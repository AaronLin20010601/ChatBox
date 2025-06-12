using ChatBox_User.Models.DTOs.Register;

namespace ChatBox_User.Services.Interfaces.Register
{
    public interface IRegisterService
    {
        Task<(bool Success, string Message)> RegisterAsync(RegisterDTO model);
    }
}
