import * as React from "react";
import { useNavigate, useLocation, Outlet } from "react-router-dom";
import HomeIcon from "@mui/icons-material/Home";
import BarChartIcon from "@mui/icons-material/BarChart";
import { AppProvider, Navigation, Session } from "@toolpad/core/AppProvider";
import { DashboardLayout } from "@toolpad/core/DashboardLayout";
import { observer } from "mobx-react-lite";
import { useStore } from "@/stores/store";
import { useAuth } from "react-oidc-context";
import theme from "@/config/theme/theme";

const NAVIGATION: Navigation = [
  {
    kind: "header",
    title: "Main items",
  },
  {
    segment: "",
    title: "Home",
    icon: <HomeIcon />,
  },
  {
    segment: "activity",
    title: "Activity",
    icon: <BarChartIcon />,
    children: [
      {
        segment: "",
        title: "Activity",
        icon: <BarChartIcon />,
      },
    ],
  },
];

function Layout(props: any) {
  const { window } = props;
  const navigate = useNavigate();
  const location = useLocation();
  const { userStore } = useStore();
  const auth = useAuth();

  // Create a router object that uses React Router's navigate
  const router = React.useMemo(() => {
    return {
      pathname: location.pathname,
      searchParams: new URLSearchParams(location.search),
      navigate: (path: string | URL) => navigate(String(path)),
    };
  }, [location, navigate]);

  const [session] = React.useState<Session | null>({
    user: {
      name: userStore.user?.name,
      email: userStore.user?.company,
    },
  });

  const authentication = React.useMemo(() => {
    return {
      signIn: () => {
        auth.signinRedirect();
      },
      signOut: () => {
        auth.signoutSilent();
      },
    };
  }, []);

  return (
    <AppProvider
      session={auth.isAuthenticated ? session : null}
      authentication={authentication}
      navigation={NAVIGATION}
      router={router}
      theme={theme}
      window={window}
      branding={{
        title: "AspReactCQRS",
        logo: "", // put your logo in this
      }}
    >
      <DashboardLayout>
        <div className="p-3">
          <Outlet />
        </div>
      </DashboardLayout>
    </AppProvider>
  );
}

export default observer(Layout);
