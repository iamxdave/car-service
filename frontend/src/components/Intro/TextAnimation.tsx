import { CSSProperties } from "react";
import pattern from "../../assets/pattern_cars.png";

const TextAnimation = ({ text }: { text: string }) => {
  const styles: CSSProperties = {
    background: `url(${pattern})`,
    backgroundSize: "50%",
    backgroundRepeat: "repeat",
    WebkitBackgroundClip: "text",
    backgroundClip: "text",
    WebkitTextStroke: "2px white",
    color: "transparent",
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
    <span
      className="text-6xl md:text-7xl xl:text-8xl text-[hsl(218,81%,75%)]"
      style={styles}
    >
      <style>{keyframes}</style>
      {text}
    </span>
  );
};

export default TextAnimation;
