import { defineStore } from 'pinia'

// 使用者驗證資料
interface User {
    id: number
    name: string
    email: string
}

export const useAuthStore = defineStore('auth', {
    state: () => ({
        token: null as string | null,
        user: null as User | null,
        isLoggedIn: false,
    }),
    actions: {
        // 用於登入操作
        login(token: string, user: User) {
            this.token = token
            this.user = user
            this.isLoggedIn = true
            localStorage.setItem('token', token)
            localStorage.setItem('user', JSON.stringify(user))
        },
        // 用於登出操作
        logout() {
            this.token = null
            this.user = null
            this.isLoggedIn = false
            localStorage.removeItem('token')
            localStorage.removeItem('user')
        },
        // 從 localStorage 初始化狀態
        initState() {
            const token = localStorage.getItem('token')
            const userStr = localStorage.getItem('user')
            if (token && userStr) {
                try {
                    const user = JSON.parse(userStr)
                    this.token = token
                    this.user = user
                    this.isLoggedIn = true
                } catch (error) {
                    console.error('Failed to parse user from localStorage')
                }
            }
        },
    },
    getters: {
        getUser: (state) => state.user,
        getToken: (state) => state.token,
        isAuthenticated: (state) => state.isLoggedIn,
    },
})