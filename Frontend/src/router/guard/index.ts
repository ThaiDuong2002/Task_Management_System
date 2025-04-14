import type { RouteRecordRaw } from "vue-router";
const ImportantPage = () =>
  import("@/pages/Assignments/ImportantPage/ImportantPage.vue");
const TodayPage = () => import("@/pages/Assignments/TodayPage/TodayPage.vue");
const UpcomingPage = () =>
  import("@/pages/Assignments/UpcomingPage/UpcomingPage.vue");
const OverduePage = () =>
  import("@/pages/Assignments/OverduePage/OverduePage.vue");
const CompletedPage = () =>
  import("@/pages/Assignments/CompletedPage/CompletedPage.vue");

const GroupImportantPage = () =>
  import("@/pages/GroupAssignments/ImportantPage/ImportantPage.vue");
const GroupOverduePage = () =>
  import("@/pages/GroupAssignments/OverduePage/OverduePage.vue");
const GroupCompletedPage = () =>
  import("@/pages/GroupAssignments/CompletedPage/CompletedPage.vue");

const UserProfilePage = () =>
  import("@/pages/UserProfilePage/UserProfilePage.vue");

const guardRoutes: RouteRecordRaw[] = [
  {
    path: "/assignments",
    name: "assignments",
    children: [
      {
        path: "important",
        name: "important",
        component: ImportantPage,
      },
      {
        path: "today",
        name: "today",
        component: TodayPage,
      },
      {
        path: "upcoming",
        name: "upcoming",
        component: UpcomingPage,
      },
      {
        path: "overdue",
        name: "overdue",
        component: OverduePage,
      },
      {
        path: "completed",
        name: "completed",
        component: CompletedPage,
      },
    ],
    meta: {
      title: "Assignments",
      requiresAuth: true,
      layout: "main",
    },
  },
  {
    path: "/group-assignments",
    name: "group-assignments",
    children: [
      {
        path: "important",
        name: "group-important",
        component: GroupImportantPage,
      },
      {
        path: "overdue",
        name: "group-overdue",
        component: GroupOverduePage,
      },
      {
        path: "completed",
        name: "group-completed",
        component: GroupCompletedPage,
      },
    ],
    meta: {
      title: "Group Assignments",
      requiresAuth: true,
      layout: "main",
    },
  },
  {
    path: "/user",
    name: "user",
    children: [
      {
        path: "profile",
        name: "profile",
        component: UserProfilePage,
      },
    ],
    meta: {
      title: "User Profile",
      requiresAuth: true,
      layout: "main",
    },
  },
];

export default guardRoutes;
