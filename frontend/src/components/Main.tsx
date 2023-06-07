import { Route, Routes, useLocation } from "react-router-dom";
import App, { UserContext, UserContextType } from "../App";
import MainPage from "./MainPage";
import SignIn from "./Account/SignIn";
import { useContext } from "react";
import Unauthorized from "./Errors/Unauthorized";
import NotFound from "./Errors/NotFound";

const Main = () => {
  const { user, updateUser } = useContext(UserContext) as UserContextType;
  const location = useLocation();
  const path = location.pathname.substring(1);

  console.log(user);
  return (
    <>
      <Routes>
        <Route
          path="/"
          element={user === undefined || !user ? <SignIn/> : <MainPage/>}
        />
        <Route
          path="/main"
          element={
            // user? <MainPage/> : <Unauthorized page={path}/>
            <MainPage />
          }
        />
        <Route path="/unauthorized" element={<Unauthorized/>}/>
        <Route path="/*" element={<NotFound/>} />
      </Routes>
    </>
  );
};

export default Main;
