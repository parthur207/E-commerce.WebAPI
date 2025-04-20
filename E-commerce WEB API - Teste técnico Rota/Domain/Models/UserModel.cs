using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models
{
    public class UserModel
    {
        public UserModel(string name, DateTime birthDate, string email, string password, string? phone)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            Phone = phone;
        }

        public string Name{ get; set; }
        public DateTime BirthDate { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }


    }
}
