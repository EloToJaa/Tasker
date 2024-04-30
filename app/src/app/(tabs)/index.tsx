import { Link } from "expo-router";
import { useTranslation } from "react-i18next";
import { Button, ScrollView, Text } from "react-native";

export default function Page() {
  const { t, i18n } = useTranslation();

  return (
    <ScrollView>
      <Text className="text-3xl text-picton-blue-600">
        {t("common.welcome")}
      </Text>
      <Button onPress={() => i18n.changeLanguage("en")} title="English" />
      <Button onPress={() => i18n.changeLanguage("pl")} title="Polish" />
      <Link href="/(drawer)">
        <Text className="text-picton-blue-600 text-3xl">User 1</Text>
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
