﻿using System.ComponentModel.DataAnnotations;

namespace ChatBox_User.Models.DTOs.Verification
{
    // 取得驗證碼發送信箱
    public class EmailDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = null!; // email
    }
}
