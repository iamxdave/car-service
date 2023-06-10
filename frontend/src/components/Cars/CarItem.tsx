import Car from "../../types/Car";

const CarItem = ({car: car}:{car:Car}) => {

  return (
    <>
      {car.model}
      {car.registrationNumber}
      {car.cost}
      {car.warranty}
    </>
  );
};

export default CarItem