﻿using System.Security.Principal;

namespace ChatBox_User.Models.Entities
{
    // 使用者
    public class User
    {
        public int Id { get; set; } // 主鍵
        public string Username { get; set; } = null!; // 用戶名
        public string Email { get; set; } = null!; // email
        public string PasswordHash { get; set; } = null!; // 加密密碼
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // 建立時間
    }
}
