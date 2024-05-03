import { Link } from "expo-router";
import {
  ScrollView,
  Text,
  TextInput,
  TouchableOpacity,
  View,
} from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";

// const schema = z.object({
//   email: z.string().email(),
//   password: z.string().min(6),
// });

export default function Page() {
  return (
    <SafeAreaView className="bg-primary h-full">
      <ScrollView>
        <View className="w-full justify-center min-h-[85vh] px-4 my-6">
          <View className="flex flex-col items-center">
            <Text className="text-3xl font-bold text-white">Sign in</Text>
            <Text className="text-white mt-2">Welcome back!</Text>
          </View>

          <View className="flex flex-col mt-8">
            <TextInput
              placeholder="Email"
              className=""
              keyboardType="email-address"
              textContentType="emailAddress"
            />

            <TextInput
              placeholder="Password"
              className="mt-4"
              secureTextEntry
              textContentType="password"
            />

            <TouchableOpacity className="mt-4" onPress={() => {}}>
              <Text className="text-white text-center">Sign in</Text>
            </TouchableOpacity>
          </View>

          <View className="flex flex-col mt-4">
            <Text className="text-white text-center">
              Don't have an account?
              <Link href="sign-up" className="text-accent">
                Sign up
              </Link>
            </Text>
          </View>
        </View>
      </ScrollView>
    </SafeAreaView>
  );
}
