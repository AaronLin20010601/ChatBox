export default {
    handleError(error: unknown): string {
        let errorMessage = '';

        if (typeof error === 'object' && error !== null && 'response' in error && typeof (error as any).response === 'object') {
            const err = error as {
                response: {
                status: number;
                data?: {
                    message?: string;
                    errors?: Record<string, string[]>;
                };
                };
            };

            const status = err.response.status;

            if (status === 401) {
                return 'User is not authenticated. Please log in again.';
            }

            const { data } = err.response;

            if (data?.errors) {
                // 處理字段驗證錯誤
                for (const key in data.errors) {
                    if (Object.prototype.hasOwnProperty.call(data.errors, key)) {
                        errorMessage += `${data.errors[key].join(', ')}\n`;
                    }
                }
            } else if (data?.message) {
                // 後端錯誤訊息
                errorMessage = data.message;
            } else {
                // 預設錯誤訊息
                errorMessage = 'An error occurred.';
            }
        } else {
            // 其他錯誤
            errorMessage = (error as { message?: string }).message ?? 'An error occurred.';
        }

        return errorMessage;
    },
}