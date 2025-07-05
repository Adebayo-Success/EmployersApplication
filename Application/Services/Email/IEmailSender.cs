using System;

namespace Application.Services.Email;

public interface IEmailSender
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}
