using Microsoft.EntityFrameworkCore;
using ChatBox_User.Models;
using ChatBox_User.Models.DTOs.Login;
using ChatBox_User.Services.Interfaces.Login;
using ChatBox_User.Services.Interfaces.Token;

namespace ChatBox_User.Services.Implements.Login
{
    public class LoginService : ILoginService
    {
        private readonly ChatBoxDbContext _context;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginService(ChatBoxDbContext context, IJwtTokenService jwtTokenService)
        {
            _context = context;
            _jwtTokenService = jwtTokenService;
        }

        // 驗證登入資訊並產生 JWT
        public async Task<(bool Success, string Message, string? Token, Models.Entities.User? User)> LoginAsync(LoginDTO model)
        {
            // 檢查 Email 是否存在
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                return (false, "Email not registered.", null, null);
            }

            // 檢查密碼是否正確
            bool passwordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
            if (!passwordValid)
            {
                return (false, "Password incorrect.", null, null);
            }

            // 生成 JWT 驗證碼
            var token = _jwtTokenService.CreateJwtToken(user);
            return (true, "Login successful.", token, user);
        }
    }
}
