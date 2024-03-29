import { Link } from "react-router-dom";

const Unauthorized = () => {
  return (
    <main className="grid h-screen place-items-center bg-neutral-800 px-6 py-24 sm:py-32 lg:px-8">
      <div className="text-center">
        <p className="text-base font-semibold text-neutral-100">401</p>
        <h1 className="mt-4 text-3xl font-bold tracking-tight text-neutral-200 sm:text-5xl">
          Access denied
        </h1>
        <p className="mt-6 text-base leading-7 text-neutral-400">
          Sorry, you need to login to view this content.
        </p>
        <div className="mt-10 flex items-center justify-center gap-x-6">
          <Link
            to="/"
            className="rounded-md bg-neutral-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-neutral-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            Go back home
          </Link>
        </div>
      </div>
    </main>
  );
};

export default Unauthorized;
