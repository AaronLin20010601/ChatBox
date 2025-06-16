<template>
    <div class="flex justify-center items-center">
        <div class="w-full max-w-md bg-white/70 backdrop-blur-md border border-white/30 rounded-2xl shadow-xl p-8">
            <h2 class="text-3xl font-semibold text-center text-gray-800 mb-6">
                🔐 Login to Chat Box
            </h2>

            <!-- 登入表單 -->
            <LoginForm @success="handleSuccess" />
        </div>
    </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
import { useAuthStore } from '@/stores/index.ts'
import LoginForm from '@/components/LoginForm.vue'

// 登入成功後進入聊天室首頁
const router = useRouter()
const authStore = useAuthStore()

function handleSuccess({ token, user }: { token: string; user: any }) {
    authStore.login(token, user)
    router.push('/chat')
}
</script>