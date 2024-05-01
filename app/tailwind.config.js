/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{js,jsx,ts,tsx}"],
  presets: [require("nativewind/preset")],
  theme: {
    extend: {},
    colors: {
      primary: "rgb(var(--color-primary))",
      secondary: "rgb(var(--color-secondary))",
      accent: "rgb(var(--color-accent))",
      neutral: "rgb(var(--color-neutral))",
      "neutral-content": "rgb(var(--color-neutral-content))",
      "base-100": "rgb(var(--color-base-100))",
      "base-200": "rgb(var(--color-base-200))",
      "base-300": "rgb(var(--color-base-300))",
      "base-content": "rgb(var(--color-base-content))",
    },
    fontFamily: {
      pthin: ["Poppins-Thin", "sans-serif"],
      pextralight: ["Poppins-ExtraLight", "sans-serif"],
      plight: ["Poppins-Light", "sans-serif"],
      pregular: ["Poppins-Regular", "sans-serif"],
      pmedium: ["Poppins-Medium", "sans-serif"],
      psemibold: ["Poppins-SemiBold", "sans-serif"],
      pbold: ["Poppins-Bold", "sans-serif"],
      pextrabold: ["Poppins-ExtraBold", "sans-serif"],
      pblack: ["Poppins-Black", "sans-serif"],
    },
  },
  future: {
    hoverOnlyWhenSupported: true,
  },
  plugins: [],
};
