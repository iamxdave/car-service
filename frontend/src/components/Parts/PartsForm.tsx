import axios, { AxiosError, AxiosResponse } from "axios";
import { useContext, useEffect, useRef, useState } from "react";
import Select, { MultiValue } from "react-select";
import { urlParts } from "../../endpoints";
import { UserContext, UserContextType } from "../../App";
import Part from "../../types/Part";

interface PartSelect {
  idPart: number;
  value: string;
  label: string;
}

const PartsForm = () => {
  const { order, updateOrder } = useContext(
    UserContext
  ) as UserContextType;
  const selectRef = useRef(null);
  const [parts, setParts] = useState<PartSelect[]>([]);
  const [selectedParts, setSelectedParts] = useState<PartSelect[]>([]);
  const [automaticParts, setAutomaticParts] = useState<PartSelect[]>([]);

  useEffect(() => {
    axios
      .get(urlParts)
      .then((response: AxiosResponse<any>) => {
        const transformedParts = response.data.map(
          (item: { idPart: number, name: string }): PartSelect => ({
            idPart: item.idPart,
            value: item.name,
            label: item.name
          })
        );

        setParts(transformedParts);
        setAutomaticParts(
          [...transformedParts]
            .sort(() => Math.random() - 0.5)
            .slice(0, Math.floor(Math.random() * transformedParts.length) + 1)
        );
      })
      .catch((reason: AxiosError) => {
        if (reason.response!.status === 401) {
        }
      });
  }, []);

  useEffect(() => {
    if(order === undefined)
      setSelectedParts([]);
  }, [order]);


  const handlePartSelect = (selectedParts : MultiValue<PartSelect>) => {
    setSelectedParts([...selectedParts])
    const parts: Part[] = selectedParts.map((p) => ({
      idPart: p.idPart,
      name: p.label,
    }));
    updateOrder({ ...order!, parts: parts});
  };

  const handleYesClick = () => {
    setSelectedParts(automaticParts);
    const parts: Part[] = automaticParts.map((p) => ({
      idPart: p.idPart,
      name: p.label,
    }));
    updateOrder({ ...order!, parts: parts});
  };

  return (
    <div className="w-full py-4 px-6 md:px-12">
      <div className="flex flex-col lg:flex-row gap-5 mt-6 border-b-4">
        <p className="inline text-4xl font-normal tracking-wide uppercase shrink-0">
          Prefer automatic part selection?
        </p>
        <button
          type="submit"
          className="block w-1/2 lg:w-1/4 h-full border py-3 mb-3 bg-neutral-700 text-sm font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#566573] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)]"
          data-te-ripple-init
          data-te-ripple-color="light"
          onClick={handleYesClick}
        >
          Yes
        </button>
      </div>
      <h3 className="my-6 text-2xl tracking-tight text-justify">
        You have the option to personally select the gear you wish to repair or
        utilize an automatic part selection feature to facilitate the selection
        process for you.
      </h3>
      <div className="py-4 px-3 mb-12">
        <Select
          ref={selectRef}
          isMulti
          className="w-full py-5 text-xl"
          options={parts}
          value={selectedParts}
          onChange={parts => handlePartSelect(parts)}
          required
        />
      </div>
    </div>
  );
};

export default PartsForm;
