import { themeColors } from "@/config/theme/theme";
import { NavLink } from "react-router-dom";

function Forbidden() {
  return (
    <main className="h-screen w-full flex flex-col justify-center items-center">
      <div className="relative flex flex-col items-center">
        <h1 className="text-9xl font-extrabold text-secondary-color tracking-widest">
          403
        </h1>
        <div
          style={{
            backgroundColor: themeColors.primary,
            color: themeColors.secondary,
          }}
          className="px-2 text-sm rounded rotate-12 absolute top-16"
        >
          Forbidden Page
        </div>
      </div>
      <button className="mt-5">
        <a
          style={{
            color: themeColors.secondary,
          }}
          className="relative inline-block text-sm font-medium group focus:outline-none focus:ring"
        >
          <span
            style={{
              backgroundColor: themeColors.primary,
            }}
            className="absolute inset-0 transition-transform translate-x-0.5 translate-y-0.5 group-hover:translate-y-0 group-hover:translate-x-0"
          ></span>
          <NavLink to={"/"}>
            <span
              style={{
                color: themeColors.secondary,
                borderColor: themeColors.text.primary,
              }}
              className="relative block px-8 py-3 border border-current"
            >
              Go Home
            </span>
          </NavLink>
        </a>
      </button>
    </main>
  );
}

export default Forbidden;
