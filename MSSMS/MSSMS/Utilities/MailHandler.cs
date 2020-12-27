using System.Net;
using System.Net.Mail;
using Task = System.Threading.Tasks.Task;

namespace MSSMS.Utilities
{
    class MailHandler
    {
        public static async Task sendNewEmailAsync(string senderName, string recipientEmail, string emailSubject, string emailBody)
        {
            var sender = new MailAddress(Properties.Settings.Default.EMAILUsername, "MSSMS " + senderName + " | Jafferjee brothers Tea Division", System.Text.Encoding.UTF8);
            var recipient = new MailAddress(recipientEmail);
            string senderPassword = Properties.Settings.Default.EMAILPassword;
            string subject = emailSubject;
            string body = emailBody;

            var smtp = new SmtpClient
            {
                Host = Properties.Settings.Default.SMTPHost,
                Port = Properties.Settings.Default.SMTPPort,
                EnableSsl = Properties.Settings.Default.SMTPSSL,
                DeliveryMethod = (SmtpDeliveryMethod) Properties.Settings.Default.SMTPDeliveryMethod,
                UseDefaultCredentials = Properties.Settings.Default.SMTPDefaultCredentials,
                Credentials = new NetworkCredential(sender.Address, senderPassword)
            };
            using (var message = new MailMessage(sender, recipient)
            {
                Subject = subject,
                Body = body,
                BodyEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.UTF8
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}
