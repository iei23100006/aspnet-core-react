import axios, { AxiosError, AxiosResponse } from "axios";
import { ActivityAPI } from "./activityAPI";
import showToast from "@/utils/showToast";
import { router } from "@/routes/Router";

axios.defaults.baseURL = import.meta.env.BASE_URL;
axios.defaults.transformResponse = function (data) {
  // Do whatever you want to transform the data
  const reISO =
    /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*)?)(?:Z|(\+|-)([\d|:]*))?$/;
  if (data !== null && data !== undefined && data !== "") {
    try {
      const json = JSON.parse(data, function (_, value) {
        if (typeof value === "string") {
          const a = reISO.exec(value);
          if (a) {
            // Convert to a Date object
            const date = new Date(value);

            // Manually construct the desired format
            const days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
            const day = days[date.getDay()];

            const month = date.toLocaleString("en-US", { month: "short" });
            const numericDay = date.toLocaleString("en-US", { day: "numeric" });
            const year = date.toLocaleString("en-US", { year: "numeric" });

            const time = date.toLocaleString("en-US", {
              hour: "numeric",
              minute: "numeric",
              second: "numeric",
              hour12: true,
            });

            return `${day}, ${month} ${numericDay} ${year} ${time}`;
          }
        }
        return value;
      });

      return json;
    } catch {
      return data;
    }
  }
  return data;
};

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

axios.interceptors.response.use(
  async (response) => {
    return response;
  },
  async (error: AxiosError) => {
    const { status, data } = error.response as AxiosResponse;

    switch (status) {
      case 400:
        showToast("error", data);
        break;
      case 401:
        showToast("error", "Unauthorized.");
        break;
      case 403:
        showToast("error", "Forbidden.");
        router.navigate("/403");
        break;
      case 500:
        showToast("error", "Internal Server Error.");
        console.log(`Axios Error: ${data}`);
        break;
      default:
        showToast(
          "error",
          "Unexpected Error: Please check log to see the details."
        );
        console.log(`Axios Error: ${data}`);
        break;
    }
    return Promise.reject(error);
  }
);

export const requests = {
  get: <T>(url: string, additional?: {}) =>
    axios.get<T>(url, additional).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  patch: <T>(url: string, body: {}) =>
    axios.patch<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
  res: <T>(url: string) => axios.put<T>(url).then(responseBody),
};

const agent = {
  ActivityAPI,
};

export default agent;
