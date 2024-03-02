import { ref, reactive, computed } from 'vue'

export default function () {
    let name = ref('John Doe')
    let age = ref(25)
    let tel = ref('123-456-7890')

    let person = reactive({
        name: 'John Doe',
        age: 25,
        tel: '123-456-7890'
    })

    // 計算屬性，可讀可寫
    let personInfo = computed({
        get(){
            return `Name: ${name.value}, Age: ${age.value}, Tel: ${tel.value}`
        },
        set(val){
            let arr = val.split(',')
            name.value = arr[0]
            age.value = +arr[1]
            tel.value = arr[2]
        }
    })

    return {
        name,
        age,
        tel,
        person,
        personInfo
    }
}