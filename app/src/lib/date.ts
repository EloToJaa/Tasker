export function getCurrentDate() {
  return new Date();
}

export function getFormattedDate(date: Date) {
  return date.toISOString().split("T")[0];
}

export function addMonth(date: Date, count: number = 1) {
  date.setMonth(date.getMonth() + count);
  date.setDate(1);
  return date;
}

export function getLastDayOfMonth(date: Date) {
  date.setMonth(date.getMonth() + 1);
  date.setDate(0);
  return date;
}
