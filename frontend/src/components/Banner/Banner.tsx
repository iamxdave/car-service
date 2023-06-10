import { red } from "@mui/material/colors";
import React, { CSSProperties, useEffect, useRef, useState } from "react";

const Banner = () => {
  useEffect(() => {
    const handleScroll = () => {
      const scrollValue =
        window.pageYOffset / (document.body.offsetHeight - window.innerHeight);
      document.documentElement.style.setProperty(
        "--scroll",
        scrollValue.toString()
      );
    };

    window.addEventListener("scroll", handleScroll);

    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, []);

  const keyframes = `
    @keyframes scroll {
      from {
        transform: translate(0);
      }
      to {
        transform: translate(300px);
      }
    },
`;

  const styles: CSSProperties = {
    animation: "scroll 1s linear forwards",
    animationPlayState: "paused",
    animationIterationCount: "1",
    animationFillMode: "both",
  };

  const stylesFirst: CSSProperties = {
    animationDelay: "calc(var(--scroll) * -1s",
  };

  const stylesSecond: CSSProperties = {
    animationDelay: "calc(var(--scroll) * -2s",
  };

  const stylesNotFilled: CSSProperties = {
    WebkitBackgroundClip: "text",
    backgroundClip: "text",
    WebkitTextStroke: "1px white",
    color: "transparent",
  };

  const stylesFilled: CSSProperties = {
    WebkitMaskImage:
      "linear-gradient(-75deg, rgba(0,0,0,.8) 30%, #000 50%, rgba(0,0,0,.8) 70%)",
    WebkitMaskSize: "200%",
    animation: "shine 2s linear infinite",
  };

  const keyframesFilled = `
    @keyframes shine {
        from { -webkit-mask-position: 150%; }
        to { -webkit-mask-position: -50%; }
    }
  `;

  const generateText = (textContent: string) => {
    const rows = [];

    for (let i = 0; i < 16; i++) {
      rows.push(
        <span
          className={`text-5xl lg:text-6xl font-medium uppercase ${
            i % 4 === 0 ? "text-[#F8B332]" : ""
          }`}
          key={i}
          style={i % 2 === 0 ? stylesFilled : stylesNotFilled}
        >
          <style>{keyframesFilled}</style>
          {textContent}
        </span>
      );
    }
    return rows;
  };

  return (
    <div className="flex-shrink-0 pb-2 overflow-hidden bg-black flex flex-col justify-items-center text-neutral-100">
      <div className="flex w-screen justify-center">
        <div
          className="flex w-screen whitespace-nowrap justify-center transition-transform duration-300"
          style={{...styles, ...stylesFirst}}
        >
          <style>{keyframes}</style>
          {generateText("car-service")}
        </div>
      </div>
      <div className="flex w-screen justify-center pr-[1000px]" style={{...styles, ...stylesSecond}}>
        <style>{keyframes}</style>
        <div className="flex whitespace-nowrap justify-center">
          {generateText("car-service")}
        </div>
      </div>
    </div>
  );
};

export default Banner;
