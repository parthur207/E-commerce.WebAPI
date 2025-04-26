using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models
{

    public class UpdateUserPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório o informe da senha atual.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage ="É obrigatório o informe da nova senha.")]
        public string NewPassword { get; set; }
    }
}
