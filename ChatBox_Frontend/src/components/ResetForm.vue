<template>
    <form @submit.prevent="handleReset" class="space-y-5">
        <!-- 新密碼欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">New Password</label>
            <input
                v-model="password" type="password" required placeholder="Enter your new password"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-green-400"
            />
        </div>

        <!-- 確認密碼欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Confirm Password</label>
            <input
                v-model="confirmPassword" type="password" required placeholder="Re-enter your new password"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-green-400"
            />
        </div>

        <!-- 驗證碼欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Verification Code</label>
            <input
                v-model="verificationCode" type="text" required placeholder="Enter the code sent to your email"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-green-400"
            />
        </div>

        <!-- 錯誤消息顯示區域 -->
        <div v-if="errorMessage" class="text-red-500 text-sm text-center">{{ errorMessage }}</div>

        <!-- 重設密碼按鈕 -->
        <button type="submit" class="w-full bg-green-500 hover:bg-green-600 text-white font-medium py-2 rounded-xl transition duration-200">
        Reset Password
        </button>
    </form>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { reset } from '@/api/reset'
import errorService from '@/services/errorService'

const props = defineProps<{
    email: string
}>()

const emit = defineEmits<{
    (e: 'success'): void
}>()

const password = ref('')
const confirmPassword = ref('')
const verificationCode = ref('')
const errorMessage = ref('')

async function handleReset() {
    try {
        // 送出重設資料
        const response = await reset({
            email: props.email,
            password: password.value,
            confirmPassword: confirmPassword.value,
            verificationCode: verificationCode.value,
        })

        alert(response)
        emit('success')
    } catch (error) {
        errorMessage.value = errorService.handleError(error) || 'Failed to reset.'
    }
}
</script>