<template>
    <NIcon size ="300%">
        <BookOutline />
    </NIcon>
    <n-menu mode="horizontal" :options="menuOptions" />
</template>

<script>
import { h } from 'vue';
import { NMenu, NIcon } from 'naive-ui';
import { RouterLink } from 'vue-router';
import { BookOutline } from '@vicons/ionicons5'

export default {
    name: 'NavigationBar',
    components: {
        NMenu, BookOutline, NIcon
    },
    data() {
        return {
            menuOptions: [
                {
                    label: () => h(RouterLink, { to: { path: '/' } }, { default: () => 'Hello World' }),
                    key: 'hello-world'
                },
                {
                    label: () => h(RouterLink, { to: { path: '/ViewCollectables' } }, { default: () => 'View Collectables' }),
                    key: 'view-collectables'
                },
                {
                    label: () => h(RouterLink, { to: { path: '/NewCollectable' } }, { default: () => 'New Collectable' }),
                    key: 'new-collectable'
                },
            ],
            getImageUrl(name) {
                return new URL(`../assets/${name}`, import.meta.url).href
            },
        };
    },
}
</script>

<style>
</style>