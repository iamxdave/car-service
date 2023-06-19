import axios, { AxiosError, AxiosResponse } from "axios";
import { RefObject, createRef, useContext, useEffect, useState } from "react";
import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";
import { urlCars } from "../../endpoints";
import CarImage from "../../assets/car2.png";
import { motion } from "framer-motion";
import OrderType from "../../types/OrderType";
import {
  CarContext,
  CarContextType,
  UserContext,
  UserContextType,
} from "../../App";

interface CarListProps {
  type: OrderType;
}

const CarCarousel = ({ type }: CarListProps) => {
  const { user, order, updateOrder } = useContext(
    UserContext
  ) as UserContextType;
  const { buyoutCars, repairCars, updateCars } = useContext(
    CarContext
  ) as CarContextType;

  const [selectedCarId, setSelectedCarId] = useState<string | undefined>();

  const url =
    type === OrderType.Repair ? `${urlCars}/${user?.idPerson}` : urlCars;

  const [carouselWidth, setCarouselWidth] = useState(0);
  const carousel: RefObject<HTMLDivElement> = createRef();

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
        setCarouselWidth(
          carousel.current?.scrollWidth! - carousel.current?.offsetWidth!
        );
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
          navigate("/unauthorized");
        }
      });
  }, []);

  useEffect(() => {
    if(order === undefined)
      setSelectedCarId(undefined);
  }, [order]);

  const handleCarSelect = (carId: string, carCost: number) => {
    setSelectedCarId(carId);
    updateOrder({ ...order!, idCar: carId, cost: carCost});
  };

  return (
    <div className="w-full py-4 px-6 md:px-12">
      <p className="text-4xl py-4 font-normal tracking-wide uppercase shrink-0 border-b-4">
        Select a vehicle to start a service order.
      </p>
      <motion.div
        ref={carousel}
        className="py-6 px-3 md:px-6 cursor-grab overflow-hidden"
        whileTap={{ cursor: "grabbing" }}
      >
        <motion.div
          drag="x"
          dragConstraints={{ right: 0, left: -carouselWidth }}
          className="flex"
        >
          {type === OrderType.Buyout &&
            buyoutCars?.map((car) => (
              <motion.div
                key={car?.idCar}
                className={`min-w-[12rem] max-w-[12rem] p-3 flex flex-col justify-between rounded-md ${
                  selectedCarId === car?.idCar ? "bg-neutral-100 shadow-md" : ""
                }`}
                onClick={() => handleCarSelect(car.idCar!, car.cost!)}
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
                  selectedCarId === car?.idCar ? "bg-neutral-100 shadow-md" : ""
                }`}
                onClick={() => handleCarSelect(car.idCar!, car.cost!)}
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
                  <span className="font-medium">{car?.registrationNumber}</span>
                </p>
              </motion.div>
            ))}
        </motion.div>
      </motion.div>
    </div>
  );
};

export default CarCarousel;
