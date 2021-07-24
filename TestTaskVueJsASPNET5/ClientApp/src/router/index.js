﻿import { createWebHistory, createRouter } from "vue-router";
import UsersList from "@/components/UsersList.vue";

const routes = [
    {
        path: "/UsersList",
        name: "UsersList",
        component: UsersList,
    },  
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;