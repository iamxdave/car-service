import axios, { AxiosError, AxiosResponse } from "axios";
import { useContext, useEffect, useState } from "react";
import { urlOrders } from "../../../endpoints";
import {
  OrderContext,
  OrderContextType,
  UserContext,
  UserContextType,
} from "../../../App";
import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";
import OrderStatus from "../../../types/Orders/OrderStatus";
import Avatar from "../../../assets/avatar.png";
import { format } from "date-fns";

const OrderResults = () => {
  const { user } = useContext(UserContext) as UserContextType;
  const { orderResults, updateOrderResults } = useContext(
    OrderContext
  ) as OrderContextType;

  const urlRepairs = `${urlOrders}/repair/${user?.idPerson}`;
  const urlBuyouts = `${urlOrders}/buyout/${user?.idPerson}`;

  const [cookies] = useCookies(["jwt"]);
  const navigate = useNavigate();

  const ITEMS_PER_PAGE = 10;

  const [currentPage, setCurrentPage] = useState(1);

  const indexOfLastItem = currentPage * ITEMS_PER_PAGE;
  const indexOfFirstItem = indexOfLastItem - ITEMS_PER_PAGE;
  const currentItems = orderResults.slice(indexOfFirstItem, indexOfLastItem);

  const totalPages = Math.ceil(orderResults.length / ITEMS_PER_PAGE);

  useEffect(() => {
    axios
      .get(urlRepairs, {
        withCredentials: true,
        headers: {
          Authorization: `Bearer ${cookies.jwt}`,
        },
      })
      .then((response: AxiosResponse<any>) => {
        const results =
          response.data && response.data.map((item: any) => item.result);
        updateOrderResults([...results]);
      })
      .catch((reason: AxiosError) => {
        console.log(reason);
        if (reason.response!.status === 401) {
          navigate("/unauthorized");
        }
      });

    axios
      .get(urlBuyouts, {
        withCredentials: true,
        headers: {
          Authorization: `Bearer ${cookies.jwt}`,
        },
      })
      .then((response: AxiosResponse<any>) => {
        console.log(response.data);
        const results =
          response.data && response.data.map((item: any) => item.result);
        updateOrderResults([...results]);
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
          navigate("/unauthorized");
        }
        if (reason.response!.status === 500) {
          navigate("/internalserver");
        }
      });
  }, []);

  const setStatus = (status: number | undefined): string => {
    if (status === undefined) {
      return "";
    }

    switch (status) {
      case 0:
        return OrderStatus.Accepted;
      case 1:
        return OrderStatus.InProgress;
      case 2:
        return OrderStatus.Completed;
      case 3:
        return OrderStatus.Cancelled;
      default:
        return "";
    }
  };

  const handlePageChange = (pageNumber: number) => {
    setCurrentPage(pageNumber);
  };

  return (
    <>
      <div className="mt-4">
        {orderResults.length === 0 ? (
          <h3 className="mb-4 text-2xl tracking-tight text-justify">
            Currently, there are no existing orders. You have the option to
            create a new order by following the process below.
          </h3>
        ) : (
          <div className="w-full overflow-hidden rounded-lg shadow-xs">
            <div className="w-full overflow-x-auto">
              <table className="w-full">
                <thead>
                  <tr className="text-xs font-semibold tracking-wide text-left text-neutral-500 uppercase border-b bg-neutral-50">
                    <th className="px-4 py-3">Id</th>
                    <th className="px-4 py-3">Mechanic</th>
                    <th className="px-4 py-3">Car</th>
                    <th className="px-4 py-3">Amount</th>
                    <th className="px-4 py-3">Status</th>
                    <th className="px-4 py-3">Start</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y">
                  {currentItems.map((d) => (
                    <tr
                      className="bg-neutral-50 hover:bg-neutral-100 text-neutral-700"
                      key={d?.idOrder}
                    >
                      <td className="px-4 py-3 text-sm">{d?.idOrder}</td>
                      <td className="px-4 py-3">
                        <div className="flex items-center text-sm">
                          <div className="relative hidden w-10 h-10 mr-3 rounded-full xl:block">
                            <img
                              className="object-cover h-full w-full rounded-full bg-white p-1 border-2 border-neutral-200"
                              src={Avatar}
                              alt="avatar"
                            />
                          </div>
                          <div className="xl:ml-1">
                            <p className="font-semibold">
                              {d?.mechanic.name} {d?.mechanic.surname}
                            </p>
                            <p className="text-xs text-neutral-600">Mechanic</p>
                          </div>
                        </div>
                      </td>
                      <td className="px-4 py-3">
                        <div className="flex items-center text-sm">
                          <div className="mr-3">
                            <p className="font-semibold">
                              {d?.car.brand} {d?.car.model}
                            </p>
                            {d?.warranty && (
                              <p className="text-xs text-neutral-600">
                                Warranty: {d?.warranty}
                              </p>
                            )}
                            {d?.parts && (
                              <p className="text-xs text-neutral-600">
                                <div>Repairing parts:</div>
                                <div className="mt-1">
                                  {d?.parts?.map((p) => (
                                    <>{p.name}, </>
                                  ))}
                                </div>
                              </p>
                            )}
                          </div>
                        </div>
                      </td>
                      <td className="px-4 py-3 text-sm">${d?.cost}</td>
                      <td className="px-4 py-3 text-xs">
                        <span className="px-2 py-1 font-semibold leading-tight text-green-700 bg-green-100 rounded-full">
                          {" "}
                          {setStatus(d?.status)}{" "}
                        </span>
                      </td>
                      <td className="px-4 py-3 text-sm">
                        {d?.dateStarted
                          ? format(new Date(d.dateStarted), "dd/MM/yyyy")
                          : ""}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            <div className="grid px-4 py-3 text-xs font-semibold tracking-wide text-neutral-500 uppercase border-t sm:grid-cols-9">
              <span className="flex items-center col-span-3">
                {" "}
                Showing {indexOfFirstItem + 1}-{indexOfLastItem} of{" "}
                {orderResults.length}{" "}
              </span>
              <span className="col-span-2"></span>
              <span className="flex col-span-4 mt-2 sm:mt-auto sm:justify-end">
                <nav aria-label="Table navigation">
                  <ul className="inline-flex items-center">
                    <li>
                      <button
                        className="px-3 py-1 rounded-md rounded-l-lg focus:outline-none focus:shadow-outline-purple"
                        aria-label="Previous"
                        onClick={() => handlePageChange(currentPage - 1)}
                        disabled={currentPage === 1}
                      >
                        <svg
                          aria-hidden="true"
                          className="w-4 h-4 fill-current"
                          viewBox="0 0 20 20"
                        >
                          <path
                            d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z"
                            clipRule="evenodd"
                            fillRule="evenodd"
                          ></path>
                        </svg>
                      </button>
                    </li>
                    {Array.from({ length: totalPages }, (_, index) => (
                      <li key={index}>
                        <button
                          className={`px-3 py-1 rounded-md focus:outline-none focus:shadow-outline-purple ${
                            currentPage === index + 1
                              ? "bg-yellow-600 text-white"
                              : ""
                          }`}
                          onClick={() => handlePageChange(index + 1)}
                        >
                          {index + 1}
                        </button>
                      </li>
                    ))}
                    <li>
                      <button
                        className="px-3 py-1 rounded-md rounded-r-lg focus:outline-none focus:shadow-outline-purple"
                        aria-label="Next"
                        onClick={() => handlePageChange(currentPage + 1)}
                        disabled={currentPage === totalPages}
                      >
                        <svg
                          className="w-4 h-4 fill-current"
                          aria-hidden="true"
                          viewBox="0 0 20 20"
                        >
                          <path
                            d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z"
                            clipRule="evenodd"
                            fillRule="evenodd"
                          ></path>
                        </svg>
                      </button>
                    </li>
                  </ul>
                </nav>
              </span>
            </div>
          </div>
        )}
      </div>
      {/* {orderResults.length !== 0 &&
            orderResults.map((d) => {
              return (
                <div className="my-12" key={d?.idOrder}>
                  <h5 className="mb-4 text-2xl tracking-tight">
                    {d?.idOrder} {d?.cost}
                  </h5>
                  <h5 className="mb-4 text-2xl tracking-tight">
                    {d?.dateStarted?.toLocaleDateString()} {d?.mechanic?.name}{" "}
                    {d?.mechanic?.surname}
                  </h5>
                  <h5 className="mb-4 text-2xl tracking-tight">
                    {d?.car?.brand} {d?.car?.model}
                    {d?.warranty}{" "}
                    {d?.car?.registrationNumber}{" "}
                    {d?.parts?.map((p) => (
                      <div>{p.name}</div>
                    ))}
                  </h5>
                  <h5 className="mb-4 text-2xl tracking-tight">{setStatus(d?.status)}</h5>
                </div>
              );
            })} */}
    </>
  );
};

export default OrderResults;
