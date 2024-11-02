using Application.Services;
using Domain.Configurations;
using Microsoft.Extensions.Options;
using Services.Registration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace Services
{
    [SingletonLifeTime]
    public class EmailService : SmtpClient, IEmailService
    {
        private readonly EmailConfiguration options;

        public EmailService(IOptions<EmailConfiguration> options)
        {
            this.options = options.Value;

            Host = this.options.Host;
            Port = this.options.Port;
            EnableSsl = this.options.EnableSsl;
            Credentials = new NetworkCredential(this.options.UserName, this.options.Password);
        }

        public async Task SendEmail(SendEmailRequest request)
        {
            using (var message = new MailMessage())
            {
                request.To = "akamran@code.edu.az";
                message.Subject = request.Subject;
                message.Body = request.Body;
                message.IsBodyHtml = true;
                message.From = new MailAddress(options.UserName, options.DisplayName);

                message.To.Add(request.To);

                //src=('|")cid:[^'"]*('|")

                var matches = Regex.Matches(message.Body, @"src=('|"")cid:(?<contentId>[^'""]*)('|"")");

                if (matches.Any())
                {
                    var avHtml = AlternateView.CreateAlternateViewFromString(message.Body, Encoding.Unicode, MediaTypeNames.Text.Html);
                    foreach (Match match in matches)
                    {
                        var contentId = match.Groups["contentId"].Value;
                        var inlineImage = new LinkedResource(Path.Combine("wwwroot", "email-templates", contentId), MediaTypeNames.Image.Jpeg);
                        inlineImage.ContentId = contentId;
                        avHtml.LinkedResources.Add(inlineImage);
                    }
                    message.AlternateViews.Add(avHtml);
                }




                await SendMailAsync(message);
            }
        }

        public Task SendEmailQueue(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
