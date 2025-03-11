import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "@/assets/styles/global.css";
import { AuthProvider, AuthProviderProps } from "react-oidc-context";
import { User } from "oidc-client-ts";
import { StoreContext, store } from "@/stores/store.ts";
import { RouterProvider } from "react-router-dom";
import { router } from "@/routes/Router";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import axios from "axios";

const queryClient = new QueryClient();
const loco = window.location;
const url = `${loco.protocol}//${loco.host}${import.meta.env.BASE_URL}${
  sessionStorage.getItem("path") ?? ""
}`;
axios.defaults.baseURL = import.meta.env.BASE_URL;
axios.get<AuthProviderProps>(`/auth-settings.json`).then((res) => {
  let oidcConfig: AuthProviderProps = res.data;
  oidcConfig.redirect_uri = url;

  oidcConfig.onSigninCallback = (user: User | void): void => {
    axios.get(`/api/user`, {
      headers: { Authorization: `Bearer ${(user as User).access_token}` },
    });

    window.location.href = url;
  };
  createRoot(document.getElementById("root")!).render(
    <StrictMode>
      <AuthProvider {...oidcConfig}>
        <StoreContext.Provider value={store}>
          <QueryClientProvider client={queryClient}>
            <RouterProvider router={router} />
          </QueryClientProvider>
        </StoreContext.Provider>
      </AuthProvider>
    </StrictMode>
  );
});
