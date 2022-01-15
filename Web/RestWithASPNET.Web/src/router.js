import { createWebHistory, createRouter } from "vue-router";

import Home from './pages/Home.vue';

const routes = [
	{
		path: '/',
		name: 'Home',
		component: Home
	},
	{
		path: '/books',
		name: 'Books',
		component: () => import('./pages/Book.vue')
	},
	{
		path: '/authors',
		name: 'Authors',
		component: () => import('./pages/Author.vue')
	},
];

const router = createRouter({
	history: createWebHistory(),
	routes
});

export default router;