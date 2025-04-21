using System.ComponentModel.DataAnnotations;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
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
