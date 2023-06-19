import Part from "./Part";

type Order =
  | {
      idUser: string;
      idMechanic: string;
      idCar: string;
      cost?: number;
      warranty?: number;
      parts?: Part[];
    }
  | undefined;

export default Order;
