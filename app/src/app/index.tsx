import { Text, View } from "react-native";

export default function Page() {
  const name = 'React Native';

  return (
    <View className="mt-12">
      <View className="mx-auto">
        <Text className="text-3xl">Page</Text>
      </View>
    </View>
  );
}
