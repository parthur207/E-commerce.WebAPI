using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models
{
    public class CreateUserModel
    {

        [Required(ErrorMessage ="É obrigatório o informe de seu nome.")]
        public string Name{ get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "É obrigatório o informe de um email.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório o informe de uma senha.")]
        public string Password { get; set; }
        public int? Phone { get; set; }

        [Required(ErrorMessage ="É obrigatório informar seu endereço.")]
        public string Address { get; set; }
    }
}
