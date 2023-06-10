import { Fragment, useState, useEffect, useContext } from "react";
import { Dialog, Disclosure, Popover, Transition } from "@headlessui/react";
import { Bars3Icon, XMarkIcon } from "@heroicons/react/24/outline";
import logo from "../../assets/logo.png";
import { Link, useNavigate } from "react-router-dom";
import { UserContext, UserContextType } from "../../App";
import axios, { AxiosError, AxiosResponse } from "axios";
import { urlLogout } from "../../endpoints";
import { useCookies } from "react-cookie";

enum Theme {
  Normal,
  Dark,
  Light,
}

const Header = () => {
  const { user, updateUser } = useContext(UserContext) as UserContextType;
  const [cookies, setCookies] = useCookies(["jwt"]);
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);
  const [navbarTheme, setNavbarTheme] = useState<Theme>(Theme.Normal);
  const [headerClassName, setHeaderClassName] = useState("");
  const navigate = useNavigate();

  const handleLogout = () => {
    axios
      .post(urlLogout, {
        withCredentials: true,
        headers: {
          Authorization: `Bearer ${cookies.jwt}`,
        },
      })
      .then((response: AxiosResponse<any>) => {
        updateUser(undefined);
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
          navigate("/unauthorized");
        }
      });
  };

  useEffect(() => {
    const handleScroll = () => {
      const darkNavbarHeight = 10;
      const lightNavbarHeight = window.innerHeight;
      const scrollPosition = window.scrollY;

      if (scrollPosition > lightNavbarHeight) {
        setNavbarTheme(Theme.Light);
      } else if (scrollPosition > darkNavbarHeight) {
        setNavbarTheme(Theme.Dark);
      } else {
        setNavbarTheme(Theme.Normal);
      }

      setHeaderClassName((prev) => {
        switch (navbarTheme) {
          case Theme.Normal:
            return "";
          case Theme.Dark:
            return "bg-[#101010] shadow-lg";
          case Theme.Light:
            return "bg-white shadow-lg";
          default:
            return "";
        }
      });
    };
    window.addEventListener("scroll", handleScroll);
    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, [navbarTheme, headerClassName]);

  return (
    <header
      className={`sticky top-0 z-50 transition-all duration-300 ease-in-out bg-neutral-900 ${headerClassName}`}
    >
      <nav
        className="mx-auto flex max-w-7xl items-center justify-between p-6 lg:px-8"
        aria-label="Global"
      >
        <div className="flex lg:flex-1">
          <a href="#" className="-m-1.5 p-1.5">
            <img className="h-8 w-auto" src={logo} alt="" />
          </a>
        </div>
        <div className="flex lg:hidden">
          <button
            type="button"
            className={`-m-2.5 inline-flex items-center justify-center rounded-md p-2.5 ${
              navbarTheme === Theme.Light
                ? "text-neutral-900"
                : "text-neutral-100"
            }`}
            onClick={() => setMobileMenuOpen(true)}
          >
            <Bars3Icon className="h-6 w-6" aria-hidden="true" />
          </button>
        </div>
        <div className="hidden lg:flex lg:gap-x-12">
          <a
            onClick={() => {
              const section = document.getElementById("second");
              window.scrollTo({ top: section?.getBoundingClientRect().top! + window.scrollY - 80});
            }}
            className={`cursor-pointer text-sm font-semibold leading-6 ${
              navbarTheme === Theme.Light
                ? "text-neutral-700"
                : "text-neutral-300"
            }`}
          >
            Cars
          </a>
          <a
            href="#"
            className={`text-sm font-semibold leading-6 ${
              navbarTheme === Theme.Light
                ? "text-neutral-700"
                : "text-neutral-300"
            }`}
          >
            Features
          </a>
          <a
            href="#"
            className={`text-sm font-semibold leading-6 ${
              navbarTheme === Theme.Light
                ? "text-neutral-700"
                : "text-neutral-300"
            }`}
          >
            Marketplace
          </a>
          <a
            href="#"
            className={`text-sm font-semibold leading-6 ${
              navbarTheme === Theme.Light
                ? "text-neutral-700"
                : "text-neutral-300"
            }`}
          >
            Company
          </a>
        </div>
        <div className="hidden lg:flex lg:flex-1 lg:justify-end">
          {user ? (
            <button
              onClick={handleLogout}
              className={`text-sm font-semibold leading-6 ${
                navbarTheme === Theme.Light
                  ? "text-neutral-700"
                  : "text-neutral-300"
              }`}
            >
              Log out
            </button>
          ) : (
            <Link
              to={"/login"}
              className={`text-sm font-semibold leading-6 ${
                navbarTheme === Theme.Light
                  ? "text-neutral-700"
                  : "text-neutral-300"
              }`}
            >
              Log in <span aria-hidden="true">&rarr;</span>
            </Link>
          )}
        </div>
      </nav>
      <Dialog
        as="div"
        className="lg:hidden"
        open={mobileMenuOpen}
        onClose={setMobileMenuOpen}
      >
        <div className="fixed inset-0" />
        <Dialog.Panel
          className={`fixed inset-y-0 right-0 z-50 w-full ${
            navbarTheme === Theme.Light ? "bg-white" : "bg-black"
          } bg-opacity-95 overflow-y-auto px-6 py-6 sm:max-w-xs sm:ring-1 sm:ring-gray-900/10`}
        >
          <div className="flex items-center justify-between">
            <button
              type="button"
              className="-m-2.5 rounded-md p-2.5 text-white"
              onClick={() => setMobileMenuOpen(false)}
            >
              <span className="sr-only">Close menu</span>
              <XMarkIcon className="h-6 w-6" aria-hidden="true" />
            </button>
          </div>
          <div className="mt-6 flow-root">
            <div className="-my-6 divide-y divide-gray-500/10">
              <div className="space-y-2 py-6">
                <a
                  className={`-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                    navbarTheme === Theme.Light
                      ? "text-black hover:text-white hover:hover:bg-black"
                      : "text-white hover:text-neutral-900 hover:hover:bg-white"
                  }`}
                >
                  Cars
                </a>
                {user && (
                  <>
                    <a
                      href="#"
                      className={`-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Features
                    </a>
                    <a
                      href="#"
                      className={`-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Marketplace
                    </a>
                    <a
                      href="#"
                      className={`-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Company
                    </a>
                  </>
                )}
              </div>
              <div className="py-6">
                {user ? (
                  <button
                    onClick={handleLogout}
                    className={`-mx-3 text-left w-[calc(100%+1.5rem)] block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                      navbarTheme === Theme.Light
                        ? "text-black hover:text-white hover:hover:bg-black"
                        : "text-white hover:text-neutral-900 hover:hover:bg-white"
                    }`}
                  >
                    Log out
                  </button>
                ) : (
                  <Link
                    to={"/login"}
                    className={`-mx-3 text-left w-[calc(100%+1.5rem)] block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                      navbarTheme === Theme.Light
                        ? "text-black hover:text-white hover:hover:bg-black"
                        : "text-white hover:text-neutral-900 hover:hover:bg-white"
                    }`}
                  >
                    Log in <span aria-hidden="true">&rarr;</span>
                  </Link>
                )}
              </div>
            </div>
          </div>
        </Dialog.Panel>
      </Dialog>
    </header>
  );
};

export default Header;
