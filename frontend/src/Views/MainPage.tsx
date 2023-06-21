import { useContext, useEffect } from "react";
import {
  OrderContext,
  OrderContextType,
  UserContext,
  UserContextType,
} from "../App";
import Header from "./UI/Header";
import Container from "./UI/Container";
import Footer from "./UI/Footer";
import Intro from "./Intro/Intro";
import Banner from "./UI/Banner";
import { urlUser } from "../endpoints";
import axios, { AxiosError, AxiosResponse } from "axios";
import Introduction from "./UI/Introduction";
import OrderForm from "../components/Orders/Submissions/OrderForm";
import OrderResults from "../components/Orders/Results/OrderResults";
import { useNavigate } from "react-router-dom";

const MainPage = () => {
  const { user, updateUser } = useContext(UserContext) as UserContextType;
  const { order, updateOrder } = useContext(OrderContext) as OrderContextType;
  const navigate = useNavigate();

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
        if (reason.response!.status === 500) {
          navigate("/internalserver");
        }
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
      {user ? (
        <>
          <Container id="second" height="h-full" bgColor="bg-white">
            <div className="container my-12 mx-auto md:px-6">
              <Introduction
                title="Make your first order in our service"
                text="We provide the highest quality of service, ensuring every order is
                      delivered with precision and customer satisfaction in mind."
              />
              <OrderForm />
            </div>
          </Container>
          <Container id="third" height="h-full" bgColor="bg-white">
            <div className="container my-12 mx-auto md:px-6">
              <Introduction
                title="Keeping track of your orders"
                text="In order to provide you with a comprehensive view of your order history, 
                      we have compiled a table below that contains all the relevant data.
                      This will allow you to conveniently access and review the information 
                      pertaining to your previous orders."
              />
              <OrderResults />
            </div>
          </Container>
        </>
      ) : (
        <></>
      )}
      <Footer />
    </div>
  );
};

export default MainPage;
