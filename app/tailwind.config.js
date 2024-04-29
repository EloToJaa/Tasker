/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{js,jsx,ts,tsx}"],
  presets: [require("nativewind/preset")],
  theme: {
    extend: {},
    colors: {
      "picton-blue": {
        50: "#f2f8fd",
        100: "#e3effb",
        200: "#c1e0f6",
        300: "#8ac6ef",
        400: "#68b7e8",
        500: "#258fd2",
        600: "#1771b2",
        700: "#145b90",
        800: "#144d78",
        900: "#164164",
        950: "#0f2a42",
      },
    },
  },
  future: {
    hoverOnlyWhenSupported: true,
  },
  plugins: [],
};
