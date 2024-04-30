import en from "@/translations/en.json";
import pl from "@/translations/pl.json";
import i18n from "i18next";
import { initReactI18next } from "react-i18next";

const resources = {
  en: {
    translation: en,
  },
  pl: {
    translation: pl,
  },
};

i18n.use(initReactI18next).init({
  resources,
  lng: "en",
  fallbackLng: "en",
  compatibilityJSON: "v3",
  interpolation: {
    escapeValue: false,
  },
});

export default i18n;
