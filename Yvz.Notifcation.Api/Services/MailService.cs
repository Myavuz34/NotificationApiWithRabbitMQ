using MailKit.Net.Smtp;
using MimeKit;
using Yvz.Notification.Models;

namespace Yvz.Notifcation.Api.Services;

public class MailService : IMailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendMail(SubmitCustomer submitCustomer)
    {
        var mail = new MimeMessage();
        var to = new MailboxAddress("User", _configuration["Smtp:to"]);
        mail.To.Add(to);

        var from = new MailboxAddress("Mustfa", _configuration["Smtp:from"]);
        mail.From.Add(from);

        mail.Subject = "Yavuz MassTransit";

        var bodyBuilder = new BodyBuilder
        {
            TextBody = submitCustomer.ToString()
        };
        mail.Body = bodyBuilder.ToMessageBody();

        var smtp = new SmtpClient();
        smtp.Connect(_configuration["Smtp:link"], 587, false);
        smtp.Authenticate(_configuration["Smtp:username"], _configuration["Smtp:password"]);

        smtp.Send(mail);
        smtp.Disconnect(true);
        smtp.Dispose();
    }
}