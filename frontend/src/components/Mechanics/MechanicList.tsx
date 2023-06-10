import axios, { AxiosError, AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import Mechanic from "../../types/Mechanic";

import { urlMechanics } from "../../endpoints";
import MechanicItem from "./MechanicItem";
import { useCookies } from "react-cookie";
import { useNavigate } from "react-router-dom";

type Props = {};

const MechanicList = () => {
  const [mechanics, setMechanics] = useState<Mechanic[] | null>();
  const [cookies, setCookies] = useCookies(['jwt']);
  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(urlMechanics, {
        withCredentials: true,
        headers: {
          'Authorization': `Bearer ${cookies.jwt}`
        }
      })
      .then((response: AxiosResponse<any>) => {    
        setMechanics(response.data);
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
          navigate('/unauthorized');
        }
      });
  }, []);

  return (
    <>
      {mechanics
        ? mechanics.map((mechanic) => {
            return (
              <MechanicItem mechanic={mechanic} />
            );
          })
        : null}
    </>
  );
};

export default MechanicList;
