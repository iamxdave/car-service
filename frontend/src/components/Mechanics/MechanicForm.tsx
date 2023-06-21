import axios, { AxiosError, AxiosResponse } from "axios";
import { useContext, useEffect, useState } from "react";
import Mechanic from "../../types/Mechanic";
import Avatar from "../../assets/avatar.png";
import { urlMechanics } from "../../endpoints";
import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";
import {
  DataContext,
  DataContextType,
  OrderContext,
  OrderContextType,
} from "../../App";
import ValidationType from "../../types/Orders/ValidationType";

const MechanicForm = () => {
  const { order, validations, updateOrder, updateValidations } = useContext(
    OrderContext
  ) as OrderContextType;
  const { mechanics, updateMechanics } = useContext(
    DataContext
  ) as DataContextType;
  const [selectedMechanicId, setSelectedMechanicId] = useState<
    string | undefined
  >();
  const [filteredMechanics, setFilteredMechanics] = useState<Mechanic[]>([]);

  const minDate = new Date().toISOString().slice(0, 10);
  const [currentDate, setCurrentDate] = useState<string>(minDate);
  const [cookies] = useCookies(["jwt"]);
  const navigate = useNavigate();

  useEffect(() => {
    setCurrentDate(minDate);

    axios
      .get(urlMechanics, {
        withCredentials: true,
        headers: {
          Authorization: `Bearer ${cookies.jwt}`,
        },
      })
      .then((response: AxiosResponse<any>) => {
        updateMechanics(response.data);
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
          navigate("/unauthorized");
        }
        if (reason.response!.status === 500) {
          navigate("/internalserver");
        }
      });
  }, []);

  useEffect(() => {
    if (order === undefined) setSelectedMechanicId(undefined);
  }, [order]);

  useEffect(() => {
    setSelectedMechanicId(undefined);
  }, [mechanics]);

  const handleDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setCurrentDate(event.target.value);
  };

  useEffect(() => {
    setFilteredMechanics((prev) => [
      ...mechanics.filter((d) => {
        const selectedDate = new Date(currentDate);
        const selectedDateEnd = new Date(selectedDate.getDate() + 7);

        let overlaps = false;
        for (const bookedDate of d.bookedDates) {
          const mechanicStart = new Date(
            new Date(bookedDate.start).getDate() - 7
          );

          if (
            mechanicStart <= selectedDateEnd &&
            new Date(bookedDate.end) >= selectedDate
          )
            overlaps = true;
        }

        return !overlaps;
      }),
    ]);
  }, [currentDate, mechanics]);

  const handleMechanicSelect = (mechanicId: string) => {
    if (mechanicId === selectedMechanicId) {
      setSelectedMechanicId(undefined);
      updateOrder({ ...order!, idMechanic: undefined, dateStarted: undefined });
    } else {
      setSelectedMechanicId(mechanicId);
      updateOrder({
        ...order!,
        idMechanic: mechanicId!,
        dateStarted: new Date(currentDate || ""),
      });
    }
  };

  return (
    <div className="w-full py-4 px-6 md:px-12">
      <h2 className="mb-4 text-3xl md:text-4xl font-bold tracking-tight">
        Choose our dedicated car specialist for exclusive assistance.
      </h2>
      <h3 className="mb-4 text-xl md:text-2xl tracking-tight text-justify">
        Our team of skilled professionals will guide you through the automotive
        service process, ensuring that you are well-informed about the changes
        that align with your preferences and requirements.
      </h3>
      <h3 className="mb-12 text-xl md:text-2xl tracking-tight text-justify">
        <span className="font-bold mr-3 italic">Important:</span>Our mechanics
        are available to handle orders within the next{" "}
        <span className="font-bold italic">7 days</span>.
      </h3>
      <div className="flex flex-col md:flex-row md:gap-5">
        <div className="w-1/3 min-w-[300px]">
          <label
            className="block uppercase tracking-wide text-neutral-700 text-xs font-bold mb-2"
            htmlFor="start"
          >
            Date
          </label>
          <input
            className="w-full bg-neutral-200 text-neutral-700 border border-neutral-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-neutral-500"
            type="date"
            id="start"
            name="trip-start"
            value={currentDate}
            min={minDate}
            max="2024-01-01"
            onChange={handleDateChange}
          ></input>
        </div>
        <div className="flex items-center my-3">
          {validations?.some((v) => v?.type === ValidationType.Mechanic) ? (
            <p className="h-10 p-1 text-lg italic text-red-600">
              {
                validations.find((v) => v?.type === ValidationType.Mechanic)
                  ?.message
              }
            </p>
          ) : (
            <div className="h-10"></div>
          )}
        </div>
      </div>
      <div className="text-center">
        <section className="mb-12 mt-6 text-center">
          {filteredMechanics.length === 0 ? (
            <div className="my-6 text-2xl tracking-tight text-justify">
              Currently, there are no available mechanics to accommodate orders
              on the specified date. We kindly suggest considering alternative
              dates for booking.
            </div>
          ) : (
            <div className="grid gap-x-3 grid-cols-2 sm:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 xxl:grid-cols-6">
              {filteredMechanics.map((d) => {
                return (
                  <div
                    className={`mb-12 mx-3 p-3 lg:mb-0 rounded-md ${
                      selectedMechanicId === d.idPerson
                        ? "bg-neutral-100 shadow-md"
                        : ""
                    }`}
                    key={d.idPerson}
                    onClick={() => {
                      handleMechanicSelect(d.idPerson);
                      updateValidations({
                        type: ValidationType.Mechanic,
                        message: "",
                      });
                    }}
                  >
                    <img
                      className="mx-auto p-4 mb-6 bg-neutral-200 rounded-full shadow-lg shadow-black/20 w-[150px]"
                      src={Avatar}
                      alt="avatar"
                    />
                    <h5 className="mb-3 text-lg font-bold">
                      {d.name} {d.surname}
                    </h5>
                  </div>
                );
              })}
            </div>
          )}
        </section>
      </div>
    </div>
  );
};

export default MechanicForm;
