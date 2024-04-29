import { Link } from "expo-router";
import { useState } from "react";
import { ScrollView, Text } from "react-native";

export default function Page() {
  const [text, setText] = useState("");

  return (
    <ScrollView>
      <Text className="text-3xl text-picton-blue-600">Page</Text>
      <Link href="/users/1">
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
