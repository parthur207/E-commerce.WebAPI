using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models.AdminModels
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Insira seu email.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira sua senha.")]
        public string Password { get; set; }
    }
}
