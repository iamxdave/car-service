import MechanicList from "./Mechanics/MechanicList";
import { useContext } from "react";
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

const MainPage = () => {
  const { user, updateUser } = useContext(UserContext) as UserContextType;

  return (
    <div className="flex flex-col">
      <Header />
      <Container id="first" height="h-[calc(100vh-80px)]" bgColor="bg-neutral-900">
        <Intro />
        <Banner />
      </Container>
      <Container id="second" height="h-screen" bgColor="bg-white">
        {user?
          <Submission />
        : <div></div>}
      </Container>
      <Container id="third" height="h-screen" bgColor="bg-white">
        {user?
          <Submission />
        : <div></div>}
      </Container>

      <Footer />
      {/* <Parallax pages={4}>
        <ParallaxLayer sticky={{ start: 0, end: 4 }}>
          <Header />
        </ParallaxLayer>
        <ParallaxLayer speed={1}>
          <Container>
            <Intro />
            <Banner />
          </Container>
        </ParallaxLayer>
        <ParallaxLayer offset={1} speed={0.5}>
          <OrderSelection />
        </ParallaxLayer>
        <ParallaxLayer offset={3.8}>
          <Footer />
        </ParallaxLayer>
      </Parallax> */}
    </div>
  );
};

export default MainPage;
