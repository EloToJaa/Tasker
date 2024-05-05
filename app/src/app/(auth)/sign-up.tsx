import { useCallback, useEffect, useState } from "react";
import { Button, ScrollView, Text, View } from "react-native";
import { authorize, prefetchConfiguration } from "react-native-app-auth";
import { SafeAreaView } from "react-native-safe-area-context";

// const config = {
//   issuer: "https://eloauth.com",
//   clientId: "265340021010174466@tasker",
//   redirectUrl: "com.elotoja.tasker:/redirect",
//   scopes: ["openid", "profile", "email", "offline_access"],
// };

const config = {
  issuer: "https://accounts.google.com",
  clientId:
    "232220184030-kb8lfaou0fjmmb32bpujc7alcghjvl9s.apps.googleusercontent.com",
  redirectUrl: "tasker://sign-up",
  scopes: ["openid", "profile"],
};

// const config = {
//   issuer:
//     "https://taker-dev-4jkb6n.zitadel.cloud/oauth/v2/device_authorization",
//   clientId: "265632486120317854@taker-api",
//   redirectUrl: "com.elotoja.tasker:/redirect",
//   scopes: ["openid", "profile", "email", "offline_access"],
// };

const defaultAuthState = {
  hasLoggedInOnce: false,
  accessToken: "",
  accessTokenExpirationDate: "",
  refreshToken: "",
};

export default function Page() {
  useEffect(() => {
    prefetchConfiguration({
      warmAndPrefetchChrome: true,
      connectionTimeoutSeconds: 5,
      ...config,
    });
  }, []);

  // const handleLoginPress = async () => {
  //   console.log("Login pressed");
  //   setProgress(true);
  //   try {
  //     console.log("config", config);
  //     const authState = await authorize(config);
  //     console.log("authState", authState);

  //     // const refreshedState = await refresh(config, {
  //     //   refreshToken: authState.refreshToken,
  //     // });
  //     // console.log(refreshedState);
  //   } catch (error) {
  //     console.log("error", error);
  //   }
  // };

  const [authState, setAuthState] = useState(defaultAuthState);

  const handleAuthorize = useCallback(async () => {
    try {
      const newAuthState = await authorize({
        ...config,
        connectionTimeoutSeconds: 5,
        iosPrefersEphemeralSession: true,
      });

      setAuthState({
        hasLoggedInOnce: true,
        ...newAuthState,
      });
    } catch (error) {
      console.error("Failed to log in", error);
    }
  }, []);

  return (
    <SafeAreaView className="bg-primary h-full">
      <ScrollView>
        <View className="w-full justify-center min-h-[85vh] px-4 my-6">
          <Text className="text-3xl font-bold text-white">Sign up</Text>
        </View>
        <Button title="Sign up" onPress={() => handleAuthorize()} />
      </ScrollView>
    </SafeAreaView>
  );
}
