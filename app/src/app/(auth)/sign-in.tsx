import { ScrollView, Text } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";

export default function Page() {
  return (
    <SafeAreaView className="bg-primary h-full">
      <ScrollView>
        <Text>Sign in</Text>
      </ScrollView>
    </SafeAreaView>
  );
}
