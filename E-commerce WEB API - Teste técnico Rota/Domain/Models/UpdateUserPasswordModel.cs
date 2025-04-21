namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class UpdateUserPasswordModel
    {

        public string Email { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
