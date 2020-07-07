using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;


namespace WebApplication3.Email
{
	//class for sending mails to customers of webalbum. e.g for password reset
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task Execute(string subject, string message, string email)
        {
            var apiKey = "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 ";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("webalbum@somewhere.de", "Webalbum"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message

            };

            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }

        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
