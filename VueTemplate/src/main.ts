// 引用createApp用於創建應用
import { createApp } from 'vue'

// 引用ElementPlus
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'

// 引用App根組建
import App from './App.vue'

// 導入路由器
import router from './router'

createApp(App)
.use(ElementPlus)
.use(router)
.mount('#app')