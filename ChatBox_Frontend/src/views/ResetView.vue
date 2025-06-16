<template>
    <div class="flex justify-center items-center">
        <div class="w-full max-w-md bg-white/70 backdrop-blur-md border border-white/30 rounded-2xl shadow-xl p-8">
            <h2 class="text-3xl font-semibold text-center text-gray-800 mb-6">
                {{ step === 1 ? "📧 Send Verification Code" : "🔒 Reset Password" }}
            </h2>

            <!-- 發送驗證碼表單 -->
            <VerificationForm v-if="step === 1" :email="email" :sendCodeApi="sendResetVerificationCode"
                @update:email="(val: string) => email = val" @success="step = 2"
            />

            <!-- 重設密碼表單 -->
            <ResetForm v-else :email="email" @success="handleSuccess"/>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import VerificationForm from '@/components/VerificationForm.vue'
import ResetForm from '@/components/ResetForm.vue'
import { sendResetVerificationCode } from '@/api/verification'

const router = useRouter()

const step = ref(1)
const email = ref('')

// 重設密碼成功後導向 home
function handleSuccess() {
    router.push('/')
}
</script>