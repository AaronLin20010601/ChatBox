using ChatBox_User.Services.Interfaces.Email;
using ChatBox_User.Services.Interfaces.Token;
using ChatBox_User.Services.Interfaces.VerifyCode;
using ChatBox_User.Services.Interfaces.Login;
using ChatBox_User.Services.Interfaces.Register;
using ChatBox_User.Services.Interfaces.Reset;

using ChatBox_User.Services.Implements.Email;
using ChatBox_User.Services.Implements.Token;
using ChatBox_User.Services.Implements.VerifyCode;
using ChatBox_User.Services.Implements.Login;
using ChatBox_User.Services.Implements.Register;
using ChatBox_User.Services.Implements.Reset;

namespace ChatBox_User.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterApplications(this IServiceCollection services)
        {
            // Email Service
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IEmailLogger, EmailLogger>();
            services.AddScoped<IEmailService, EmailService>();

            // Token Service
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            // Verify Code Service
            services.AddScoped<IVerificationCode, VerificationCode>();
            services.AddScoped<IRegisterVerificationService, RegisterVerificationService>();
            services.AddScoped<IResetVerificationService, ResetVerificationService>();

            // Login Service
            services.AddScoped<ILoginService, LoginService>();

            // Register Service
            services.AddScoped<IRegisterService, RegisterService>();

            // Reset Service
            services.AddScoped<IResetPasswordService, ResetPasswordService>();

            return services;
        }
    }
}
