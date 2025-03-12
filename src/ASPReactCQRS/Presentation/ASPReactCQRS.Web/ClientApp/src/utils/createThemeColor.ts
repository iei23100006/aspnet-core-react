export default function createThemeColors(primaryColor: string) {
  const colorMap: Record<string, string> = {
    blue: "lightblue",
    navy: "skyblue",
    royalblue: "powderblue",
    steelblue: "aliceblue",

    green: "lightgreen",
    forestgreen: "palegreen",
    teal: "mintcream",
    darkgreen: "honeydew",

    red: "lightcoral",
    firebrick: "salmon",
    crimson: "mistyrose",
    darkred: "lightpink",

    yellow: "lightyellow",
    gold: "lemonchiffon",
    goldenrod: "palegoldenrod",
    orange: "moccasin",

    purple: "thistle",
    indigo: "lavender",
    rebeccapurple: "plum",
    violet: "lavenderblush",

    gray: "lightgray",
    slategray: "gainsboro",
    darkslategray: "whitesmoke",
    dimgray: "ghostwhite",

    brown: "wheat",
    saddlebrown: "bisque",
    chocolate: "antiquewhite",
    sienna: "burlywood",

    pink: "lightpink",
    hotpink: "lightpink",
    deeppink: "mistyrose",
    coral: "lightcoral",

    cyan: "paleturquoise",
    lightcyan: "azure",
    darkcyan: "powderblue",
  };

  return {
    primary: primaryColor,
    secondary: "white",
    text: {
      primary: "black",
      secondary: "gray",
    },
    background: {
      default: "white",
      selected: colorMap[primaryColor] || "lightgray", // Default to light gray if no match
    },
  } as const;
}
