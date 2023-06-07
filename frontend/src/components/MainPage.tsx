import MechanicList from "./Mechanics/MechanicList";
import { useContext } from "react";
import { UserContext, UserContextType } from "../App";
import Header from "./UI/Header";
import Container from "./UI/Container";
import Footer from "./UI/Footer";
import Intro from "./Intro/Intro";


const MainPage = () => {
  const { user, updateUser } = useContext(UserContext) as UserContextType;
  return (
    <div className="flex flex-col">
      <Header />
      <Container>
        <Intro/>
        <MechanicList></MechanicList>
        <div className="h-screen">hello</div>
      </Container>
      <Footer />
    </div>
  );
};

export default MainPage;
