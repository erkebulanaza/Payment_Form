import { createRouter, createWebHistory } from 'vue-router';

import PaymentForm from '../components/PaymentForm.vue';
import PaymentHistory from '../components/PaymentHistory.vue';
import PaymentStats from '../components/PaymentStats.vue';

const routes = [
    { path: '/', component: PaymentForm },
    { path: '/history', component: PaymentHistory },
    { path: '/stats', component: PaymentStats },
];

export const router = createRouter({
    history: createWebHistory(),
    routes,
});