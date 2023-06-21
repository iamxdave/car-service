import { useContext, useEffect, useState } from "react";
import OrderType from "../../../types/Orders/OrderType";
import {
  DataContext,
  DataContextType,
  OrderContext,
  OrderContextType,
  UserContext,
  UserContextType,
} from "../../../App";
import { urlOrders } from "../../../endpoints";
import axios, { AxiosError, AxiosResponse } from "axios";
import ValidationType from "../../../types/Orders/ValidationType";
import OrderResult from "../../../types/Orders/OrderResult";
import { useNavigate } from "react-router-dom";

const Submission = ({ type }: { type: OrderType }) => {
  const { user } = useContext(UserContext) as UserContextType;
  const {
    order,
    orderResults,
    validations,
    updateOrder,
    updateOrderResults,
    updateValidations,
  } = useContext(OrderContext) as OrderContextType;
  const { removeMechanic, removeCar } = useContext(
    DataContext
  ) as DataContextType;
  const [response, setResponse] = useState<OrderResult | undefined>();

  const navigate = useNavigate();
  const url =
    type === OrderType.Repair ? `${urlOrders}/repair` : `${urlOrders}/buyout`;

  const handleFormSubmit = async () => {
    var validate = true;

    if (order?.idCar === undefined) {
      updateValidations({
        type: ValidationType.Car,
        message: "Please select a car for an order",
      });
      validate = false;
    }

    if (order?.idMechanic === undefined) {
      updateValidations({
        type: ValidationType.Mechanic,
        message: "Please select a mechanic for an order",
      });
      validate = false;
    }

    if (
      type === OrderType.Repair &&
      (order?.idParts === undefined || order?.idParts.length === 0)
    ) {
      updateValidations({
        type: ValidationType.Part,
        message: "Please select at least one part to repair for an order",
      });
      validate = false;
    }

    if (!validate) return;

    const formData = {
      ...order,
    };

    await axios
      .post(url, { ...formData, idUser: user?.idPerson })
      .then((response: AxiosResponse) => {
        if (response.status === 201) {
          setResponse(response.data);
          updateOrderResults([response.data]);
          removeMechanic(response.data.mechanic);
          removeCar(response.data.car, type);
        }
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 500) {
          navigate("/internalserver");
        }
      });
  };

  useEffect(() => {
    if (order === undefined) setResponse(undefined);
  }, [order]);

  return (
    <div className="w-full py-4 px-6 md:px-12">
      <section className="mb-6">
        <div className="py-4 border-t-4">
          {type === OrderType.Buyout && (
            <>
              <h2 className="mb-4 text-4xl font-bold tracking-tight">
                Total order cost
              </h2>
              <h3 className="mb-4 text-2xl md:text-3xl font-medium tracking-tight text-justify">
                $
                {response?.cost === undefined
                  ? order?.cost
                    ? order.cost
                    : 0
                  : response.cost}
              </h3>
            </>
          )}
          {type === OrderType.Repair && (
            <>
              <h2 className="mb-4 text-4xl font-bold tracking-tight">
                Total order cost
              </h2>
              {response?.cost === undefined ? (
                <h3 className="mb-4 text-xl md:text-2xl tracking-tight text-justify">
                  The estimated cost of the order will be provided upon
                  consultation with our mechanics regarding the pricing of the
                  parts.
                </h3>
              ) : (
                <h3 className="mb-4 text-2xl md:text-3xl font-medium tracking-tight text-justify">
                  ${response?.cost ? response.cost : 0}
                </h3>
              )}
            </>
          )}
        </div>
        <div className="flex flex-col gap-3 lg:flex-row text-xl md:text-2xl font-normal tracking-tight text-justify">
          {response?.idOrder !== undefined ? (
            <>
              <span>Your order has id:</span>
              <span className="lg:ml-3">{response.idOrder}</span>
            </>
          ) : (
            <></>
          )}
        </div>
        <div>
          {validations?.some((v) => v?.type === ValidationType.Total) ? (
            <p className="h-10 p-1 text-lg italic text-red-600">
              {
                validations.find((v) => v?.type === ValidationType.Total)
                  ?.message
              }
            </p>
          ) : (
            <div className="h-10"></div>
          )}
        </div>
      </section>
      <button
        className="min-w-[300px] bg-yellow-400 text-neutral-700 py-3 mb-3 text-lg font-medium uppercase leading-normal shadow-[0_4px_9px_-4px_#566573] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)]"
        onClick={handleFormSubmit}
      >
        Submit your order
      </button>
    </div>
  );
};

export default Submission;
