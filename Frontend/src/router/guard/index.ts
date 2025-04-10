import type { RouteRecordRaw } from "vue-router";
const AssignmentsPage = () =>
  import("@/pages/AssignmentsPage/AssignmentsPage.vue");

const guardRoutes: RouteRecordRaw[] = [
  {
    path: "/assignments",
    name: "assignments",
    component: AssignmentsPage,
    meta: {
      title: "Assignments",
      requiresAuth: true,
      layout: "main",
    },
  },
];

export default guardRoutes;
