import type { RouteRecordRaw } from "vue-router";
const AssignmentsPage = () => import("@/pages/AssignmentsPage");

const guardRoutes: RouteRecordRaw[] = [
  {
    path: "/assignments",
    name: "assignments",
    component: AssignmentsPage,
    meta: {
      title: "Assignments",
      requiresAuth: true,
    },
  },
];

export default guardRoutes;
