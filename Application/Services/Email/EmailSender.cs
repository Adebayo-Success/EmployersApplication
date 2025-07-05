namespace Application.Services.Email;

using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Data.Configuration;
using Data.Model;
using Microsoft.Extensions.Options;

public class EmailSender : IEmailSender
{
    private readonly Email _mail;

    public EmailSender(IOptions<Email> mailSettings)
    {
        _mail = mailSettings.Value;
    }


    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var message = new MailMessage
        {
            From = new MailAddress(_mail.FromEmail, _mail.Username),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        message.To.Add(toEmail);

        using var smtp = new SmtpClient
        {
            Host = _mail.SmtpServer,
            Port = _mail.Port,
            EnableSsl = true,
            Credentials = new NetworkCredential(_mail.Username, _mail.Password),
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false
        };


        smtp.TargetName = "STARTTLS/smtp.mailtrap.io";

        await smtp.SendMailAsync(message);
    }
}


