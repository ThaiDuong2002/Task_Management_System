import type { RouteRecordRaw } from "vue-router";
const TasksPage = () => import("@/pages/TasksPage");

const guardRoutes: RouteRecordRaw[] = [
  {
    path: "/tasks",
    name: "tasks",
    component: TasksPage,
    meta: {
      title: "Tasks",
      requiresAuth: true,
    },
  },
];

export default guardRoutes;
