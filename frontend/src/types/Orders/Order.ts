type Order =
  | {
      idUser: string;
      idMechanic: string | undefined;
      idCar: string | undefined;
      dateStarted: Date | undefined;
      cost?: number | undefined;
      warranty?: number;
      idParts?: number[];
    }
  | undefined;

export default Order;
