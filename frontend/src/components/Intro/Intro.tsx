import welcome_guy from "../../assets/guy.png";
import TextAnimation from "./TextAnimation";

const Intro = () => {
  return (
    <div className="container mx-auto md:px-6">
      <section className="background-radial-gradient mb-32">
        <div className="px-6 py-12 text-center md:px-12 lg:text-left">
          <div className="container mx-auto">
            <div className="grid items-center gap-12 lg:grid-cols-2">
              <div className="mt-12 lg:mt-0">
                <h1 className="mb-12 text-5xl font-bold tracking-tight text-[hsl(218,81%,95%)] md:text-6xl xl:text-7xl">
                  Driven by <br />
                  <TextAnimation text="EXCELLENCE" />
                </h1>
                <p className="text-lg text-[hsl(218,81%,95%)]">
                  Experience the epitome of automotive excellence with our
                  unparalleled car service, where your satisfaction is our driving force.
                </p>
              </div>
              <div className="mb-12 lg:mb-0">
                <img src={welcome_guy} className="relative"></img>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Intro;
