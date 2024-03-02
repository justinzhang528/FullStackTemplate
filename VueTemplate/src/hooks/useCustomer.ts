import type { Customer } from '@/interface/Customer'
import { reactive } from 'vue'
import { $get } from '@/utils/request';

export default function () {
    let tableData: Customer[] = reactive([
    ])

    let getAllCustomer = ()=>{
        $get('/Admin/GetAllCustomer',null).then((res)=>{
            tableData.push(...res.data.customers)
            console.log(tableData)
        })
    }

    return {
        tableData,
        getAllCustomer
    }
}