import {
  AlarmClock,
  CalendarClock,
  CalendarRange,
  GalleryVertical,
  Star,
} from "lucide-vue-next";

export const sidebarGroups = {
  independencies: [
    {
      name: "Important",
      icon: Star,
      url: "/assignments/important",
    },
    {
      name: "Today",
      icon: CalendarClock,
      url: "/assignments/today",
    },
    {
      name: "Upcoming",
      icon: CalendarRange,
      url: "/assignments/upcoming",
    },
    {
      name: "Overdue",
      icon: AlarmClock,
      url: "/assignments/overdue",
    },
    {
      name: "Completed",
      icon: GalleryVertical,
      url: "/assignments/completed",
    },
  ],
  dependencies: [
    {
      name: "Important",
      icon: Star,
      url: "/group-assignments/important",
    },
    {
      name: "Overdue",
      icon: AlarmClock,
      url: "/group-assignments/overdue",
    },
    {
      name: "Completed",
      icon: GalleryVertical,
      url: "/group-assignments/completed",
    },
  ],
};
