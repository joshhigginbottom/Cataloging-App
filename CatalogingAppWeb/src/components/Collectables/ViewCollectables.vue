<template>
    <div class="container">
        <v-sheet 
            v-for="collectable in this.collectables"
            class="card"
            :key="collectable.Id"
            :elevation="3"
            :height="200"
            :width="200"
        >
            <h2>{{ collectable.Title }}</h2>
        </v-sheet>
    </div>
</template>

<script>
import api from '../../api/api.js'

export default {
    name: 'ViewCollectables',
    components: {
       
    },
    async created(){
        this.collectables = (await api.get('collectables?$expand=images')).data;
    },
    data() {
        return {
            collectables: []
        }
    },
    methods: {

    },
}
</script>

<style>
    .card {
        margin:10px;
        padding:10px;
    }
    .container {
        display: inline-flex;
        flex-direction: row;
        flex-wrap: wrap;
    }
</style>