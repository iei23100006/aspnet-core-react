import createThemeColors from "@/utils/createThemeColor";
import { extendTheme } from "@mui/material/styles";
import type { CssVarsThemeOptions } from "@mui/material/styles";

export const themeColors = createThemeColors("navy"); // Change the color

const theme = extendTheme({
  colorSchemeSelector: "data",
  breakpoints: {
    values: {
      xs: 0,
      sm: 600,
      md: 600,
      lg: 1200,
      xl: 1536,
    },
  },
  components: {
    MuiAppBar: {
      styleOverrides: {
        root: {
          backgroundColor: themeColors.primary,
        },
      },
    },
    MuiDrawer: {
      styleOverrides: {
        paper: {
          backgroundColor: themeColors.background.default,
        },
      },
    },
    MuiSwitch: {
      styleOverrides: {
        switchBase: {
          color: themeColors.text.secondary,
          "&.Mui-checked": {
            color: themeColors.primary,
          },
          "&.Mui-disabled": {
            color: themeColors.background.default,
          },
        },
        track: {
          opacity: 0.3,
          ".Mui-checked.Mui-checked + &": {
            opacity: 0.5,
            backgroundColor: themeColors.primary,
          },
        },
      },
    },
    MuiButton: {
      styleOverrides: {
        root: {
          backgroundColor: themeColors.secondary,
          border: `1px solid ${themeColors.primary}`,
          color: themeColors.text.primary,
          "&:hover": {
            backgroundColor: themeColors.secondary,
          },
        },
      },
    },
    MuiListItemButton: {
      styleOverrides: {
        root: {
          "&.Mui-selected": {
            backgroundColor: themeColors.background.selected,
            "&:hover": {
              backgroundColor: themeColors.background.selected,
            },
            "& .MuiListItemIcon-root": {
              color: `${themeColors.primary} !important`,
              "& .MuiSvgIcon-root": {
                color: `${themeColors.primary} !important`,
              },
            },
            "& .MuiTypography-root": {
              color: `${themeColors.primary} !important`,
              fontWeight: 500,
            },
          },
        },
      },
    },
    MuiListItemIcon: {
      styleOverrides: {
        root: {
          color: themeColors.text.secondary,
          minWidth: "40px",
        },
      },
    },
    MuiAvatar: {
      styleOverrides: {
        root: {
          backgroundColor: themeColors.secondary,
          color: themeColors.primary,
          border: `2px solid ${themeColors.primary}`,
        },
      },
    },
    MuiTypography: {
      styleOverrides: {
        h6: {
          color: `${themeColors.secondary} !important`,
        },
      },
    },
  },
} as CssVarsThemeOptions);

export default theme;
