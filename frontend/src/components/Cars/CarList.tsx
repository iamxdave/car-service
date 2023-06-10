import axios, { AxiosError, AxiosResponse } from 'axios';
import { useEffect, useState } from 'react'
import { useCookies } from 'react-cookie';
import { useNavigate } from 'react-router-dom';
import { urlCars } from '../../endpoints';
import Car from '../../types/Car';
import CarItem from './CarItem';

const CarList = () => {
    const [cars, setCars] = useState<Car[] | null>();
    const [cookies, setCookies] = useCookies(['jwt']);
    const navigate = useNavigate();
  
    useEffect(() => {
      axios
        .get(urlCars, {
          withCredentials: true,
          headers: {
            'Authorization': `Bearer ${cookies.jwt}`
          }
        })
        .then((response: AxiosResponse<any>) => {
          setCars(response.data);
        })
        .catch((reason: AxiosError) => {
          if (reason.response!.status === 401) {
            navigate('/unauthorized');
          }
        });
    }, []);
  
    return (
      <>
        {cars
          ? cars.map((car) => {
              return (
                <CarItem car={car} />
              );
            })
          : null}
      </>
    );
}

export default CarList