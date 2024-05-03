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
      "--color-primary": "rgb(117 130 255)",
      "--color-secondary": "rgb(255 113 207)",
      "--color-accent": "rgb(0 199 181)",
      "--color-neutral": "rgb(42 50 60)",
      "--color-neutral-content": "rgb(166 173 187)",
      "--color-base-100": "rgb(29 35 42)",
      "--color-base-200": "rgb(25 30 36)",
      "--color-base-300": "rgb(21 25 30)",
      "--color-base-content": "rgb(166 173 187)",
    }),
    light: vars({
      "--color-primary": "rgb(101 195 200)",
      "--color-secondary": "rgb(239 159 188)",
      "--color-accent": "rgb(238 175 58)",
      "--color-neutral": "rgb(41 19 52)",
      "--color-neutral-content": "rgb(166 173 187)",
      "--color-base-100": "rgb(250 247 245)",
      "--color-base-200": "rgb(239 234 230)",
      "--color-base-300": "rgb(231 226 223)",
      "--color-base-content": "rgb(41 19 52)",
    }),
  },
};
