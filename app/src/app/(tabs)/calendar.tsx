import {
  addMonth,
  getCurrentDate,
  getFormattedDate,
  getLastDayOfMonth,
} from "@/lib/date";
import { useEffect, useState } from "react";
import { Text, TouchableOpacity } from "react-native";
import { Agenda, AgendaEntry } from "react-native-calendars";
import {
  AgendaSchedule,
  DateData,
  MarkedDates,
} from "react-native-calendars/src/types";
import { SafeAreaView } from "react-native-safe-area-context";

export default function Page() {
  const [items, setItems] = useState<AgendaSchedule>({});
  const [markedDates, setMarkedDates] = useState<MarkedDates>({});

  const firstDay = addMonth(getCurrentDate(), -2);
  const lastDay = getLastDayOfMonth(addMonth(getCurrentDate(), 12));

  const loadItems = (data: DateData) => {
    for (let i = -15; i < 85; i++) {
      const time = data.timestamp + i * 24 * 60 * 60 * 1000;
      const date = new Date(time);
      if (date <= firstDay || date >= lastDay) continue;
      const strTime = date.toISOString().split("T")[0];
      if (!items[strTime]) {
        items[strTime] = [];
        const numItems = Math.floor(Math.random() * 5);
        for (let j = 0; j < numItems; j++) {
          items[strTime].push({
            name: "Item for " + strTime + " #" + j,
            height: 0,
            day: strTime,
          });
        }
      }
    }
    const newItems = {};
    Object.keys(items).forEach((key) => {
      newItems[key] = items[key];
    });
    setItems(newItems);
  };

  const renderItem = (reservation: AgendaEntry, isFirst: boolean) => {
    return (
      <TouchableOpacity className="border rounded-md p-2 mt-2 min-h-20">
        <Text>
          {reservation.name}, {reservation.height}, {reservation.day},
          {isFirst ? "first" : "not first"}
        </Text>
      </TouchableOpacity>
    );
  };

  useEffect(() => {
    setMarkedDates(
      Object.keys(items).reduce((acc, key) => {
        acc[key] = {
          color: "green",
          startingDay: true,
          endingDay: true,
        } as MarkedDates[keyof MarkedDates];
        return acc;
      }, {}),
    );
  }, [items]);

  return (
    <SafeAreaView style={{ flex: 1 }} className="bg-picton-blue-600 h-full">
      <Agenda
        items={items}
        loadItemsForMonth={loadItems}
        selected={getFormattedDate(getCurrentDate())}
        renderItem={renderItem}
        markingType="period"
        markedDates={markedDates}
        minDate={getFormattedDate(firstDay)}
        maxDate={getFormattedDate(lastDay)}
      />
    </SafeAreaView>
  );
}
