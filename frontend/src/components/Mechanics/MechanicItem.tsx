
import React from 'react';

interface Props {
  name: string;
  surname: string;
}

type MechanicItemType = {
  name: string,
  surname: string
}

const MechanicItem = ({ name, surname }:MechanicItemType) => {

  return (
    <>
      {name}
      {surname}
    </>
  );
};

export default MechanicItem