import { createWebHashHistory, createRouter } from 'vue-router'
import HelloWorld from '../components/HelloWorld.vue'
import NewCollectable from '../components/Collectables/NewCollectable.vue'
import ViewCollectables from '../components/Collectables/ViewCollectables.vue'

const routes = [
    {
        path:'/',
        component:HelloWorld,
        props:{msg:'Hi Rach'},
    },
    {
        path:'/NewCollectable',
        component:NewCollectable,
    },
    {
        path:'/ViewCollectables',
        component:ViewCollectables,
    },
]

const router = createRouter({
    history:createWebHashHistory(),
    routes,
});

export default router;