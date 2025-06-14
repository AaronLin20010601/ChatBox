﻿namespace ChatBox_User.Services.Interfaces.Email
{
    public interface IEmailSender
    {
        Task<bool> SendAsync(IEnumerable<string> toEmails, string subject, string htmlBody, string textBody);
    }
}
