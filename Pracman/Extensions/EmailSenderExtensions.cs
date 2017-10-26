using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Pracman.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string emailBody)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email", emailBody);
        }

        /// <summary>
        ///     Inserts dynamic information into email templates and then returns the email html via a string
        /// </summary>
        /// <param name="env">Hosting information used to get web root path.</param>
        /// <param name="templateName">Name of the template file under wwwroot/email_templates</param>
        /// <param name="headerText">Text to go in the header of the email</param>
        /// <param name="callbackUrl">Special url used to reset password, or verify email address</param>
        /// <returns>string containing email html</returns>
        public static string FormatEmail(IHostingEnvironment env, string templateName, string headerText, string callbackUrl)
        {
            var webRoot = env.WebRootPath;
            var separator = Path.DirectorySeparatorChar.ToString();
            var pathToTemplate = webRoot + separator + "email_templates" + separator + templateName;
            var htmlBody = "";

            using (StreamReader SourceReader = File.OpenText(pathToTemplate))
            {
                htmlBody = SourceReader.ReadToEnd();
            }

            return string.Format(htmlBody, headerText, callbackUrl);
        }
    }
}
