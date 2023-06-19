import React, { useContext, useEffect, useState } from "react";
import {
  CarContext,
  CarContextType,
  UserContext,
  UserContextType,
} from "../../App";
import Car from "../../types/Car";
import axios, { AxiosError, AxiosResponse } from "axios";
import { urlCars, urlWorkshops } from "../../endpoints";
import { useCookies } from "react-cookie";
import Workshop from "../../types/Workshop";
import { useNavigate } from "react-router-dom";
import OrderType from "../../types/OrderType";

const CarForm = () => {
  const [formData, setFormData] = useState<Car>({
    idWorkshop: 1,
    brand: "",
    model: "",
    registrationNumber: "",
  });
  const { user } = useContext(UserContext) as UserContextType;
  const { updateCars } = useContext(CarContext) as CarContextType;
  const [workshops, setWorkshops] = useState<Workshop[] | null>();
  const [validation, setValidation] = useState("");
  const [cookies] = useCookies(["jwt"]);
  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(urlWorkshops)
      .then((response: AxiosResponse) => {
        if (response.status === 200) {
          setWorkshops(response.data);
        }
      })
      .catch((reason: AxiosError) => {});
  }, []);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const url = `${urlCars}/${user?.idPerson}`;

    await axios
      .post(url, formData, {
        withCredentials: true,
        headers: {
          Authorization: `Bearer ${cookies.jwt}`,
        },
      })
      .then((response: AxiosResponse) => {
        updateCars([formData], OrderType.Repair);
      })
      .catch((reason: AxiosError) => {
        const msg = (reason.response!.data as { message: string }).message;
        if (reason.response!.status === 409) {
          setValidation(msg);
        }
      });
  };

  return (
    <form className="w-full py-4 px-6 md:px-12 my-12" onSubmit={handleSubmit}>
      <div className="flex mb-6">
        <div className="flex flex-col justify-end w-1/3 px-3">
          <label
            className="block uppercase tracking-wide text-neutral-700 text-xs font-bold mb-2"
            htmlFor="brand"
          >
            Brand
          </label>
          <input
            className="w-full bg-neutral-200 text-neutral-700 border py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white"
            id="brand"
            value={formData.brand}
            type="text"
            onChange={(e) =>
              setFormData((prev) => ({
                ...prev,
                brand: e.target.value,
              }))
            }
            required
            placeholder="Ford"
          ></input>
          <p className="h-5"></p>
        </div>
        <div className="flex flex-col justify-end w-1/3 px-3">
          <label
            className="block uppercase tracking-wide text-neutral-700 text-xs font-bold mb-2"
            htmlFor="model"
          >
            Model
          </label>
          <input
            className="w-full bg-neutral-200 text-neutral-700 border border-neutral-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-neutral-500"
            id="model"
            value={formData.model}
            type="text"
            onChange={(e) =>
              setFormData((prev) => ({
                ...prev,
                model: e.target.value,
              }))
            }
            required
            placeholder="Fiesta"
          ></input>
          <p className="h-5"></p>
        </div>
        <div className="w-1/3 px-3">
          <label
            className="block uppercase tracking-wide text-neutral-700 text-xs font-bold mb-2"
            htmlFor="registrationNumber"
          >
            Registration number
          </label>
          <input
            className="w-full bg-neutral-200 text-neutral-700 border border-neutral-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-neutral-500"
            id="registartionNumber"
            value={formData.registrationNumber}
            type="text"
            onChange={(e) => {
              setFormData((prev) => ({
                ...prev,
                registrationNumber: e.target.value,
              }));
              setValidation("");
            }}
            required
            placeholder="XYZ 12345"
          ></input>
          <p className="h-5 p-1 text-sm text-red-600">{validation}</p>
        </div>
      </div>
      <div className="flex mb-6">
        <div className="flex flex-col justify-end w-1/3 px-3">
          <label
            className="block uppercase tracking-wide text-neutral-700 text-xs font-bold mb-2"
            htmlFor="brand"
            style={{ visibility: "hidden" }}
          >
            hidden
          </label>
          <button
            type="submit"
            className="block w-full h-full border py-3 mb-3 bg-neutral-700 text-sm font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#566573] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)]"
            data-te-ripple-init
            data-te-ripple-color="light"
          >
            Submit
          </button>
        </div>
        <div className="w-2/3 px-3">
          <label
            className="block uppercase tracking-wide text-neutral-700 text-xs font-bold mb-2"
            htmlFor="brand"
          >
            Workshop
          </label>
          <select
            className="w-full bg-neutral-200 text-neutral-700 border py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white"
            id="brand"
            value={formData.idWorkshop}
            onChange={(e) => {
              setFormData((prev) => ({
                ...prev,
                idWorkshop: Number.parseInt(e.target.value),
              }));
            }}
            required
          >
            {workshops?.map((e) => (
              <option
                key={e.idWorkshop}
                value={e.idWorkshop}
                className="text-neutral-900"
              >
                {e.address}
              </option>
            ))}
          </select>
        </div>
      </div>
    </form>
  );
};

export default CarForm;
