import type { RouteRecordRaw } from "vue-router";
const AssignmentsPage = () =>
  import("@/pages/AssignmentsPage/AssignmentsPage.vue");
const GroupAssignmentsPage = () =>
  import("@/pages/GroupAssignmentsPage/GroupAssignmentsPage.vue");

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
  {
    path: "/group-assignments",
    name: "group-assignments",
    component: GroupAssignmentsPage,
    meta: {
      title: "Group Assignments",
      requiresAuth: true,
      layout: "main",
    },
  },
];

export default guardRoutes;
