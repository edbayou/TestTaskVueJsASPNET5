<template>
    <div class="container-fluid mt-4">
        <h1 class="h1">Список пользователей</h1>
        <input type="text" placeholder="Имя" v-model="model.name">
        <input type="text" placeholder="Фамилия" v-model="model.surname">
        <button type="submit"
            class="btn btn-primary m-2 fload-end"
            @click="createUserRecord()">
            Добавит/Изменить
        </button>
        <b-row>
            <b-col>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Имя</th>
                            <th>Фамилия</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="record in records" :key="record.id">
                            <td>{{ record.id }}</td>
                            <td>{{ record.name }}</td>
                            <td>{{ record.surname }}</td>

                            <td class="text-right">
                                <a href="#" @click.prevent="updateUserRecord(record)">Редактировать</a> -
                                <a href="#" @click.prevent="deleteUserRecord(record.id)">Удалить</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </b-col>
        </b-row>
    </div>
</template>

<script>
    import api from '@/services/UserRecordsApiService';
    export default {
        data() {
            return {
                loading: false,
                records: [],
                model: {}
            };
        },
        async created() {
        this.getAll()
        },
        methods: {
            async getAll() {
                this.loading = true
                try {
                this.records = await api.getAll()
                } finally {
                this.loading = false
                }
            },
            async updateUserRecord(userRecord) {
                // используем для заполнения даных для редактирования
                this.model = Object.assign({}, userRecord)
            },
            async createUserRecord() {
                const isUpdate = !!this.model.id;
                if (isUpdate) {
                    await api.update(this.model.id, this.model)
                } else {
                    await api.create(this.model)
                }
                // Clear the data inside of the form
                this.model = {}
                // Fetch all records again to have latest data
                await this.getAll()
            },
            async deleteUserRecord(id) {
                if (confirm('Вы точно хотите удалить эту запись?')) {
                // убираем из формы удаленную запись
                    if (this.model.id === id) {
                        this.model = {}
                    }
                    await api.delete(id)
                    await this.getAll()
                }
            }
         }
     }
</script>