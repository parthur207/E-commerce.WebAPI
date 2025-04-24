using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Ecommerce.Application.DTOs;
using Ecommerce.Infrastructure.ExternalService.InterfaceNotification;
using Ecommerce.Domain.Attributes;


namespace Ecommerce.Infrastructure.ExternalService
{
    public sealed class NotificationService : AttributesBodyEmail, INotificationInterface
    {
        private const string _smtpHost = "smtp.gmail.com";
        private const int _smtpPort = 587;
        //private const string _smtpUser = $"projetosdotnet@gmail.com";
        private const string _smtpUser = $"parthur207@gmail.com";
        private const string _smtpPass = "yvkl pdcw uxht baob";

        public void SendConfirmationEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName)
        {
            string SubjectComplete = SubjectConfirmation + TransactionData.TransactionId.ToString();
            using (var client = new SmtpClient(_smtpHost, _smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_smtpUser, _smtpPass);

                var mail = new MailMessage();
                mail.From = new MailAddress(_smtpUser);
                mail.To.Add(toEmail);
                mail.Subject = SubjectComplete;
                mail.Body = ConfirmationEmail;
                mail.IsBodyHtml = true;

                client.Send(mail);
            }
        }


        public void SendShippingConfirmationEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName)
        {
            string SubjectComplete = SubjectShippingConfirmation + TransactionData.TransactionId.ToString();
            using (var client = new SmtpClient(_smtpHost, _smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_smtpUser, _smtpPass);

                var mail = new MailMessage();
                mail.From = new MailAddress(_smtpUser);
                mail.To.Add(toEmail);
                mail.Subject = SubjectComplete;
                mail.Body = ShippingConfirmationEmail;
                mail.IsBodyHtml = true;

                client.Send(mail);
            }
        }

        public void SendCanceledEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName)
        {
            string SujectComplete = SubjectShippingCanceled + TransactionData.TransactionId.ToString();
            using (var client = new SmtpClient(_smtpHost, _smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_smtpUser, _smtpPass);

                var mail = new MailMessage();
                mail.From = new MailAddress(_smtpUser);
                mail.To.Add(toEmail);
                mail.Subject = SujectComplete;
                mail.Body = CancellationEmail;
                mail.IsBodyHtml = true;

                client.Send(mail);
            }
        }
    }
}

