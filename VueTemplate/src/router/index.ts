import {createRouter, createWebHashHistory} from 'vue-router';

const router = createRouter({
    history: createWebHashHistory(),
    routes: [
        {
            path: '/',
            component: () => import('../views/Login.vue')
        },
        {
            path: '/register',
            component: () => import('../views/Register.vue')
        },
        {
            path: '/person',
            component: () => import('../views/Person.vue')
        },
        {
            path: '/customerList',
            component: () => import('../views/CustomerList.vue')
        },
        {
            path: '/login',
            redirect: '/'
        }
    ]
})

export default router;