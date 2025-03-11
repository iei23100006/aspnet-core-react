import { toast } from "react-toastify";

const showToast = (type: "success" | "error" | "warning", message: string) => {
  toast[type](message, {
    position: "top-center",
    autoClose: 5000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
    theme: "colored",
  });
};

export default showToast;
