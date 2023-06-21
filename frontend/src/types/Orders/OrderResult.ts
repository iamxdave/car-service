import Car from "../Car";
import Mechanic from "../Mechanic";
import Part from "../Part";

type OrderResult =
  | {
      idOrder: string;
      mechanic: Mechanic;
      car: Car;
      cost: number | undefined;
      dateStarted: Date;
      status?: number | undefined;
      dateCompleted?: Date;
      warranty?: number;
      parts?: Part[];
    }
  | undefined;

export default OrderResult;
