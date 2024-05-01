import themes from "@/lib/themes";
import { ReactNode } from "react";
import { useColorScheme, View } from "react-native";

export type ThemeProps = {
  name: keyof typeof themes;
  children: ReactNode;
};

export default function ThemeProvider({ children, name }: ThemeProps) {
  const colorScheme = useColorScheme();

  return (
    <View style={themes[name][colorScheme]} className="flex-1">
      {children}
    </View>
  );
}
