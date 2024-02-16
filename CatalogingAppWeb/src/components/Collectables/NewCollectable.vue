<template>
    <div>
        <v-form>
            <v-container fluid>
                <v-row>
                    <v-col cols="12">
                        <v-file-input v-model="files" label="File input" chips multiple></v-file-input>
                        <v-text-field v-model="collectable.Title" :rules="[v => !!v || 'Title is required']"
                            :counter="10" label="Title" required>
                        </v-text-field>
                        <v-text-field v-model="collectable.Description" label="Description"></v-text-field>
                        <v-text-field v-model="collectable.Pricepaid" label="Price Paid"></v-text-field>
                        <v-text-field v-model="collectable.Currentworth" label="Current Worth"></v-text-field>
                        <v-text-field v-model="collectable.Size" label="Size"></v-text-field>
                        <v-btn @click="submit">Submit</v-btn>
                    </v-col>
                </v-row>
            </v-container>
        </v-form>
    </div>
</template>

<script>
import api from '../../api/api.js'

export default {
    name: 'NewCollectable',
    components: {

    },
    setup() {
    },
    data() {
        return {
            collectable: {
                Hierarchynode: {
                    id:0,
                },
                Title: null,
                Description: null,
                Pricepaid: null,
                Currentworth: null,
                Size: null,
            },
            files: [],
        }
    },
    methods: {
        async submit() {
            var collectable = (await api.post('/collectables', this.collectable)).data;

            console.log(collectable);

            this.files.forEach(f => {
                var formData = new FormData();
                formData.append("file", f);
                formData.append("collectableId", collectable.id);
                api.post('images', formData, {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    }
                })
            });
        },
    },
}
</script>

<style>

</style>