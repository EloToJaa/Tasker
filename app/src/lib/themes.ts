// dark: {
//   "color-scheme": "dark",
//   "primary": "#7582ff",
//   "secondary": "#ff71cf",
//   "accent": "#00c7b5",
//   "neutral": "#2a323c",
//   "neutral-content": "#A6ADBB",
//   "base-100": "#1d232a",
//   "base-200": "#191e24",
//   "base-300": "#15191e",
//   "base-content": "#A6ADBB",
// }

// cupcake: {
//   "color-scheme": "light",
//   "primary": "#65c3c8",
//   "secondary": "#ef9fbc",
//   "accent": "#eeaf3a",
//   "neutral": "#291334",
//   "base-100": "#faf7f5",
//   "base-200": "#efeae6",
//   "base-300": "#e7e2df",
//   "base-content": "#291334",
// },

import { vars } from "nativewind";

export default {
  default: {
    dark: vars({
      "--color-primary": "117 130 255",
      "--color-secondary": "255 113 207",
      "--color-accent": "0 199 181",
      "--color-neutral": "42 50 60",
      "--color-neutral-content": "166 173 187",
      "--color-base-100": "29 35 42",
      "--color-base-200": "25 30 36",
      "--color-base-300": "21 25 30",
      "--color-base-content": "166 173 187",
    }),
    light: vars({
      "--color-primary": "101 195 200",
      "--color-secondary": "239 159 188",
      "--color-accent": "238 175 58",
      "--color-neutral": "41 19 52",
      "--color-base-100": "250 247 245",
      "--color-base-200": "239 234 230",
      "--color-base-300": "231 226 223",
      "--color-base-content": "41 19 52",
    }),
  },
};
