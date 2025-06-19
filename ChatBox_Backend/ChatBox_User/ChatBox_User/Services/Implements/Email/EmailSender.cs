using Microsoft.Extensions.Options;
using System.Text;
using Newtonsoft.Json;
using ChatBox_User.Settings;
using ChatBox_User.Services.Interfaces.Email;

namespace ChatBox_User.Services.Implements.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly HttpClient _httpClient;
        private readonly MailjetSettings _settings;

        public EmailSender(IHttpClientFactory httpClientFactory, IOptions<MailjetSettings> options)
        {
            _httpClient = httpClientFactory.CreateClient();
            _settings = options.Value;
        }

        public async Task<bool> SendAsync(IEnumerable<string> toEmails, string subject, string htmlBody, string textBody)
        {
            var payload = new
            {
                to = toEmails,
                subject = subject,
                html = htmlBody,
                text = textBody,
                from_email = _settings.SenderEmail,
                from_name = _settings.SenderName
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:8000/email/token", content);
            return response.IsSuccessStatusCode;
        }
    }
}
