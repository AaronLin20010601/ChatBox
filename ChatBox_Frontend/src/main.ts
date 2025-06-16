import './assets/tailwind.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import axios from 'axios'
import router from './router'
import { useAuthStore } from './stores'
import App from './App.vue'

const app = createApp(App)

app.use(createPinia())

app.use(router)

app.config.globalProperties.$http = axios

const authStore = useAuthStore()
authStore.initState()

app.mount('#app')