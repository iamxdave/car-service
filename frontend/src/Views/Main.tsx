import { Route, Routes } from "react-router-dom";
import MainPage from "./MainPage";
import LogIn from "./Account/LogIn";
import Unauthorized from "./Errors/Unauthorized";
import NotFound from "./Errors/NotFound";
import SignUp from "./Account/SingUp";
import InternalServer from "./Errors/InternalServer";

const Main = () => {
  return (
    <>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/login" element={<LogIn />}></Route>
        <Route path="/signup" element={<SignUp />}></Route>
        <Route path="/unauthorized" element={<Unauthorized />} />
        <Route path="/internalserver" element={<InternalServer />} />
        <Route path="/*" element={<NotFound />} />
      </Routes>
    </>
  );
};

export default Main;
