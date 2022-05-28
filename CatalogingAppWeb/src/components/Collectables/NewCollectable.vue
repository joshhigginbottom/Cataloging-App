<template>
    <form @submit="submit">
        <div><label>Title:</label><input type="text" v-model="collectable.Title" /></div>
        <div><label>Description:</label><input type="text" v-model="collectable.Description" /></div>
        <div><label>Price Paid:</label><input type="text" v-model="collectable.Pricepaid" /></div>
        <div><label>Current Worth:</label><input type="text" v-model="collectable.Currentworth" /></div>
        <div><label>Size:</label><input type="text" v-model="collectable.Size" /></div>
        <button>Submit</button>
    </form>
</template>

<script>
import api from '../../api/api.js'

export default {
    name:'NewCollectable',
    data(){
        return {
            collectable:{
                Id:0,
                Title:'',
                Description:'',
                Pricepaid:0,
                Currentworth:0,
                Size:'',
            },
        }
    },
    methods:{
        submit:function() {
            console.log(this.collectable);
            api.post('/collectables',this.collectable);
        },
    },
}
</script>

<style>
</style>