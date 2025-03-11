import { CircularProgress } from "@mui/material";
import { themeColors } from "@/config/theme/theme";

export default function Loading() {
  return (
    <div className="h-screen w-screen flex items-center justify-center">
      <CircularProgress
        sx={{
          color: themeColors.primary,
        }}
      />
    </div>
  );
}
