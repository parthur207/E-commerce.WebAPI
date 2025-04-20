using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class CreateUserModel
    {
        public string Name{ get; set; }
        public DateTime BirthDate { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }

    }
}
