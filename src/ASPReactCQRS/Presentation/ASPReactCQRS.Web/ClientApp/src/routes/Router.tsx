import { RouteObject, createBrowserRouter } from "react-router-dom";
import { Suspense, lazy } from "react";

import App from "@/App";
import Loading from "@/components/common/Loading";

// Lazy loading for code splitting
const Home = lazy(() => import("@/pages/home/page"));
const Activity = lazy(() => import("@/pages/activity/page"));

const Forbidden = lazy(() => import("@/pages/errors/403"));
const NotFound = lazy(() => import("@/pages/errors/404"));

export const routes: RouteObject[] = [
  {
    path: "/",
    element: (
      <Suspense
        fallback={
          <>
            <Loading />
          </>
        }
      >
        <App />
      </Suspense>
    ),
    children: [
      {
        path: "",
        element: <Home />,
      },
      {
        path: "activity",
        element: <Activity />,
      },
      {
        path: "403",
        element: <Forbidden />,
      },
      {
        path: "*",
        element: <NotFound />,
      },
    ],
  },
];

export const router = createBrowserRouter(routes, {
  basename: import.meta.env.BASE_URL,
});
