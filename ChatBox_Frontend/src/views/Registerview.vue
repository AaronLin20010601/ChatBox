<template>
    <div class="flex justify-center items-center">
        <div class="w-full max-w-md bg-white/70 backdrop-blur-md border border-white/30 rounded-2xl shadow-xl p-8">
            <h2 class="text-3xl font-semibold text-center text-gray-800 mb-6">
                {{ step === 1 ? "📧 Send Verification Code" : "📝 Register Account" }}
            </h2>

            <!-- 發送驗證碼表單 -->
            <VerificationForm v-if="step === 1" :email="email" :sendCodeApi="sendRegisterVerificationCode"
                @update:email="(val: string) => email = val" @success="step = 2"
            />

            <!-- 註冊表單 -->
            <RegisterForm v-else :email="email" @success="handleSuccess"/>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import VerificationForm from '@/components/VerificationForm.vue'
import RegisterForm from '@/components/RegisterForm.vue'
import { sendRegisterVerificationCode } from '@/api/verification'

const router = useRouter()

const step = ref(1)
const email = ref('')

// 註冊成功後導向 home
function handleSuccess() {
    router.push('/')
}
</script>