import axios, { AxiosError, AxiosResponse } from "axios";
import { useContext, useEffect, useState } from "react";
import Mechanic from "../../types/Mechanic";
import avatar from "../../assets/avatar.png";
import { urlMechanics } from "../../endpoints";
import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";
import { CalendarIcon } from "@heroicons/react/24/outline";
import { UserContext, UserContextType } from "../../App";

const MechanicForm = () => {
  const { order, updateOrder } = useContext(UserContext) as UserContextType;
  const [data, setData] = useState<{ mechanic: Mechanic; firstDate: Date }[]>(
    []
  );
  const [selectedMechanicId, setSelectedMechanicId] = useState<
    string | undefined
  >();

  const [currentDate, setCurrentDate] = useState<string>();
  const minDate = new Date().toISOString().slice(0, 10);
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
        const updatedMechanics = response.data.map((mechanic: Mechanic) => ({
          mechanic: mechanic,
          firstDate: new Date(),
        }));
        setData(updatedMechanics);
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
          navigate("/unauthorized");
        }
      });
  }, []);

  useEffect(() => {
    if(order === undefined)
      setSelectedMechanicId(undefined);
  }, [order]);


  const handleDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setCurrentDate(event.target.value);
    console.log(filteredMechanics);
  };

  const handleMechanicSelect = (mechanicId: string | undefined) => {
    setSelectedMechanicId(mechanicId);
    updateOrder({ ...order!, idMechanic: mechanicId! });
  };

  const filteredMechanics = data
    ? data.filter((d) => {
        const selectedDate = new Date(currentDate || "");
        const selectedDateEnd = new Date(
          selectedDate.getTime() + 7 * 24 * 60 * 60 * 1000
        );
        let flag = true;

        d.mechanic.bookedDates.sort();

        for (const bookedDate of d.mechanic.bookedDates) {
          const date = new Date(bookedDate);
          const dateEnd = new Date(date.getTime() + 7 * 24 * 60 * 60 * 1000);

          if (flag) {
            if (date.getDate() - 8 >= new Date(minDate).getDate()) {
              d.firstDate = new Date(date);
              d.firstDate.setDate(d.firstDate.getDate() - 8);
            } else {
              d.firstDate = new Date(dateEnd);
              d.firstDate.setDate(d.firstDate.getDate());
            }
            flag = false;
          }
          if (
            (date <= selectedDate && selectedDate <= dateEnd) ||
            (date <= selectedDateEnd && selectedDateEnd <= dateEnd)
          ) {
            return false;
          }
        }
        return true;
      })
    : [];

  return (
    <div className="w-full py-4 px-6 md:px-12">
      <h2 className="mb-4 text-4xl font-bold tracking-tight">
        Choose our dedicated car specialist for exclusive assistance.
      </h2>
      <h3 className="mb-4 text-2xl tracking-tight text-justify">
        Our team of skilled professionals will guide you through the automotive
        service process, ensuring that you are well-informed about the changes
        that align with your preferences and requirements.
      </h3>
      <h3 className="mb-12 text-2xl tracking-tight text-justify">
        <span className="font-bold mr-3 italic">Important:</span>Our mechanics
        are available to handle orders within the next{" "}
        <span className="font-bold italic">7 days</span>.
      </h3>
      <div className="flex gap-5">
        <div className="w-1/3">
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
      </div>
      <div className="text-center">
        <section className="mb-32 mt-12 text-center">
          <div className="grid gap-x-3 grid-cols-2 sm:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 xxl:grid-cols-6">
            {filteredMechanics.map((d) => {
              return (
                <div
                  className={`mb-12 mx-3 p-3 lg:mb-0 rounded-md ${
                    selectedMechanicId === d.mechanic?.idPerson
                      ? "bg-neutral-100 shadow-md"
                      : ""
                  }`}
                  key={d.mechanic.idPerson}
                  onClick={() => handleMechanicSelect(d.mechanic?.idPerson)}
                >
                  <img
                    className="mx-auto p-4 mb-6 bg-neutral-200 rounded-full shadow-lg shadow-black/20 w-[150px]"
                    src={avatar}
                    alt="avatar"
                  />
                  <h5 className="mb-3 text-lg font-bold">
                    {d.mechanic.name} {d.mechanic.surname}
                  </h5>
                  <h5 className="mb-6 text-sm font-neutral">
                    Taking orders from <br />
                    <span className="flex justify-center items-center font-medium">
                      <CalendarIcon className="w-4 h-4 mr-1 self-center" />
                      {d.firstDate.toLocaleDateString()}
                    </span>
                  </h5>
                </div>
              );
            })}
          </div>
        </section>
      </div>
    </div>
  );
};

export default MechanicForm;
