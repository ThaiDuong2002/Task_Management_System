import type { RouteRecordRaw } from "vue-router";
const TasksPage = () => import("@/pages/TasksPage/index.vue");

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
