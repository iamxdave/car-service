import React, { useContext, useState } from "react";
import CarCarousel from "../Cars/CarCarousel";
import OrderType from "../../types/OrderType";
import CarForm from "../Cars/CarForm";
import Buyout from "./Order/Buyout";
import Repair from "./Order/Repair";
import MechanicForm from "../Mechanics/MechanicForm";
import Title from "./Title";
import Prelude from "../Cars/Prelude";
import Conclusion from "./Conclusion";
import { UserContext, UserContextType } from "../../App";
import WarrantyForm from "../Warranty/WarrantyForm";
import PartsForm from "../Parts/PartsForm";

const OrderSelection = () => {
  const [openTab, setOpenTab] = useState(OrderType.Buyout);
  const { order, updateOrder } = useContext(UserContext) as UserContextType;

  const handleOpenTabClick = (
    type: OrderType,
    e: React.MouseEvent<HTMLAnchorElement, MouseEvent>
  ) => {
    e.preventDefault();
    setOpenTab(type);
    updateOrder(undefined);
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
              <Conclusion type={openTab} />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default OrderSelection;
