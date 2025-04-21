using System.ComponentModel.DataAnnotations;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{

    //Isso pode ser uma vulnerabilidade. Verificar depois..
    public class UpdateUserPasswordModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
