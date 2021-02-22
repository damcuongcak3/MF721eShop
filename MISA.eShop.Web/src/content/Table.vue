<template>
    <table>
        <thead>
            <th></th>
        </thead>
        <tbody>
            <tr v-for="(item, index) in data" :key="item.EmployeeCode">
                <td>{{index +1}}</td>
                
            </tr>
        </tbody>
    </table>
</template>
<script>
export default {
    name: 'Table',
    props:{
    data: {

            type: Object,
            default: null,
    }
    },
    data() {
        return {
            
        }
    },
    
}
</script>
<style scoped>
table{
    border-color: red;
}
</style>