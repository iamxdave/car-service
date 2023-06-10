import Mechanic from "../../types/Mechanic";

const MechanicItem = ({mechanic}:{mechanic:Mechanic}) => {

  return (
    <>
      {mechanic.name}
      {mechanic.surname}
    </>
  );
};

export default MechanicItem