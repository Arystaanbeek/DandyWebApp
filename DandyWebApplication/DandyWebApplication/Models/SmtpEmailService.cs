/*using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using static DandyWebApplication.Controllers.SignUpController;

public class SmtpEmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public SmtpEmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task SendAsync(string to, string subject, string htmlBody)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.FromAddress),
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(to);

        using var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword),
            EnableSsl = true,
        };

        await smtpClient.SendMailAsync(mailMessage);
    }
}

public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string SmtpUsername { get; set; }
    public string SmtpPassword { get; set; }
    public string FromAddress { get; set; }
}
*/