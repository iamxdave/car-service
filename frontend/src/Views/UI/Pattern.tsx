import { CSSProperties } from "react";
import pattern from "../../assets/pattern.jpg";

const Pattern = () => {
  const inlineStyles: CSSProperties = {
    background: `url(${pattern})`,
    backgroundSize: "cover",
    animation: "infinite 35s linear infinite",
  };

  const keyframes = `
        @keyframes infinite {
          0%{
            background-position: 50% 0;
          }
          100%{
            background-position: 50% -1000px;
          }
        }
      `;
  return (
    <div className="h-1/2 bg-neutral-900" style={inlineStyles}>
      <style>{keyframes}</style>
    </div>
  );
};

export default Pattern;
