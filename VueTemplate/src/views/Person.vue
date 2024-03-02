<template>
    <div class="person">
        <h2>Person Info:</h2>
        <p>Name: {{ person.name }}</p>
        <p>Age: {{ person.age }}</p>
        <button @click="showInfo">Show Info</button>
        <input type="text" v-model="person.name">
        <input type="number" v-model="person.age">
        <input type="tel" v-model="person.tel">
        <hr>
        <h2>Games List:</h2>
        <ol>
            <li v-for="game in games" :key="game.id">
                {{ game.gameName }} - ${{ game.price }}
            </li>
        </ol>
        <p>Total Price: ${{ gameTotalPrice }}</p>
        <input type="number" v-model="games[0].price">
    </div>

</template>

<script lang="ts" setup name="Person">
    // ref => 創建一個響應式數據或對象，必須使用.value訪問
    // reactive => 創建一個響應式對象，可以直接訪問
    // toRefs => 轉換成響應式數據
    import { toRefs, toRef, computed, watch } from 'vue'
    import { $post } from '../utils/request'
    import usePerson from '@/hooks/usePerson'
    import useGame from '@/hooks/useGame'

    const { name, age, tel, person, personInfo } = usePerson()
    const { games, gameTotalPrice } = useGame()

    // 監聽
    watch(person, (newVal, oldVal)=> {
        console.log(`Name changed from ${oldVal.name} to ${newVal.name}`)
    },{deep: true})

    // 方法
    const showInfo = ()=> {
        alert(`Name: ${name.value}, Age: ${age.value}, Tel: ${tel.value}`)
        $post('/Test/Index', person)
            .then((response) => console.log(response.data))
    }
</script>

<style scoped>
    .person {
        background-color: skyblue;
        box-shadow: 0 0 10px;
        border-radius: 10px;
        padding: 20px;
    }
</style>