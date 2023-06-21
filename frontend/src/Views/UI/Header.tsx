import { useState, useEffect, useContext } from "react";
import { Dialog } from "@headlessui/react";
import { Bars3Icon, XMarkIcon } from "@heroicons/react/24/outline";
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

  const navbarHandle = (id: string) => {
    const section = document.getElementById(id);
    window.scrollTo({
      top: section?.getBoundingClientRect().top! + window.scrollY - 72,
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
        <div className="flex lg:flex-1"></div>
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
          {user && user !== undefined && (
            <>
              <a
                onClick={() => navbarHandle("first")}
                className={`cursor-pointer text-sm font-semibold leading-6 ${
                  navbarTheme === Theme.Light
                    ? "text-neutral-700"
                    : "text-neutral-300"
                }`}
              >
                Home
              </a>
              <a
                onClick={() => navbarHandle("second")}
                className={`cursor-pointer text-sm font-semibold leading-6 ${
                  navbarTheme === Theme.Light
                    ? "text-neutral-700"
                    : "text-neutral-300"
                }`}
              >
                Submission
              </a>
              <a
                onClick={() => navbarHandle("third")}
                className={`cursor-pointer text-sm font-semibold leading-6 ${
                  navbarTheme === Theme.Light
                    ? "text-neutral-700"
                    : "text-neutral-300"
                }`}
              >
                Tracking
              </a>
            </>
          )}
        </div>
        <div className="hidden lg:flex lg:flex-1 lg:justify-end">
          <div className="flex gap-5">
            {user && user !== undefined ? (
              <>
                <p
                  className={`text-sm font-semibold leading-6 ${
                    navbarTheme === Theme.Light
                      ? "text-neutral-700"
                      : "text-neutral-300"
                  }`}
                >
                  Hello, {user.name} {user.surname}
                </p>
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
              </>
            ) : (
              <>
                <Link
                  to={"/signup"}
                  className={`text-sm font-semibold leading-6 ${
                    navbarTheme === Theme.Light
                      ? "text-neutral-700"
                      : "text-neutral-300"
                  }`}
                >
                  Sign up
                </Link>
                <Link
                  to={"/login"}
                  className={`text-sm font-semibold leading-6 ${
                    navbarTheme === Theme.Light
                      ? "text-neutral-700"
                      : "text-neutral-300"
                  }`}
                >
                  Log in
                </Link>
              </>
            )}
          </div>
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
              className={`-m-2.5 rounded-md p-2.5 ${
                navbarTheme === Theme.Light ? "text-black" : "text-white"
              }`}
              onClick={() => setMobileMenuOpen(false)}
            >
              <XMarkIcon className="h-6 w-6" aria-hidden="true" />
            </button>
          </div>
          <div className="mt-6 flow-root">
            <div className="-my-6 divide-y divide-gray-500/10">
              {user && user !== undefined && (
                <div className="py-6">
                  <p
                    className={`-mx-3 text-left w-[calc(100%+1.5rem)] block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                      navbarTheme === Theme.Light ? "text-black" : "text-white"
                    }`}
                  >
                    Hello, {user.name} {user.surname}
                  </p>
                </div>
              )}
              <div className="space-y-2 py-6">
                {user && user !== undefined && (
                  <>
                    <a
                      onClick={() => navbarHandle("first")}
                      className={`cursor-pointer -mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Home
                    </a>
                    <a
                      onClick={() => navbarHandle("second")}
                      className={`cursor-pointer -mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Submission
                    </a>
                    <a
                      onClick={() => navbarHandle("third")}
                      className={`cursor-pointer -mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Tracking
                    </a>
                  </>
                )}
              </div>
              <div className="py-6">
                {user && user !== undefined ? (
                  <>
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
                  </>
                ) : (
                  <>
                    <Link
                      to={"/signup"}
                      className={`cursor-pointer -mx-3 text-left w-[calc(100%+1.5rem)] block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Sign up
                    </Link>
                    <Link
                      to={"/login"}
                      className={`cursor-pointer -mx-3 text-left w-[calc(100%+1.5rem)] block rounded-lg px-3 py-2 text-base font-semibold leading-7 ${
                        navbarTheme === Theme.Light
                          ? "text-black hover:text-white hover:hover:bg-black"
                          : "text-white hover:text-neutral-900 hover:hover:bg-white"
                      }`}
                    >
                      Log in
                    </Link>
                  </>
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
