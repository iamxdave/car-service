import { ReactNode } from "react";

interface ContainerProps {
  id: string;
  height: string;
  bgColor: string;
  children: ReactNode;
}

const Container = ({ id, height, bgColor, children }: ContainerProps) => {
  const classes = `${height} ${bgColor}`;

  return (
    <div id={id} className={`flex flex-col ${classes}`}>
      {children}
    </div>
  );
};

export default Container;
