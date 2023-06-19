import "./App.css";

import { createContext, useEffect, useState } from "react";
import Main from "./components/Main";
import Car from "./types/Car";
import OrderType from "./types/OrderType";
import Order from "./types/Order";
import User from "./types/User";



export type UserContextType = {
  user: User | undefined;
  order: Order | undefined;
  updateUser: (s: User) => void;
  updateOrder: (s: Order) => void;
};

export type CarContextType = {
  repairCars: Car[];
  buyoutCars: Car[];
  updateCars: (s: Car[], o: OrderType) => void;
};

// export type OrderContextType = {
//   order: Order | undefined;
//   validation: { type: }
//   updateOrder: (s: Order) => void;
// };

export const UserContext = createContext<UserContextType | null>(null);
export const CarContext = createContext<CarContextType | null>(null);

function App() {
  const [user, setUser] = useState<User>();
  const [buyoutCars, setBuyoutCars] = useState<Car[]>([]);
  const [repairCars, setRepairCars] = useState<Car[]>([]);
  const [order, setOrder] = useState<Order>();

  const updateUser = (s: User) => {
    setUser(s);
  };

  const updateCars = (s: Car[], o: OrderType) => {
    if (o == OrderType.Buyout) setBuyoutCars((prev) => [...prev, ...s]);

    if (o == OrderType.Repair) setRepairCars((prev) => [...prev, ...s]);
  };

  const updateOrder = (s: Order) => {
    setOrder(s);
  };


  return (
    <div className="App">
      <UserContext.Provider value={{ user, updateUser, order, updateOrder }}>
        <CarContext.Provider value={{ buyoutCars, repairCars, updateCars }}>
          <Main></Main>
        </CarContext.Provider>
      </UserContext.Provider>
    </div>
  );
}

export default App;
