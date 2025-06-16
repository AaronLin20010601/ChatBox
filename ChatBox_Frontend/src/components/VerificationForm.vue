<template>
    <form @submit.prevent="handleSendCode" class="space-y-5">
        <!-- Email 欄位 -->
        <div>
            <label class="block text-sm font-medium text-gray-700 mb-1">Email</label>
            <input
                v-model="localEmail" type="email" required placeholder="Enter your email"
                class="w-full px-4 py-2 border border-gray-300 rounded-xl shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-400"
            />
        </div>

        <!-- 錯誤訊息 -->
        <div v-if="errorMessage" class="text-red-500 text-sm text-center">{{ errorMessage }}</div>

        <!-- 發送驗證碼 -->
        <button type="submit" class="w-full bg-blue-500 hover:bg-blue-600 text-white font-medium py-2 rounded-xl transition duration-200">
        Send Verification Code
        </button>
    </form>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import errorService from '@/services/errorService'

const props = defineProps<{
    email: string
    sendCodeApi: (email: string) => Promise<any>
}>()

const emit = defineEmits<{
    (e: 'success'): void
    (e: 'update:email', value: string): void
}>()

// 本地 email 狀態
const localEmail = ref(props.email || '')
const errorMessage = ref('')

watch(() => props.email, (newVal) => {
    localEmail.value = newVal
})

// 發送驗證碼
async function handleSendCode() {
    try {
        const response = await props.sendCodeApi(localEmail.value)
        alert(response)
        emit('update:email', localEmail.value)
        emit('success')
    } catch (error) {
        errorMessage.value = errorService.handleError(error) || 'Failed to send verification code.'
    }
}
</script>