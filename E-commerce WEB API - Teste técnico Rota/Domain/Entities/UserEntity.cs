using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System.Net;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string name, DateTime birthDate, string email, string password, string? phone, string address, UserStatusEnum status)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
            Status = UserStatusEnum.Active;
            Transactions=new List<TransactionEntity>();
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string? Phone { get; private set; }
        public string Address { get; private set; }
        public UserStatusEnum Status { get; private set; }
        public List<TransactionEntity> Transactions { get; private set; } // Lista de transações do usuário (Começando nula)

        public void SetUserStatusInative()
        {
            if (Status == UserStatusEnum.Active)
            {
                Status = UserStatusEnum.Inactive;
            }
        }
    }
}
