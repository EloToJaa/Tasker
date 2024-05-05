import ThemeProvider from "@/components/ThemeProvider";
import "@/lib/i18n";
import * as Notifications from "expo-notifications";
import { Stack } from "expo-router";
import { StatusBar } from "expo-status-bar";
import "../global.css";

Notifications.setNotificationHandler({
  handleNotification: async () => ({
    shouldShowAlert: true,
    shouldPlaySound: false,
    shouldSetBadge: false,
  }),
});

export default function Layout() {
  return (
    <ThemeProvider name="default">
      <Stack>
        <Stack.Screen name="(tabs)" options={{ headerShown: false }} />
        <Stack.Screen name="(auth)" options={{ headerShown: false }} />
        <Stack.Screen name="redirect" options={{ headerShown: true }} />
      </Stack>
      <StatusBar backgroundColor="#161622" style="light" />
    </ThemeProvider>
  );
}
