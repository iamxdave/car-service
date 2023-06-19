import React, { useContext, useEffect, useState } from "react";
import OrderType from "../../types/OrderType";
import { UserContext, UserContextType } from "../../App";
import Order from "../../types/Order";
import { urlOrders } from "../../endpoints";
import axios, { AxiosError, AxiosResponse } from "axios";

const Conclusion = ({ type }: { type: OrderType }) => {
  const { user, order, updateOrder } = useContext(
    UserContext
  ) as UserContextType;

  const url =
    type === OrderType.Repair ? `${urlOrders}/repair` : `${urlOrders}/buyout`;

  const handleFormSubmit = async () => {
    const formData = {
      ...order
    };

    console.log(formData)

    await axios
      .post(url, {...formData, idUser: user?.idPerson})
      .then((response: AxiosResponse) => {
        if (response.status === 201) {
          console.log(response.data);
        }
      })
      .catch((reason: AxiosError) => {
        console.log(reason.response?.data)
      });
  };
  
  return (
    <div className="px-6">
      <section className="mb-16">
        <div className="py-4 px-3 border-t-4">
          {type === OrderType.Buyout && (
            <>
              <h2 className="mb-4 text-4xl font-bold tracking-tight">
                Total order cost
              </h2>
              <h3 className="mb-4 text-3xl font-medium tracking-tight text-justify">
                ${order?.cost ? order.cost : 0}
              </h3>
            </>
          )}
          {type === OrderType.Repair && (
            <>
              <h2 className="mb-4 text-4xl font-bold tracking-tight">
                Total order cost
              </h2>
              <h3 className="mb-4 text-2xl tracking-tight text-justify">
                The estimated cost of the order will be provided upon
                consultation with our mechanics regarding the pricing of the
                parts.
              </h3>
            </>
          )}
        </div>
      </section>
      <button
        className="w-1/3 border py-3 mb-3 text-lg bg-yellow-600 font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#566573] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)]"
        onClick={handleFormSubmit}
      >
        Submit your order
      </button>
    </div>
  );
};

export default Conclusion;
