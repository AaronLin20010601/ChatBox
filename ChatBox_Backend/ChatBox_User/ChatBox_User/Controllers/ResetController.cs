using Microsoft.AspNetCore.Mvc;
using ChatBox_User.Models.DTOs.Reset;
using ChatBox_User.Services.Interfaces.Reset;

namespace ChatBox_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetController : BaseApiController
    {
        private readonly IResetPasswordService _resetService;

        public ResetController(IResetPasswordService resetService)
        {
            _resetService = resetService;
        }

        // 重設密碼
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetDTO model)
        {
            if (!ModelState.IsValid)
            {
                return ModelStateErrorResponse();
            }

            var result = await _resetService.ResetPasswordAsync(model);
            return result.Success ? Ok(result.Message) : BadRequest(new { Message = result.Message });
        }
    }
}
