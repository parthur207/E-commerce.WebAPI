namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class SaleModel
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalValue { get; set; }
        public string Status { get; set; } = string.Empty;

        /*public string PaymentMethod { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryStatus { get; set; } = string.Empty;*/
    }
}
