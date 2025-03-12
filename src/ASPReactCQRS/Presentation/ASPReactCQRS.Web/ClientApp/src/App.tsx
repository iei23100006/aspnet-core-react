import { StyledEngineProvider } from "@mui/material/styles";
import { useLocation } from "react-router-dom";
import "react-toastify/dist/ReactToastify.css";
import { useStore } from "@/stores/store";
import { ToastContainer } from "react-toastify";
import { useAuth } from "react-oidc-context";
import { useEffect } from "react";
import { observer } from "mobx-react-lite";
import Layout from "./components/layout/Layout";
// import { initializeAxios } from "./config/api/api";
import axios from "axios";

function App() {
  const { userStore } = useStore();
  const location = useLocation();
  const auth = useAuth();
  userStore.setUser(auth.user?.profile);

  useEffect(() => {
    // initializeAxios(auth);
    sessionStorage.setItem("path", location.pathname.slice(1));
  }, [location.pathname]);

  // Axios Interceptor
  axios.interceptors.request.use(
    async (config) => {
      const token = auth.isAuthenticated ? auth.user?.access_token : "";
      if (token && config.headers) {
        config.headers["Authorization"] = "Bearer " + token;
        if (!config.headers["Content-Type"]) {
          config.headers["Content-Type"] = "application/json";
        }
      }
      config.validateStatus = (status) => status < 400;
      return config;
    },
    (error) => {
      Promise.reject(error);
    }
  );

  return (
    <StyledEngineProvider injectFirst>
      <Layout />
      <ToastContainer
        position="top-center"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="colored"
        style={{ width: "400px" }}
      />
    </StyledEngineProvider>
  );
}

export default observer(App);
