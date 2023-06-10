import { useContext, useEffect, useRef, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useCookies } from "react-cookie";
import { UserContext, UserContextType } from "../../App";
import axios, { AxiosError, AxiosResponse, AxiosResponseHeaders } from "axios";
import { urlLogin, urlUser } from "../../endpoints";
import { Input, Ripple, initTE } from "tw-elements";
import logo from "../../assets/logo.png";

initTE({ Input, Ripple });

interface Credit {
  email: string;
  password: string;
  remember: boolean;
}

export default function LogIn() {
  const [formData, setFormData] = useState<Credit>({
    email: "",
    password: "",
    remember: false,
  });
  const { user, updateUser } = useContext(UserContext) as UserContextType;
  const rememberCheckboxRef = useRef<HTMLInputElement>(null);
  const [validation, setValidation] = useState("");
  const navigate = useNavigate();


  useEffect(() => {
    axios.defaults.withCredentials = true;

    axios
      .get(urlUser)
      .then((response: AxiosResponse) => {
        if (response.status === 200) {
          const user = response.data;
          updateUser(user);
          navigate('/');
        }
      })
      .catch((reason: AxiosError) => {
        return;
      });
  }, []);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const credit: Credit = {
      email: formData.email,
      password: formData.password,
      remember: formData.remember,
    };

    await axios
      .post(urlLogin, credit)
      .then((response: AxiosResponse) => {
        if (response.status === 200) {
          updateUser(credit);
          navigate('/');
        }
      })
      .catch((reason: AxiosError) => {
        const msg = (reason.response!.data as { message: string }).message;
        if (reason.response!.status === 401) {
          setValidation(msg);
        }
      });
  };

  return (
    <section className="h-screen flex flex-col md:flex-row">
      <div
        className="h-screen w-screen md:w-2/3 flex items-center justify-center"
        style={{
          backgroundImage:
            "url(https://images.unsplash.com/photo-1602481222849-c8f6bb1f0f38?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80)",
          backgroundRepeat: "no-repeat",
          backgroundSize: "cover",
          backgroundPosition: "center",
        }}
      >
        <div className="mb-12 md:mb-0 relative inset-0">
          <img
            src={logo}
            className="w-auto h-1/4 max-w-[200px] md:max-w-xs"
            alt="Logo"
          />
        </div>
      </div>
      <div className="md:w-1/3">
        <div className="max-w-lg h-full px-8 py-24">
          <div className="flex h-full items-center justify-center">
            <div className="w-full">
              <div className="text-2xl text-center mb-6">Log In</div>
              <form onSubmit={handleSubmit}>
                <div className="mb-6">
                  <label
                    htmlFor="email"
                    className="block mb-2 text-sm font-medium text-neutral-700"
                  >
                    Email
                  </label>
                  <input
                    type="email"
                    id="email"
                    value={formData.email}
                    className="bg-neutral-50 border-2 border-neutral-500 text-neutral-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 k:placeholder-neutral-400"
                    placeholder="name_surname@email.com"
                    onChange={(e) =>
                      setFormData((prev) => ({
                        ...prev,
                        email: e.target.value,
                      }))
                    }
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
                    value={formData.password}
                    className="bg-neutral-50 border-2 border-neutral-500 text-neutral-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 k:placeholder-neutral-400"
                    onChange={(e) =>
                      setFormData((prev) => ({
                        ...prev,
                        password: e.target.value,
                      }))
                    }
                    required
                  ></input>
                </div>

                <div className="mb-6 flex items-start justify-between flex-row">
                  <div className="mb-[0.125rem] block min-h-[1.5rem] pl-[1.5rem]">
                    <input
                      className="relative float-left -ml-[1.5rem] mr-[6px] mt-[0.15rem] h-[1.125rem] w-[1.125rem] rounded-[0.25rem] border-[0.125rem] border-solid border-neutral-300 outline-none before:pointer-events-none before:absolute before:h-[0.875rem] before:w-[0.875rem] before:scale-0 before:rounded-full before:bg-transparent before:opacity-0 before:shadow-[0px_0px_0px_13px_transparent] before:content-[''] checked:border-primary checked:bg-primary checked:before:opacity-[0.16] checked:after:absolute checked:after:-mt-px checked:after:ml-[0.25rem] checked:after:block checked:after:h-[0.8125rem] checked:after:w-[0.375rem] checked:after:rotate-45 checked:after:border-[0.125rem] checked:after:border-l-0 checked:after:border-t-0 checked:after:border-solid checked:after:border-white checked:after:bg-transparent checked:after:content-[''] hover:cursor-pointer hover:before:opacity-[0.04] hover:before:shadow-[0px_0px_0px_13px_rgba(0,0,0,0.6)] focus:shadow-none focus:transition-[border-color_0.2s] focus:before:scale-100 focus:before:opacity-[0.12] focus:before:shadow-[0px_0px_0px_13px_rgba(0,0,0,0.6)] focus:before:transition-[box-shadow_0.2s,transform_0.2s] focus:after:absolute focus:after:z-[1] focus:after:block focus:after:h-[0.875rem] focus:after:w-[0.875rem] focus:after:rounded-[0.125rem] focus:after:content-[''] checked:focus:before:scale-100 checked:focus:before:shadow-[0px_0px_0px_13px_#3b71ca] checked:focus:before:transition-[box-shadow_0.2s,transform_0.2s] checked:focus:after:-mt-px checked:focus:after:ml-[0.25rem] checked:focus:after:h-[0.8125rem] checked:focus:after:w-[0.375rem] checked:focus:after:rotate-45 checked:focus:after:rounded-none checked:focus:after:border-[0.125rem] checked:focus:after:border-l-0 checked:focus:after:border-t-0 checked:focus:after:border-solid checked:focus:after:border-white checked:focus:after:bg-transparent"
                      type="checkbox"
                      name="remember"
                      defaultChecked
                      onChange={(e) => console.log(e.target.value)}
                    />
                    <label
                      className="inline-block pl-[0.15rem] hover:cursor-pointer"
                      htmlFor="remember"
                    >
                      Remember me
                    </label>
                  </div>

                  <Link
                    to="/singup"
                    className="text-primary transition duration-150 ease-in-out hover:text-primary-600 focus:text-primary-600 active:text-primary-700 dark:text-primary-400 dark:hover:text-primary-500 dark:focus:text-primary-500 dark:active:text-primary-600"
                  >
                    Sign up
                  </Link>
                </div>

                <button
                  type="submit"
                  className="bg-neutral-700 inline-block w-full rounded bg-primary px-7 pb-2.5 pt-3 text-sm font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#566573] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)]"
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
}
