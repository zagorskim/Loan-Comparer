using SendGrid.Helpers.Mail;

namespace Loans_Comparer.Services.EmailService
{
    public class SendGridDto
    {
        public EmailAddress From
        {
            get => new EmailAddress("david.khodak322@gmail.com");
        }
        public string Subject { get; set; }
        public string To { get; set; }
        public string TextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}
