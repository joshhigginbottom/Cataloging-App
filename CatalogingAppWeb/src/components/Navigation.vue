<template>
    <v-app-bar app :elevation="1">
        <template v-slot:prepend>
            <v-icon icon="mdi-shoe-ballet" />
        </template>

        <v-app-bar-title>Clog</v-app-bar-title>
        <v-divider vertical class="mx-4"></v-divider>
        <v-menu>
            <template v-slot:activator="{ props }">
                <v-btn color="primary" v-bind="props">Collectables</v-btn>
            </template>
            <v-list>
                <v-list-item v-for="(item, index) in items" :key="index" :value="index" :to="item.to">
                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                </v-list-item>
            </v-list>
        </v-menu>
        <!--<v-spacer></v-spacer>-->
        <template v-slot:append>
            <!--<v-btn icon="mdi-dots-vertical"></v-btn>-->
        </template>
    </v-app-bar>
</template>

<script>
//import { RouterLink } from 'vue-router';
//import { BookOutline } from '@vicons/ionicons5'

export default {
    name: 'NavigationBar',
    components: {

    },
    data() {
        return {
            items: [
                { title: "View", to: "/ViewCollectables" },
                { title: "Add", to: "/NewCollectable" }
            ]
        };
    },
}
</script>

<style>
.v-toolbar-title {
    flex-grow: 0;
    flex-basis: auto;
}

.v-toolbar__prepend {
    margin-inline-end: 0;
}
</style>