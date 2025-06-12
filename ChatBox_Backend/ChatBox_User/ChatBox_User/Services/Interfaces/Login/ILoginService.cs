using ChatBox_User.Models.DTOs.Login;

namespace ChatBox_User.Services.Interfaces.Login
{
    public interface ILoginService
    {
        Task<(bool Success, string Message, string? Token, Models.Entities.User? User)> LoginAsync(LoginDTO model);
    }
}
