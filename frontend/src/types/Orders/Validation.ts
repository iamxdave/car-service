import ValidationType from "./ValidationType";

type Validation =
  | {
      type: ValidationType;
      message: string;
    }
  | undefined;

export default Validation;
