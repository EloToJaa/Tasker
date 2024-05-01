import { Link } from "expo-router";
import { useColorScheme } from "nativewind";
import { useTranslation } from "react-i18next";
import { Button, ScrollView, Text } from "react-native";

export default function Page() {
  const { t, i18n } = useTranslation();
  const { colorScheme, setColorScheme } = useColorScheme();

  return (
    <ScrollView>
      <Button
        onPress={() =>
          setColorScheme(colorScheme === "light" ? "dark" : "light")
        }
        title="Change color scheme"
      />
      <Button onPress={() => i18n.changeLanguage("en")} title="English" />
      <Button onPress={() => i18n.changeLanguage("pl")} title="Polish" />

      <Text className="text-3xl text-primary">{t("common.welcome")}</Text>

      <Text className="text-3xl text-secondary">{t("common.welcome")}</Text>
      <Link href="/(auth)/sign-in">
        <Text className="text-picton-blue-600 text-3xl">Sign In</Text>
      </Link>
      <Text className="text-blue-600 text-xl">User 2</Text>
      <Text className="text-xl">
        Lorem ipsum, dolor sit amet consectetur adipisicing elit. Sint
        consequatur, eligendi totam dignissimos ab doloremque aliquam maiores
        distinctio? Dicta nulla est libero ab odio provident ut facere sunt
        eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing elit.
        Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias?Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias?Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias? Lorem ipsum, dolor sit amet consectetur adipisicing
        elit. Sint consequatur, eligendi totam dignissimos ab doloremque aliquam
        maiores distinctio? Dicta nulla est libero ab odio provident ut facere
        sunt eveniet alias?
      </Text>
    </ScrollView>
  );
}
