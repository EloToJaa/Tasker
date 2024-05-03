import { Redirect } from "expo-router";
import { Button, Text, View } from "react-native";

type Props = {
  handleLogin: () => void;
  authenticated: boolean | null;
};

export default function Login({ authenticated, handleLogin }: Props) {
  if (authenticated === null) {
    return <Text>Loading...</Text>;
  } else if (authenticated === false) {
    return (
      <View>
        <Button title="Login" onPress={handleLogin} />
      </View>
    );
  }

  return <Redirect href="/callback" />;
}
