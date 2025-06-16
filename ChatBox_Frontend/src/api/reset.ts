import axios from 'axios'

const API_URL = 'http://localhost:5300/api/reset'

// 重設密碼資料
export interface ResetPayload {
    email: string
    verificationCode: string
    password: string
    confirmPassword: string
}

// 後端回傳訊息
export interface ResetResponse {
    Message: string
}

// 送出重設密碼資料
export const reset = async (payload: ResetPayload): Promise<ResetResponse> => {
    try {
        const response = await axios.post<ResetResponse>(API_URL, payload)
        return response.data
    } catch (error) {
        throw error
    }
}