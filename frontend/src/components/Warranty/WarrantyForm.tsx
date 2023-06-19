import React, { useContext, useEffect, useState } from "react";
import { UserContext, UserContextType } from "../../App";

const WarrantyForm = () => {
  const { order, updateOrder } = useContext(UserContext) as UserContextType;
  const [value, setValue] = useState(0);
  const [prevValue, setPrevValue] = useState(0);
  
  const handleSliderChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = parseInt(e.target.value);
    setValue(newValue);

    const isIncreasing = newValue > prevValue;
    setPrevValue(newValue);
  
    const costAdjustment = isIncreasing ? 100 : -100;
  
    updateOrder({ ...order!, warranty: 5 + newValue, cost: order?.cost! + costAdjustment });
  };

  useEffect(() => {
    if(order === undefined)
      setValue(0);
  }, [order]);


  return (
    <div className="py-4 px-6 md:px-12 mt-12 mb-24">
      <h2 className="mb-4 text-4xl font-bold tracking-tight">
        Boost your <span className="text-yellow-600">confidence</span> with our
        car's warranty coverage.
      </h2>
      <h3 className="mb-4 text-2xl tracking-tight text-justify">
        The warranty duration for the car can be extended by adjusting the
        slider. The default warranty value is{" "}
        <span className="font-bold italic"> 5 years</span>, and you have the
        option to add additional duration as per your preference.
      </h3>
      <h3 className="mb-4 text-2xl tracking-tight text-justify">
        There is a supplementary cost of{" "}
        <span className="font-bold italic">$100</span> for each additional year.
      </h3>

      <div className="flex flex-col w-full gap-5">
        <label
          htmlFor="customRange1"
          className="inline-block text-2xl italic font-medium mt-6 text-neutral-700"
        >
          Extra years: <span className="ml-2">{value}</span>
        </label>
        <input
          type="range"
          className="h-full max-w-lg py-1 px-1 flex-grow cursor-pointer appearance-none rounded-lg bg-neutral-200"
          step={1}
          min="0"
          max="5"
          disabled={order?.idCar === undefined}
          
          value={value}
          id="customRange1"
          onChange={handleSliderChange}
        />
      </div>
    </div>
  );
};

export default WarrantyForm;
