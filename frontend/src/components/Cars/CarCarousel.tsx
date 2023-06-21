import axios, { AxiosError, AxiosResponse } from "axios";
import { useContext, useEffect, useRef, useState } from "react";
import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";
import { urlCars } from "../../endpoints";
import CarImage from "../../assets/car.png";
import { motion } from "framer-motion";
import OrderType from "../../types/Orders/OrderType";
import {
  DataContext,
  DataContextType,
  OrderContext,
  OrderContextType,
  UserContext,
  UserContextType,
} from "../../App";
import ValidationType from "../../types/Orders/ValidationType";
import Title from "../../Views/UI/Title";

interface CarListProps {
  type: OrderType;
}

const CarCarousel = ({ type }: CarListProps) => {
  const { user } = useContext(UserContext) as UserContextType;
  const { order, validations, updateOrder, updateValidations } = useContext(
    OrderContext
  ) as OrderContextType;
  const { buyoutCars, repairCars, updateCars } = useContext(
    DataContext
  ) as DataContextType;

  const [selectedCarId, setSelectedCarId] = useState<string | undefined>();
  const url =
    type === OrderType.Repair
      ? `${urlCars}/${user?.idPerson}`
      : type === OrderType.Buyout
      ? `${urlCars}`
      : "";

  const [carouselWidth, setCarouselWidth] = useState(0);
  const carousel = useRef<HTMLDivElement>(null);
  const [cookies] = useCookies(["jwt"]);
  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(url, {
        withCredentials: true,
        headers: {
          Authorization: `Bearer ${cookies.jwt}`,
        },
      })
      .then((response: AxiosResponse<any>) => {
        updateCars(response.data, type);
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
          navigate("/unauthorized");
        }
      });
  }, []);

  useEffect(() => {
    setCarouselWidth(
      carousel.current?.scrollWidth! - carousel.current?.offsetWidth!
    );
  }, [buyoutCars, repairCars]);

  useEffect(() => {
    if (order === undefined) setSelectedCarId(undefined);
  }, [order]);

  const handleCarSelect = (carId: string, carCost: number) => {
    if (selectedCarId === carId) {
      setSelectedCarId(undefined);
      updateOrder({ ...order!, idCar: undefined, cost: undefined });
    } else {
      setSelectedCarId(carId);
      updateOrder({ ...order!, idCar: carId, cost: carCost });
    }
  };

  const resetCarSelect = () => {
    setSelectedCarId(undefined);
    updateOrder({ ...order!, idCar: undefined, cost: undefined });
  };

  const areAnyCars =
    (type === OrderType.Repair && repairCars.length === 0) ||
    (type === OrderType.Buyout && buyoutCars.length === 0);

  return (
    <div className="w-full py-4 px-6 md:px-12">
      <Title text="Select a vehicle to start a service order"></Title>
      {areAnyCars ? (
        <div className="my-6 text-2xl tracking-tight text-justify">
          {type === OrderType.Buyout && (
            <>
              At present, there are no available vehicles to place an order. We
              apologize for any inconvenience.
            </>
          )}
          {type === OrderType.Repair && (
            <>
              Currently, there are no cars available for ordering. We recommend
              adding a new car to proceed with the order placement.
            </>
          )}
        </div>
      ) : (
        <motion.div
          ref={carousel}
          className="pt-6 -mx-3 cursor-grab overflow-hidden"
          whileTap={{ cursor: "grabbing" }}
        >
          <motion.div
            drag="x"
            dragConstraints={{ right: 0, left: -carouselWidth }}
            className="flex"
            onDragEnd={resetCarSelect}
          >
            {type === OrderType.Buyout &&
              buyoutCars?.map((car) => (
                <motion.div
                  key={car?.idCar}
                  className={`min-w-[12rem] max-w-[12rem] p-3 flex flex-col justify-between rounded-md ${
                    selectedCarId === car?.idCar
                      ? "bg-neutral-100 shadow-md"
                      : ""
                  }`}
                  onClick={() => {
                    handleCarSelect(car.idCar!, car.cost!);
                    updateValidations({
                      type: ValidationType.Car,
                      message: "",
                    });
                  }}
                >
                  <div>
                    <div className="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-lg bg-neutral-200">
                      <img
                        src={CarImage}
                        alt={car?.model}
                        draggable="false"
                        className="h-full w-full p-5 object-cover object-center group-hover:opacity-75"
                      />
                    </div>
                    <h3 className="mt-4 text-md text-gray-700">
                      {car?.brand} {car?.model}
                    </h3>
                    <p className="my-3 text-sm font-medium text-gray-900 text-justify">
                      {car?.description}
                    </p>
                  </div>
                  <div>
                    <div className="mt-6 text-sm">Price</div>
                    <p className="pb-3 text-lg font-medium self-start text-gray-900">
                      ${car?.cost}
                    </p>
                  </div>
                </motion.div>
              ))}
            {type === OrderType.Repair &&
              repairCars?.map((car) => (
                <motion.div
                  key={car?.idCar}
                  className={`min-w-[12rem] max-w-[12rem] p-3 flex flex-col justify-between rounded-md ${
                    selectedCarId === car?.idCar
                      ? "bg-neutral-100 shadow-md"
                      : ""
                  }`}
                  onClick={() => {
                    handleCarSelect(car.idCar!, car.cost!);
                    updateValidations({
                      type: ValidationType.Car,
                      message: "",
                    });
                  }}
                >
                  <div>
                    <div className="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-lg bg-neutral-200">
                      <img
                        src={CarImage}
                        alt={car?.model}
                        draggable="false"
                        className="h-full w-full p-5 object-cover object-center group-hover:opacity-75"
                      />
                    </div>
                    <h3 className="mt-4 text-md text-gray-700">
                      {car?.brand} {car?.model}
                    </h3>
                    <p className="my-3 text-sm font-medium text-gray-900 text-justify">
                      {car?.description}
                    </p>
                  </div>
                  <div className="mt-6 text-sm">Registartion number</div>
                  <p className="pb-3 text-lg font-medium self-start text-gray-900">
                    <span className="font-medium">
                      {car?.registrationNumber}
                    </span>
                  </p>
                </motion.div>
              ))}
          </motion.div>
        </motion.div>
      )}
      <div className="flex items-center">
        {validations?.some((v) => v?.type === ValidationType.Car) ? (
          <p className="h-10 p-1 text-lg italic text-red-600">
            {validations.find((v) => v?.type === ValidationType.Car)?.message}
          </p>
        ) : (
          <div className="h-10"></div>
        )}
      </div>
    </div>
  );
};

export default CarCarousel;
