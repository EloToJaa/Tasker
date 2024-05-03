import { useCallback, useEffect, useState } from "react";
import { Button, ScrollView, Text, View } from "react-native";
import {
  authorize,
  prefetchConfiguration,
  refresh,
} from "react-native-app-auth";
import { SafeAreaView } from "react-native-safe-area-context";

const config = {
  issuer: "https://eloauth.com",
  clientId: "265340021010174466@tasker",
  redirectUrl: "https://localhost:3000/callback",
  scopes: ["openid", "profile", "email"],
};

export default function Page() {
  const [progress, setProgress] = useState(false);

  useEffect(() => {
    prefetchConfiguration({
      warmAndPrefetchChrome: true,
      connectionTimeoutSeconds: 5,
      ...config,
    });
  }, []);

  const handleLoginPress = useCallback(async () => {
    console.log("Login pressed");
    setProgress(true);
    try {
      const authState = await authorize(config);
      console.log(authState);

      const refreshedState = await refresh(config, {
        refreshToken: authState.refreshToken,
      });
      console.log(refreshedState);
    } catch (error) {
      console.log("error", error);
    }
  }, []);

  return (
    <SafeAreaView className="bg-primary h-full">
      <ScrollView>
        <View className="w-full justify-center min-h-[85vh] px-4 my-6">
          <Text className="text-3xl font-bold text-white">Sign up</Text>
        </View>
        <Button title="Sign up" onPress={() => handleLoginPress()} />
      </ScrollView>
    </SafeAreaView>
  );
}
