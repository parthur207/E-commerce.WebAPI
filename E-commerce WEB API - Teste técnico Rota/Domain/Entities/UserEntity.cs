using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using System.Net;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        //Construtor para atualizar dados do user
        public UserEntity(string name, string? phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }

        //Construtor para criar um novo user
        public UserEntity(string name, DateTime birthDate, string email, string password, string? phone, string address)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
            Transactions=new List<TransactionEntity>();
            UserStatus = UserStatusEnum.Active;
            Role = UserTypeEnum.User;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string? Phone { get; private set; }
        public string Address { get; private set; }
        public List<TransactionEntity> Transactions { get; private set; } //Lista de transações do usuário (Começando nula)
        public UserStatusEnum UserStatus { get; private set; }
        public UserTypeEnum Role { get; private set; }


        public void SetStatus(UserStatusEnum Newstatus)//Admin
        {
            UserStatus = Newstatus;
        }
        public void UpdatePhone(string? newPhone)
        {
            Phone = newPhone;
        }

        public void UpdateAddress(string newAddress)
        {
            Address = newAddress;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

    }
}
