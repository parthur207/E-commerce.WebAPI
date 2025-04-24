using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;


namespace E_commerce_WEB_API___Teste_técnico_Rota.Infrastructure.AuthenticationService
{
    public sealed class NotificationService
    {
        private const string _smtpHost = "smtp.gmail.com";
        private const int _smtpPort = 587;
        //private const string _smtpUser = $"projetosdotnet@gmail.com";
        private const string _smtpUser = $"parthur207@gmail.com";
        private const string _smtpPass = "yvkl pdcw uxht baob";
        private const string Suject = "Confirmação de Compra - Pedido nº ";


        public void SendEmail(string toEmail, TransactionInformationToEmailDTO TransactionData, string UserName)
        {

            string body = $@"
    <html>
        <body style='font-family: Arial, sans-serif;'>
            <h2 style='color: #2c3e50;'>Compra confirmada com sucesso!</h2>
            <p>Olá <strong>{TransactionData.UserName}</strong>,</p>
            <p>Obrigado por sua compra! Seu pedido <strong>nº {TransactionData.TransactionId + DateTime.Now.Date.ToString()}</strong> foi confirmado com sucesso em {TransactionData.TransactionDate.Date} as {TransactionData.TransactionDate.Hour}<strong></strong>.</p>

            <h3>Detalhes do Pedido:</h3>
            <ul>
                <li>Produto: {TransactionData.ShoppingList}
                <li>Quantidade: {TransactionData}</li>
                <li>Valor Total: R$ {TransactionData.TotalValue}</li>
                <li>Forma de Pagamento: ...</li>
            </ul>

            <p>Você receberá uma nova notificação quando o pedido for enviado.</p>

            <p>Atenciosamente,<br><strong>Equipe Projeto E-Commerce .NET</strong></p>

            <hr>
            <small style='color: gray;'>Este é um e-mail automático. Por favor, não responda.</small>
        </body>
    </html>
";


            string SujectComplete = Suject + TransactionData.TransactionId.ToString();
            using (var client = new SmtpClient(_smtpHost, _smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_smtpUser, _smtpPass);

                var mail = new MailMessage();
                mail.From = new MailAddress(_smtpUser);
                mail.To.Add(toEmail);
                mail.Subject = SujectComplete;
                mail.Body = body;
                mail.IsBodyHtml = true;

                client.Send(mail);
            }
        }
    }
}

