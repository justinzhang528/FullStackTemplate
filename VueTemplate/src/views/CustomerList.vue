<template>
    <div class="customerList">
        <div class="box">
            <h2>Customer List</h2>
            <el-table :data="filterTableData" style="width: 100%" >
                <el-table-column label="Email" prop="email" />
                <el-table-column label="Phone" prop="phone" />
                <el-table-column label="Address" prop="address" />
                <el-table-column align="right">
                    <template #header>
                    <el-input v-model="search" size="small" placeholder="Type to search" />
                    </template>
                    <template #default="scope">
                    <el-button size="small" @click="handleEdit(scope.$index, scope.row)">Edit</el-button>
                    <el-button size="small" type="danger" @click.prevent="handleDelete(scope.$index, scope.row)">Delete</el-button>
                    </template>
                </el-table-column>
            </el-table>
        </div> 
    </div>
</template>
  
<script lang="ts" setup>
    import { $get } from '@/utils/request';
    import { computed, ref, reactive, onMounted } from 'vue'
  
    interface Customer {
        customerId: number
        email: string
        phone: string
        address: string
    }

    const search = ref('')
    const filterTableData = computed(() =>
        tableData.filter(
            (data) =>
            !search.value ||
            data.email.toLowerCase().includes(search.value.toLowerCase())
        )
    )
    const handleEdit = (index: number, row: Customer) => {
        console.log(index, row)
    }

    const handleDelete = (index: number, row: Customer) => {
        console.log(index, row)
        tableData.splice(index, 1)
    }

    const tableData: Customer[] = reactive([])

    // run on page load
    onMounted(()=>{
        $get('/Admin/GetAllCustomer',null).then((res)=>{
            tableData.push(...res.data.customers)
            console.log(tableData)
        })
    })
</script>
  
<style scoped lang="scss">
.customerList{
    width: 100vw;
    height: 100vh;
    background: white;
    display: flex;
    justify-self: center;
    align-items: flex-start;
    padding: 30px 0 0 0;
    background-image: url(../images/background.png);
    background-size: cover;
    .box{
        width: 1200px;
        margin: 0 auto;
        padding: 20px;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0,0,0,.5);
        background: white;
        h2{
            font-size: 20px;
            text-align: center;
            margin-bottom: 20px;
        }
    }
}
</style>