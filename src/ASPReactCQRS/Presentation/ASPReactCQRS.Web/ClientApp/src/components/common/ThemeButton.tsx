import React from "react";
import { Button, ButtonProps } from "@mui/material";
import { themeColors } from "@/config/theme/theme";

interface ThemeButtonProps extends ButtonProps {
  children: React.ReactNode;
}

function ThemeButton({ children, className, ...props }: ThemeButtonProps) {
  return (
    <Button
      {...props}
      className={className}
      style={{
        opacity: 0.9,
        backgroundColor: themeColors.primary,
        color: themeColors.secondary,
      }}
      sx={{
        "&:hover": {
          opacity: `1 !important`,
          backgroundColor: `${themeColors.primary} !important`,
        },
      }}
    >
      {children}
    </Button>
  );
}

export default ThemeButton;
