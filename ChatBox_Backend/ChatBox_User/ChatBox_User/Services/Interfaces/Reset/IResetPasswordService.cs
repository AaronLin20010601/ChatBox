using ChatBox_User.Models.DTOs.Reset;

namespace ChatBox_User.Services.Interfaces.Reset
{
    public interface IResetPasswordService
    {
        Task<(bool Success, string Message)> ResetPasswordAsync(ResetDTO model);
    }
}
