import { Route, Routes, useLocation } from "react-router-dom";
import App, { UserContext, UserContextType } from "../App";
import MainPage from "./MainPage";
import LogIn from "./Account/LogIn";
import { useContext } from "react";
import Unauthorized from "./Errors/Unauthorized";
import NotFound from "./Errors/NotFound";

const Main = () => {
  const { user, updateUser } = useContext(UserContext) as UserContextType;
  const location = useLocation();
  const path = location.pathname.substring(1);

  return (
    <>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route
          path="/main"
          element={
            // user? <MainPage/> : <Unauthorized page={path}/>
            <MainPage />
          }
        />
        <Route path="/login" element={<LogIn />}></Route>
        <Route path="/unauthorized" element={<Unauthorized />} />
        <Route path="/*" element={<NotFound />} />
      </Routes>
    </>
  );
};

export default Main;
