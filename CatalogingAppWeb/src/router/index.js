import { createWebHashHistory, createRouter } from 'vue-router'
import HelloWorld from '../components/HelloWorld.vue'
import NewCollectable from '../components/Collectables/NewCollectable.vue'

const routes = [
    {
        path:'/HelloWorld',
        component:HelloWorld,
        props:{msg:'Hi Rach'},
    },
    {
        path:'/NewCollectable',
        component:NewCollectable,
    },
]

const router = createRouter({
    history:createWebHashHistory(),
    routes,
});

export default router;