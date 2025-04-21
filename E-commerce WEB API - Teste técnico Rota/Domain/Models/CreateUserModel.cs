using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System.ComponentModel.DataAnnotations;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class CreateUserModel
    {
        [Required]
        public string Name{ get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
