import { useContext, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import {
  OrderContext,
  OrderContextType,
  UserContext,
  UserContextType,
} from "../../App";
import axios, { AxiosError, AxiosResponse } from "axios";
import { urlRegister } from "../../endpoints";
import Credit from "../../types/User";
import Slogan from "../../assets/slogan.jpg";

const SignUp = () => {
  const [formData, setFormData] = useState<Credit>({
    idPerson: "",
    name: "",
    surname: "",
    email: "",
    password: "",
  });
  const { updateUser } = useContext(UserContext) as UserContextType;
  const { order, updateOrder } = useContext(OrderContext) as OrderContextType;
  const [validation, setValidation] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    await axios
      .post(urlRegister, formData)
      .then((response: AxiosResponse) => {
        if (response.status === 201) {
          updateUser(formData);
          updateOrder({ ...order!, idUser: formData!.idPerson });
          navigate("/login");
        }
      })
      .catch((reason: AxiosError) => {
        const msg = (reason.response!.data as { message: string }).message;
        if (reason.response!.status === 409) {
          setValidation(msg);
        }
        if (reason.response!.status === 500) {
          navigate("/internalserver");
        }
      });
  };

  return (
    <section className="h-screen flex bg-neutral-900 items-center flex-col lg:flex-row">
      <div
        className="h-2/3 my-5 py-10 w-screen md:w-2/3 flex items-center justify-center"
        style={{
          backgroundImage: `url(${Slogan})`,
          backgroundRepeat: "no-repeat",
          backgroundSize: "cover",
          backgroundPosition: "center",
        }}
      ></div>
      <div className="h-full rounded-lg lg:rounded-none lg:w-1/3 min-w-[400px] bg-white flex justify-center align-middle shadow-2xl">
        <div className="flex-grow max-w-xl h-full px-16 md:px-8 py-24">
          <div className="flex h-full items-center justify-center">
            <div className="w-full">
              <div className="text-2xl text-center mb-6">Sign Up</div>
              <form onSubmit={handleSubmit}>
                <div className="mb-6 flex justify-between gap-5">
                  <div className="flex-grow">
                    <label
                      htmlFor="name"
                      className="block mb-2 text-sm font-medium text-neutral-700"
                    >
                      Name
                    </label>
                    <input
                      type="text"
                      id="name"
                      value={formData!.name}
                      className="bg-neutral-50 border-2 border-neutral-500 text-neutral-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 k:placeholder-neutral-400"
                      onChange={(e) => {
                        setFormData((prev) => ({
                          ...prev!,
                          name: e.target.value,
                        }));
                        setValidation("");
                      }}
                      required
                    ></input>
                  </div>
                  <div className="flex-grow">
                    <label
                      htmlFor="surname"
                      className="block mb-2 text-sm font-medium text-neutral-700"
                    >
                      Surname
                    </label>
                    <input
                      type="text"
                      id="surname"
                      value={formData!.surname}
                      className="bg-neutral-50 border-2 border-neutral-500 text-neutral-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 k:placeholder-neutral-400"
                      onChange={(e) => {
                        setFormData((prev) => ({
                          ...prev!,
                          surname: e.target.value,
                        }));
                        setValidation("");
                      }}
                      required
                    ></input>
                  </div>
                </div>
                <div className="mb-6">
                  <label
                    htmlFor="surname"
                    className="block mb-2 text-sm font-medium text-neutral-700"
                  >
                    Email
                  </label>
                  <input
                    type="email"
                    id="email"
                    value={formData!.email}
                    className="bg-neutral-50 border-2 border-neutral-500 text-neutral-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 k:placeholder-neutral-400"
                    placeholder="name_surname@email.com"
                    onChange={(e) => {
                      setFormData((prev) => ({
                        ...prev!,
                        email: e.target.value,
                      }));
                      setValidation("");
                    }}
                    required
                  ></input>
                </div>
                <div className="mb-6">
                  <label
                    htmlFor="password"
                    className="block mb-2 text-sm font-medium text-neutral-700"
                  >
                    Password
                  </label>
                  <input
                    type="password"
                    id="password"
                    value={formData!.password}
                    className="bg-neutral-50 border-2 border-neutral-500 text-neutral-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 k:placeholder-neutral-400"
                    onChange={(e) => {
                      setFormData((prev) => ({
                        ...prev!,
                        password: e.target.value,
                      }));
                      setValidation("");
                    }}
                    required
                  ></input>
                </div>

                <div className="mb-6 flex items-start justify-between flex-row">
                  <p className="text-red-600">{validation}</p>

                  <Link to="/login" className="hover:cursor-pointer">
                    Log in
                  </Link>
                </div>

                <button
                  type="submit"
                  className="bg-neutral-900 inline-block w-full rounded bg-primary px-7 pb-2.5 pt-3 text-sm font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#566573] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)]"
                  data-te-ripple-init
                  data-te-ripple-color="light"
                >
                  Sign in
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default SignUp;
