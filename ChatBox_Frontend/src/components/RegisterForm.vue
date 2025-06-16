<template>
    <form @submit.prevent="handleRegister" class="space-y-5">
        <!-- 使用者名稱欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Username</label>
            <input
                v-model="username" type="text" required placeholder="Enter your username"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-400"
            />
        </div>

        <!-- Email 欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Email</label>
            <input
                :value="email" type="email" disabled
                class="w-full px-4 py-2 bg-gray-100 cursor-not-allowed border border-gray-300 rounded-xl shadow-sm"
            />
        </div>

        <!-- 密碼欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Password</label>
            <input
                v-model="password" type="password" required placeholder="Enter your password"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-400"
            />
        </div>

        <!-- 確認密碼欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Confirm Password</label>
            <input
                v-model="confirmPassword" type="password" required placeholder="Re-enter your password"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-400"
            />
        </div>

        <!-- 驗證碼欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Verification Code</label>
            <input
                v-model="verificationCode" type="text" required placeholder="Enter the code sent to your email"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-400"
            />
        </div>

        <!-- 錯誤消息顯示區域 -->
        <div v-if="errorMessage" class="text-red-500 text-sm text-center">{{ errorMessage }}</div>

        <!-- 註冊帳號 -->
        <button type="submit" class="w-full bg-blue-500 hover:bg-blue-600 text-white font-medium py-2 rounded-xl transition duration-200">
        Register
        </button>
    </form>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { register } from '@/api/register'
import errorService from '@/services/errorService'

const props = defineProps<{
    email: string
}>()

const emit = defineEmits<{
    (e: 'success'): void
}>()

const username = ref('')
const password = ref('')
const confirmPassword = ref('')
const verificationCode = ref('')
const errorMessage = ref('')

async function handleRegister() {
    try {
        // 送出註冊資料
        const response = await register({
            username: username.value,
            email: props.email,
            password: password.value,
            confirmPassword: confirmPassword.value,
            verificationCode: verificationCode.value,
        })

        alert(response)
        emit('success')
    } catch (error) {
        errorMessage.value = errorService.handleError(error) || 'Failed to register.'
    }
}
</script>