import axios from 'axios'

const API_URL = 'http://localhost:5300/api/register'

// 註冊資料
export interface RegisterPayload {
    email: string
    verificationCode: string
    username: string
    password: string
    confirmPassword: string
}

// 後端回傳訊息
export interface RegisterResponse {
    Message: string
}

// 送出註冊資料
export const register = async (payload: RegisterPayload): Promise<RegisterResponse> => {
    try {
        const response = await axios.post<RegisterResponse>(API_URL, payload)
        return response.data
    } catch (error) {
        throw error
    }
}