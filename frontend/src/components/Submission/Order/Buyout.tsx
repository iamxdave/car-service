import React from "react";
import CarCarousel from "../../Cars/CarCarousel";
import OrderType from "../../../types/OrderType";
import Title from "../Title";
import WarrantyForm from "../../Warranty/WarrantyForm";

const Buyout = () => {
  return (
    <div>
      <CarCarousel type={OrderType.Buyout} />
      <WarrantyForm />
    </div>
  );
};

export default Buyout;
