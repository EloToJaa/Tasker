import { Link } from "expo-router";
import { useColorScheme } from "nativewind";
import { useTranslation } from "react-i18next";
import { Button, ScrollView, Text } from "react-native";
import { SafeAreaView } from "react-native-safe-area-context";

export default function Page() {
  const { t, i18n } = useTranslation();
  const { colorScheme, setColorScheme } = useColorScheme();

  return (
    <SafeAreaView>
      <ScrollView className="bg-base-100">
        <Button
          onPress={() =>
            setColorScheme(colorScheme === "light" ? "dark" : "light")
          }
          title={colorScheme === "light" ? "Dark" : "Light"}
        />
        <Button onPress={() => i18n.changeLanguage("en")} title="English" />
        <Button onPress={() => i18n.changeLanguage("pl")} title="Polish" />

        <Text className="text-3xl text-primary">{t("common.welcome")}</Text>

        <Text className="text-3xl text-secondary">{t("common.welcome")}</Text>
        <Link href="/(auth)/sign-in">
          <Text className="text-primary text-3xl">Sign In</Text>
        </Link>
        <Link href="/(auth)/sign-up">
          <Text className="text-primary text-3xl">Sign Up</Text>
        </Link>
        <Text className="text-blue-600 text-xl">User 2</Text>
        <Text className="text-xl text-base-content text-justify">
          Lorem ipsum, dolor sit amet consectetur adipisicing elit. Sint
          consequatur, eligendi totam dignissimos ab doloremque aliquam maiores
          distinctio? Dicta nulla est libero ab odio provident ut facere sunt
          eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
          elit. Sint consequatur, eligendi totam dignissimos ab doloremque
          aliquam maiores distinctio? Dicta nulla est libero ab odio provident
          ut facere sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur
          adipisicing elit. Sint consequatur, eligendi totam dignissimos ab
          doloremque aliquam maiores distinctio? Dicta nulla est libero ab odio
          provident ut facere sunt eveniet alias? Lorem ipsum, dolor sit amet
          consectetur adipisicing elit. Sint consequatur, eligendi totam
          dignissimos ab doloremque aliquam maiores distinctio? Dicta nulla est
          libero ab odio provident ut facere sunt eveniet alias? Lorem ipsum,
          dolor sit amet consectetur adipisicing elit. Sint consequatur,
          eligendi totam dignissimos ab doloremque aliquam maiores distinctio?
          Dicta nulla est libero ab odio provident ut facere sunt eveniet
          alias?Lorem ipsum, dolor sit amet consectetur adipisicing elit. Sint
          consequatur, eligendi totam dignissimos ab doloremque aliquam maiores
          distinctio? Dicta nulla est libero ab odio provident ut facere sunt
          eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
          elit. Sint consequatur, eligendi totam dignissimos ab doloremque
          aliquam maiores distinctio? Dicta nulla est libero ab odio provident
          ut facere sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur
          adipisicing elit. Sint consequatur, eligendi totam dignissimos ab
          doloremque aliquam maiores distinctio? Dicta nulla est libero ab odio
          provident ut facere sunt eveniet alias? Lorem ipsum, dolor sit amet
          consectetur adipisicing elit. Sint consequatur, eligendi totam
          dignissimos ab doloremque aliquam maiores distinctio? Dicta nulla est
          libero ab odio provident ut facere sunt eveniet alias? Lorem ipsum,
          dolor sit amet consectetur adipisicing elit. Sint consequatur,
          eligendi totam dignissimos ab doloremque aliquam maiores distinctio?
          Dicta nulla est libero ab odio provident ut facere sunt eveniet
          alias?Lorem ipsum, dolor sit amet consectetur adipisicing elit. Sint
          consequatur, eligendi totam dignissimos ab doloremque aliquam maiores
          distinctio? Dicta nulla est libero ab odio provident ut facere sunt
          eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
          elit. Sint consequatur, eligendi totam dignissimos ab doloremque
          aliquam maiores distinctio? Dicta nulla est libero ab odio provident
          ut facere sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur
          adipisicing elit. Sint consequatur, eligendi totam dignissimos ab
          doloremque aliquam maiores distinctio? Dicta nulla est libero ab odio
          provident ut facere sunt eveniet alias? Lorem ipsum, dolor sit amet
          consectetur adipisicing elit. Sint consequatur, eligendi totam
          dignissimos ab doloremque aliquam maiores distinctio? Dicta nulla est
          libero ab odio provident ut facere sunt eveniet alias? Lorem ipsum,
          dolor sit amet consectetur adipisicing elit. Sint consequatur,
          eligendi totam dignissimos ab doloremque aliquam maiores distinctio?
          Dicta nulla est libero ab odio provident ut facere sunt eveniet alias?
        </Text>
      </ScrollView>
    </SafeAreaView>
  );
}
