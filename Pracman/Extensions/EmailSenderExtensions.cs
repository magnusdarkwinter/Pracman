using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Pracman.Services;

namespace Pracman.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string emailBody)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email", emailBody);
        }
    }
}
