﻿using ChatBox_User.Services.Interfaces.VerifyCode;

namespace ChatBox_User.Services.Implements.VerifyCode
{
    public class VerificationCode : IVerificationCode
    {
        // 生成隨機的驗證碼
        public string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
