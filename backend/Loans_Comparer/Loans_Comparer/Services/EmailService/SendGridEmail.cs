using Loans_Comparer.Helpers;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace Loans_Comparer.Services.EmailService
{
    public interface ISendGridEmail
    {
        Task SendEmailAsync(SendGridDto emailDto);
    }
    public class SendGridEmail : ISendGridEmail
    {
        private readonly ILogger<SendGridEmail> _logger;
        public MessageSenderOptions Options { get; set; }
        public SendGridEmail(IOptions<MessageSenderOptions> options, ILogger<SendGridEmail> logger)
        {
            Options = options.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(SendGridDto emailDto)
        {
            if (string.IsNullOrEmpty(Options.ApiKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(Options.ApiKey, emailDto);
        }

        private async Task Execute(string apiKey, SendGridDto emailDto)
        {
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("david.khodak322@gmail.com"),
                Subject = emailDto.Subject,
                PlainTextContent = emailDto.TextContent,
                HtmlContent = emailDto.HtmlContent
            };
            msg.AddTo(emailDto.To);


            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            var dummy = response.StatusCode;
            var dummy2 = response.Headers;
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {emailDto.To} queued successfully!"
                                   : $"Failure Email to {emailDto.To}");
        }
    }
}
