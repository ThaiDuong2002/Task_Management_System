import {
  AlarmClock,
  CalendarClock,
  CalendarRange,
  CircleCheck,
  Star,
} from "lucide-vue-next";

export const sidebarGroups = {
  independencies: [
    {
      name: "Today",
      icon: CalendarClock,
      url: "/assignments/today",
    },
    {
      name: "Important",
      icon: Star,
      url: "/assignments/important",
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
      icon: CircleCheck,
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
      icon: CircleCheck,
      url: "/group-assignments/completed",
    },
  ],
};
