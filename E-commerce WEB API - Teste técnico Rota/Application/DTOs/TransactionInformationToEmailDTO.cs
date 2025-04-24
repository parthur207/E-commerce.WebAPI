namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs
{
    public class TransactionInformationToEmailDTO
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<TransactionProductSimpleDTO> ShoppingList { get; set; }
        public decimal TotalValue { get; set; }
    }

}
