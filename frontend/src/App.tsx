import "./App.css";

import { createContext, useState } from "react";
import Main from "./components/Main";

type User =
  | {
      email: string;
      password: string;
    }
  | undefined;

type Action = {
  type: string;
};

export type UserContextType = {
  user: User;
  updateUser: (s: User) => void;
};

export const UserContext = createContext<UserContextType | null>(null);

const userReducer = (state: User, action: Action) => {
  switch (action.type) {
    case "update": {
      console.log(state);
    }
  }
};

function App() {
  const [user, setUser] = useState<User>();

  const updateUser = (s: User) => {
    setUser(s);
  };

  return (
    <div className="App">
      <UserContext.Provider value={{ user, updateUser }}>
        <Main></Main>
      </UserContext.Provider>
    </div>
  );
}

export default App;
