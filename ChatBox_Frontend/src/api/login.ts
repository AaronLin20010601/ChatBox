import axios from 'axios'

const API_URL = 'http://localhost:5300/api/login'

// 使用者資料
export interface LoginUser {
    id: number
    username: string
    email: string
}

// 後端回傳資料
export interface LoginResponse {
    message: string
    token: string
    user: LoginUser
}

// 發送登入請求到後端並獲取 JWT
export const login = async (email: string, password: string): Promise<LoginResponse> => {
    try {
        const response = await axios.post<LoginResponse>(API_URL, { email, password })
        return response.data
    } catch (error) {
        throw error
    }
}