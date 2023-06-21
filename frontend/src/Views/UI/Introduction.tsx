const Introduction = ({ title, text }: { title: string; text: string }) => {
  return (
    <section className="mb-16 border-l-8 border-l-yellow-400">
      <div className="py-4 px-6 mt-12 md:px-12">
        <h2 className="mb-4 md:mb-6 text-4xl md:text-5xl font-bold tracking-tight">
          {title}
        </h2>
        <h3 className="mb-4 text-lg sm:text-xl md:text-2xl tracking-tight text-justify whitespace-break-spaces">
          {text}
        </h3>
      </div>
    </section>
  );
};

export default Introduction;
