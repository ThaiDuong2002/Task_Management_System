import {
  AlarmClock,
  CalendarClock,
  CalendarRange,
  GalleryVertical,
  Star,
} from "lucide-vue-next";

export const sidebarGroups = {
  independents: [
    {
      name: "Important",
      icon: Star,
      url: "/important",
    },
    {
      name: "Today",
      icon: CalendarClock,
      url: "/today",
    },
    {
      name: "Upcoming",
      icon: CalendarRange,
      url: "/upcoming",
    },
    {
      name: "Overdue",
      icon: AlarmClock,
      url: "/overdue",
    },
    {
      name: "Completed",
      icon: GalleryVertical,
      url: "/completed",
    },
  ],
};
