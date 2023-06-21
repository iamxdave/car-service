import React, { useContext, useState } from "react";
import CarCarousel from "../../Cars/CarCarousel";
import OrderType from "../../../types/Orders/OrderType";
import CarForm from "../../Cars/CarForm";
import MechanicForm from "../../Mechanics/MechanicForm";
import Prelude from "../../Cars/Prelude";
import Submission from "./Submission";
import WarrantyForm from "../../Warranty/WarrantyForm";
import PartsForm from "../../Parts/PartsForm";
import { OrderContext, OrderContextType } from "../../../App";
import ValidationType from "../../../types/Orders/ValidationType";

const OrderForm = () => {
  const [openTab, setOpenTab] = useState(OrderType.Buyout);
  const { updateOrder, updateValidations } = useContext(
    OrderContext
  ) as OrderContextType;

  const handleOpenTabClick = (
    type: OrderType,
    e: React.MouseEvent<HTMLAnchorElement, MouseEvent>
  ) => {
    e.preventDefault();
    setOpenTab(type);
    updateOrder(undefined);
    for (const val of Object.values(ValidationType))
      updateValidations({ type: val as ValidationType, message: "" });
  };

  return (
    <>
      <div className="flex flex-wrap">
        <div className="w-full">
          <ul
            className="flex mb-0 list-none flex-wrap pt-3 pb-4 flex-row"
            role="tablist"
          >
            <li className="-mb-px mr-2 last:mr-0 flex-auto text-center">
              <a
                className={
                  "text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal transition-all duration-300 ease-in-out " +
                  (openTab === OrderType.Buyout
                    ? "text-white bg-neutral-900"
                    : "text-yellow-400 bg-white")
                }
                onClick={(e) => handleOpenTabClick(OrderType.Buyout, e)}
                data-toggle="tab"
                href="#link1"
                role="tablist"
              >
                Buyout
              </a>
            </li>
            <li className="-mb-px mr-2 last:mr-0 flex-auto text-center">
              <a
                className={
                  "text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal transition-all duration-300 ease-in-out " +
                  (openTab === OrderType.Repair
                    ? "text-black bg-yellow-400"
                    : "text-yellow-400 bg-white")
                }
                onClick={(e) => handleOpenTabClick(OrderType.Repair, e)}
                data-toggle="tab"
                href="#link2"
                role="tablist"
              >
                Reppair
              </a>
            </li>
          </ul>
          <div className="relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded">
            <div className="px-4 py-5 my-12 flex-auto">
              <div className="tab-content tab-space">
                <div
                  className={openTab === OrderType.Buyout ? "block" : "hidden"}
                  id="link1"
                >
                  <CarCarousel type={OrderType.Buyout} />
                  <WarrantyForm />
                </div>
                <div
                  className={openTab === OrderType.Repair ? "block" : "hidden"}
                  id="link2"
                >
                  <Prelude />
                  <CarForm />
                  <CarCarousel type={OrderType.Repair} />
                  <PartsForm />
                </div>
              </div>
              <MechanicForm />
              <Submission type={openTab} />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default OrderForm;
