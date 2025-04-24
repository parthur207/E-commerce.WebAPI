using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Infrastructure.ExternalService.InterfaceNotification
{
    public interface INotificationInterface
    {
        void SendShippingConfirmationEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName);
        void SendCanceledEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName);
        void SendConfirmationEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName);
    }
}
