<template>
    <form @submit.prevent="loginUser" class="space-y-5">
        <!-- Email 欄位 -->
        <div>
            <label for="email" class="block text-sm font-medium text-gray-700 mb-1">Email</label>
            <input
                type="email" id="email" v-model="email" required placeholder="you@example.com"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-indigo-400 bg-white/90"
            />
        </div>

        <!-- 密碼欄位 -->
        <div>
            <label for="password" class="block text-sm font-medium text-gray-700 mb-1">Password</label>
            <input 
                type="password" id="password" v-model="password" required placeholder="Enter your password"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-indigo-400 bg-white/90"
            />
        </div>

        <!-- 錯誤訊息 -->
        <div v-if="errorMessage" class="text-red-500 text-sm text-center">{{ errorMessage }}</div>

        <!-- 登入按鈕 -->
        <button type="submit" class="w-full bg-indigo-500 hover:bg-indigo-600 text-white font-semibold py-2 rounded-xl transition duration-200">
        Login
        </button>
    </form>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { login } from '@/api/login'
import errorService from '@/services/errorService'

const emit = defineEmits<{
    (e: 'success', payload: { token: string; user: any }): void
}>()

const email = ref('')
const password = ref('')
const errorMessage = ref('')

// 登入處理邏輯
async function loginUser() {
    try {
        const { token, user } = await login(email.value, password.value)
        if (token && user) {
            emit('success', { token, user })
        }
    } catch (error: any) {
        errorMessage.value = errorService.handleError(error) || 'Login failed.'
    }
}
</script>