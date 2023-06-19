import MechanicForm from "./Mechanics/MechanicForm";
import { useContext, useEffect } from "react";
import { UserContext, UserContextType } from "../App";
import Header from "./UI/Header";
import Container from "./UI/Container";
import Footer from "./UI/Footer";
import Intro from "./Intro/Intro";
import { Parallax, ParallaxLayer } from "@react-spring/parallax";
import OrderSelection from "./Submission/OrderSelection";
import Banner from "./Banner/Banner";
import Introduction from "./Submission/Introduction";
import Submission from "./Submission/Submission";
import { urlUser } from "../endpoints";
import axios, { AxiosError, AxiosResponse } from "axios";

const MainPage = () => {
  const { user, order, updateUser, updateOrder } = useContext(
    UserContext
  ) as UserContextType;

  useEffect(() => {
    axios.defaults.withCredentials = true;

    axios
      .get(urlUser)
      .then((response: AxiosResponse) => {
        if (response.status === 200) {
          const user = response.data;
          updateUser(user);
          updateOrder({ ...order!, idUser: user.idPerson });
        }
      })
      .catch((reason: AxiosError) => {
        return;
      });
  }, []);

  return (
    <div className="flex flex-col">
      <Header />
      <Container
        id="first"
        height="h-[calc(100vh-72px)]"
        bgColor="bg-neutral-900"
      >
        <Intro />
        <Banner />
      </Container>
      <Container id="second" height="h-full" bgColor="bg-white">
        {user ? <Submission /> : <div></div>}
      </Container>
      <Footer />
    </div>
  );
};

export default MainPage;
