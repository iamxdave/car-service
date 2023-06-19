import React from "react";
import CarForm from "../../Cars/CarForm";
import CarCarousel from "../../Cars/CarCarousel";
import OrderType from "../../../types/OrderType";
import Title from "../Title";
import PartsForm from "../../Parts/PartsForm";

const Repair = () => {
  return (
    <div>
      <CarForm />
      <CarCarousel type={OrderType.Repair} />
      <PartsForm />
    </div>
  );
};

export default Repair;
