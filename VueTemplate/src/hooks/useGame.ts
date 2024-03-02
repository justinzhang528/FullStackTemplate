import {reactive, computed, toRefs, toRef} from 'vue'

export default function () {
    let games = reactive([
        {id: 1, gameName: 'GTA V', price: 50},
        {id: 2, gameName: 'FIFA 22', price: 60},
        {id: 3, gameName: 'NFS', price: 40}
    ])

    // 轉換成響應式數據，再進行assign
    let {id, gameName, price} = toRefs(games[0])
    let gameName2 = toRef(games[0], 'gameName')

    // 計算屬性，只讀
    let gameTotalPrice = computed(()=> {
        return games.reduce((acc, game)=> acc + game.price, 0)
    })

    return {
        games,
        gameTotalPrice
    }
}