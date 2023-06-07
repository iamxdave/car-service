import React, { ReactNode, CSSProperties } from "react";
import pattern from "../../assets/pattern.jpg";

interface ContainerProps {
  children: ReactNode;
}

const Container = ({ children }: ContainerProps) => {
  return (
    <div className="bg-neutral-900">
      {children}
    </div>
  );
};

export default Container;
