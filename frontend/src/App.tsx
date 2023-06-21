import "./App.css";

import { createContext, useState } from "react";
import Main from "./Views/Main";
import Car from "./types/Car";
import OrderType from "./types/Orders/OrderType";
import Order from "./types/Orders/Order";
import User from "./types/User";
import Validation from "./types/Orders/Validation";
import ValidationType from "./types/Orders/ValidationType";
import OrderResult from "./types/Orders/OrderResult";
import Mechanic from "./types/Mechanic";

export type UserContextType = {
  user: User | undefined;
  updateUser: (s: User) => void;
};

export type DataContextType = {
  mechanics: Mechanic[];
  repairCars: Car[];
  buyoutCars: Car[];
  removeMechanic: (s: Mechanic) => void;
  removeCar: (s: Car, o: OrderType) => void;
  updateMechanics: (s: Mechanic[]) => void;
  updateCars: (s: Car[], o: OrderType) => void;
  updateRepairCar: (s: Car) => void;
};

export type OrderContextType = {
  order: Order | undefined;
  orderResults: OrderResult[];
  validations: Validation[] | undefined;
  updateOrder: (s: Order) => void;
  updateOrderResults: (s: OrderResult[]) => void;
  updateValidations: (s: Validation) => void;
};

export const UserContext = createContext<UserContextType | null>(null);
export const OrderContext = createContext<OrderContextType | null>(null);
export const DataContext = createContext<DataContextType | null>(null);

function App() {
  const [user, setUser] = useState<User>();
  const [mechanics, setMechanics] = useState<Mechanic[]>([]);
  const [buyoutCars, setBuyoutCars] = useState<Car[]>([]);
  const [repairCars, setRepairCars] = useState<Car[]>([]);
  const [order, setOrder] = useState<Order>();
  const [orderResults, setOrderResults] = useState<OrderResult[]>([]);
  const [validations, setValidations] = useState<Validation[]>([]);

  const updateUser = (s: User) => {
    setUser(s);
  };

  const removeMechanic = (s: Mechanic) => {
    setMechanics((prev) => [
      ...prev.filter((m) => m.idPerson !== s.idPerson),
      s,
    ]);
  };

  const removeCar = (s: Car, o: OrderType) => {
    if (o == OrderType.Buyout)
      setBuyoutCars((prev) => [...prev.filter((c) => c.idCar !== s.idCar)]);

    if (o == OrderType.Repair)
      setRepairCars((prev) => [...prev.filter((c) => c.idCar !== s.idCar)]);
  };

  const updateMechanics = (s: Mechanic[]) => {
    setMechanics((prev) => [...prev, ...s]);
  };

  const updateRepairCar = (s: Car) => {
    setRepairCars((prev) => [...prev.filter((c) => c.idCar !== undefined), s]);
  };

  const updateCars = (s: Car[], o: OrderType) => {
    if (o == OrderType.Buyout) setBuyoutCars((prev) => [...prev, ...s]);

    if (o == OrderType.Repair) setRepairCars((prev) => [...prev, ...s]);
  };

  const updateValidations = (s: Validation) => {
    if (s?.message !== "") {
      setValidations((prev) => [
        ...prev,
        s,
        {
          type: ValidationType.Total,
          message: "Please fill the form before submition",
        },
      ]);
    } else {
      setValidations((prev) =>
        prev.filter(
          (v) => v?.type !== s?.type && v?.type !== ValidationType.Total
        )
      );
    }
  };

  const updateOrder = (s: Order) => {
    setOrder(s);
  };

  const updateOrderResults = (s: OrderResult[]) => {
    setOrderResults((prev) => [...prev, ...s]);
  };

  return (
    <div className="App">
      <UserContext.Provider value={{ user, updateUser }}>
        <OrderContext.Provider
          value={{
            order,
            orderResults,
            validations,
            updateOrder,
            updateOrderResults,
            updateValidations,
          }}
        >
          <DataContext.Provider
            value={{
              mechanics,
              buyoutCars,
              repairCars,
              removeMechanic,
              removeCar,
              updateMechanics,
              updateCars,
              updateRepairCar,
            }}
          >
            <Main></Main>
          </DataContext.Provider>
        </OrderContext.Provider>
      </UserContext.Provider>
    </div>
  );
}

export default App;
