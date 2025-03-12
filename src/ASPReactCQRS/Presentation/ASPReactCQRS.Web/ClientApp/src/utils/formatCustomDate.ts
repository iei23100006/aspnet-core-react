export default function formatCustomDate(date: Date): string {
  const options: Intl.DateTimeFormatOptions = {
    weekday: "short",
    month: "short",
    day: "numeric",
    year: "numeric",
    hour: "numeric",
    minute: "numeric",
    second: "numeric",
    hour12: true,
  };

  // Convert the date to the desired format
  const formattedDate = date.toLocaleString("en-US", options);

  return formattedDate.replace(",", "");
}
