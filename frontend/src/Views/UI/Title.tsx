const Title = ({ text }: { text: string }) => {
  return (
    <div className="py-4 border-b-4 shrink-0">
      <p className="text-3xl md:text-4xl font-normal tracking-wide uppercase">
        {text}
      </p>
    </div>
  );
};

export default Title;
