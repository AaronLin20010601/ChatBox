<!-- 網頁導覽列 -->
<template>
    <nav class="bg-white/30 backdrop-blur-md border-b border-indigo-200 px-6 py-4 shadow-sm">
        <div class="max-w-6xl mx-auto flex justify-between items-center">
            <h1 class="text-2xl font-semibold text-indigo-700 flex items-center space-x-2">
                🗪 Chat Box
            </h1>
            <ul class="flex space-x-6 text-gray-800 font-medium items-center">
                <!-- 未登入選單 -->
                <template v-if="!isLoggedIn">
                    <li>
                        <RouterLink to="/login" class="hover:text-indigo-600 transition">Login</RouterLink>
                    </li>
                    <li>
                        <RouterLink to="/register" class="hover:text-indigo-600 transition">Register</RouterLink>
                    </li>
                    <li>
                        <RouterLink to="/reset" class="hover:text-indigo-600 transition">Reset Password</RouterLink>
                    </li>
                </template>

                <!-- 已登入選單 -->
                <template v-else>
                    <li>
                        <button @click="logout" class="hover:text-red-500 transition">Logout</button>
                    </li>
                </template>
            </ul>
        </div>
    </nav>
</template>

<script lang="ts" setup>
import { useRouter } from 'vue-router'
import { computed } from 'vue'
import { useAuthStore } from '@/stores/index.ts'

// 初始化 router 和 authStore
const router = useRouter()
const authStore = useAuthStore()

// 登入狀態
const isLoggedIn = computed(() => authStore.isAuthenticated)

// 登出行為
const logout = () => {
    authStore.logout()
    router.push('/')
}
</script>