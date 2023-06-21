import axios, { AxiosError, AxiosResponse } from "axios";
import { useContext, useEffect, useRef, useState } from "react";
import Select, { MultiValue } from "react-select";
import { urlParts } from "../../endpoints";
import { OrderContext, OrderContextType } from "../../App";
import ValidationType from "../../types/Orders/ValidationType";
import { useNavigate } from "react-router-dom";
import Title from "../../Views/UI/Title";

interface PartSelect {
  idPart: number;
  value: string;
  label: string;
}

const PartsForm = () => {
  const { order, validations, updateOrder, updateValidations } = useContext(
    OrderContext
  ) as OrderContextType;
  const selectRef = useRef(null);
  const [parts, setParts] = useState<PartSelect[]>([]);
  const [selectedParts, setSelectedParts] = useState<PartSelect[]>([]);
  const [automaticParts, setAutomaticParts] = useState<PartSelect[]>([]);

  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(urlParts)
      .then((response: AxiosResponse<any>) => {
        const transformedParts = response.data.map(
          (item: { idPart: number; name: string }): PartSelect => ({
            idPart: item.idPart,
            value: item.name,
            label: item.name,
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
        if (reason.response!.status === 500) {
          navigate("/internalserver");
        }
      });
  }, []);

  useEffect(() => {
    if (order === undefined) setSelectedParts([]);
  }, [order]);

  const handlePartSelect = (selectedParts: MultiValue<PartSelect>) => {
    setSelectedParts([...selectedParts]);
    const parts: number[] = selectedParts.map((p) => p.idPart);
    updateOrder({ ...order!, idParts: parts });
    updateValidations({ type: ValidationType.Part, message: "" });
  };

  const handleYesClick = () => {
    setSelectedParts(automaticParts);
    const parts: number[] = automaticParts.map((p) => p.idPart);
    updateOrder({ ...order!, idParts: parts });
    updateValidations({ type: ValidationType.Part, message: "" });
  };

  return (
    <div className="w-full py-4 px-6 md:px-12">
      <div className="flex flex-col lg:flex-row gap-3 md:gap-5 lg:items-center">
        <Title text="Prefer automatic part selection?"></Title>
        <button
          type="submit"
          className="block w-1/2 lg:w-1/4 max-w-[200px] h-full border py-3 bg-neutral-700 text-sm font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#566573] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(86,101,115,0.3),0_4px_18px_0_rgba(86,101,115,0.2)]"
          data-te-ripple-init
          data-te-ripple-color="light"
          onClick={handleYesClick}
        >
          Yes
        </button>
      </div>
      <h3 className="my-6 text-xl md:text-2xl tracking-tight text-justify">
        You have the option to personally select the gear you wish to repair or
        utilize an automatic part selection feature to facilitate the selection
        process for you.
      </h3>
      <Select
        ref={selectRef}
        isMulti
        className="w-full py-5 text-xl"
        options={parts}
        value={selectedParts}
        onChange={(parts) => handlePartSelect(parts)}
        required
      />
      <div className="mb-12">
        {validations?.some((v) => v?.type === ValidationType.Part) ? (
          <p className="h-10 p-1 text-lg italic text-red-600">
            {validations.find((v) => v?.type === ValidationType.Part)?.message}
          </p>
        ) : (
          <div className="h-10"></div>
        )}
      </div>
    </div>
  );
};

export default PartsForm;
