<template>
    <n-card size="medium">
        <n-form>
            <n-upload 
                multiple
                directory-dnd
                action="https://localhost:7138/api/images"
                ref="upload"
                :default-upload="false"
                @change="handleChange"
                :max="5"
                list-type="image-card"
            >
                <n-upload-dragger>
                    <n-icon size="48" :depth="3">
                        <ArchiveOutline />
                    </n-icon>
                    <!--<n-text style="font-size: 16px">
                        Click or drag a file to this area to upload
                    </n-text>-->
                </n-upload-dragger>
            </n-upload>
            <n-divider />
            <n-form-item label="Title">
                <n-input type="text" v-model:value="collectable.Title" />
            </n-form-item>
            <n-form-item label="Description">
                <n-input type="text" v-model:value="collectable.Description" />
            </n-form-item>
            <n-form-item label="Price Paid">
                <n-input-number v-model:value="collectable.Pricepaid" />
            </n-form-item>
            <n-form-item label="Current Worth">
                <n-input-number v-model:value="collectable.Currentworth" />
            </n-form-item>
            <n-form-item label="Size">
                <n-input type="text" v-model:value="collectable.Size" />
            </n-form-item>
            <n-button @click="submit">Create</n-button>
        </n-form>
    </n-card>
</template>

<script>
import api from '../../api/api.js'
import { ref } from 'vue';
import { NInput, NInputNumber, NForm, NFormItem, NButton, NCard,  NUpload, NIcon, NUploadDragger, NDivider} from 'naive-ui'
import { ArchiveOutline } from '@vicons/ionicons5'

export default {
    name: 'NewCollectable',
    components: {
        NDivider, NInput, NInputNumber, NForm, NFormItem, NButton, NCard,  NUpload, NIcon, NUploadDragger, ArchiveOutline
    },
    setup(){
        const fileListLengthRef = ref(0);
        const uploadRef = ref(null);
        return {
            upload: uploadRef,
            fileListLength: fileListLengthRef,
            handleChange(data) {
                fileListLengthRef.value = data.fileList.length;
            }
        }
    },
    data() {
        return {
            collectable: {
                Id: 0,
                Title: null,
                Description: null,
                Pricepaid: null,
                Currentworth: null,
                Size: null,
            },
        }
    },
    methods: {
        submit() {
            console.log(this.uploadRef);
            this.uploadRef.value?.submit();
            api.post('/collectables', this.collectable);
        },
    },
}
</script>

<style>
</style>