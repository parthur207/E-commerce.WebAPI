using System.ComponentModel.DataAnnotations;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class UserLoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
