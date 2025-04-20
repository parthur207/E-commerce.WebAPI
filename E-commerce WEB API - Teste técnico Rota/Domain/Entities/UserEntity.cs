using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string name, DateTime birthDate, string email, string password, string? phone, UserStatusEnum status)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            Phone = phone;
            Status = status;
            Status = UserStatusEnum.Active;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string? Phone { get; private set; }
        public UserStatusEnum Status { get; private set; }


        public void SetUserStatusÌnative()
        {
            if (Status == UserStatusEnum.Active)
            {
                Status = UserStatusEnum.Inactive;
            }
        }
    }
}
