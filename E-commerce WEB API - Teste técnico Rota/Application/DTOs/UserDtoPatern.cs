using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs
{
    public class UserDtoPatern
    {
        public UserDtoPatern(string name, DateTime birthDate, string email, DateTime createdAt, bool isDeleted, string? phone, string address, UserStatusEnum status)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            CreatedAt = createdAt;
            Phone = phone;
            Address = address;
            TransactionsList = new List<(string, int)>();
            Status = status;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? Phone { get; private set; }
        public string Address { get; private set; } 
        public List<(string,int)> TransactionsList { get; set; }
        public UserStatusEnum Status { get; private set; }
    }
}
