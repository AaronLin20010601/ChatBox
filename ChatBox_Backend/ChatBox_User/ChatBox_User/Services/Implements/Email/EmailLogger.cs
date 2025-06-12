using ChatBox_User.Models;
using ChatBox_User.Models.Entities;
using ChatBox_User.Services.Interfaces.Email;

namespace ChatBox_User.Services.Implements.Email
{
    public class EmailLogger : IEmailLogger
    {
        private readonly ChatBoxDbContext _context;

        public EmailLogger(ChatBoxDbContext context)
        {
            _context = context;
        }

        // email 傳送紀錄
        public async Task LogAsync(IEnumerable<string> toEmails, string subject, string body, bool isSuccess)
        {
            // 將郵件記錄存入資料庫
            var emailLog = new EmailLog
            {
                ToEmail = string.Join(",", toEmails),
                Subject = subject,
                Body = body,
                IsSuccess = isSuccess,
                SentAt = DateTime.UtcNow
            };

            _context.EmailLogs.Add(emailLog);
            await _context.SaveChangesAsync();
        }
    }
}
