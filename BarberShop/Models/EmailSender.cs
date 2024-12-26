using Microsoft.AspNetCore.Identity.UI.Services;

namespace BarberShop.Models
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //email gönderme alanı
            return Task.CompletedTask;
        }
    }
}
