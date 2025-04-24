using Ecommerce.Application.DTOs;

namespace Ecommerce.Infrastructure.ExternalService.InterfaceNotification
{
    public interface INotificationInterface
    {
        void SendShippingConfirmationEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName);
        void SendCanceledEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName);
        void SendConfirmationEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName);
    }
}
