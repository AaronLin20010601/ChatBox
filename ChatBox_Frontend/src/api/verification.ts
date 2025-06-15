import axios from 'axios'

const API_URL = 'http://localhost:5300/api/verification'

// 後端回傳訊息
export interface VerificationResponse {
    Message: string
}

// 發送註冊驗證碼
export const sendRegisterVerificationCode = async (email: string): Promise<VerificationResponse> => {
    try {
        const response = await axios.post<VerificationResponse>(`${API_URL}/register`, { email })
        return response.data
    } catch (error) {
        throw error
    }
}

// 發送重設密碼驗證碼
export const sendResetVerificationCode = async (email: string): Promise<VerificationResponse> => {
    try {
        const response = await axios.post<VerificationResponse>(`${API_URL}/reset`, { email })
        return response.data
    } catch (error) {
        throw error
    }
}