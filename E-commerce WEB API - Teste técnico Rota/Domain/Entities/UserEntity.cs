using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Roles;
using System;
using System.Collections.Generic;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        public UserEntity(string name, int?phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;  
        }
        
        public UserEntity(string name, DateTime birthDate, string email, string password, int? phone, string address)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
            TransactionsList = new List<TransactionEntity>();
            UserStatus = UserStatusEnum.Active;
            Role = UsersRoles.User;
        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int? Phone { get; private set; }
        public string Address { get; private set; }

        public List<TransactionEntity> TransactionsList { get; private set; }

        public UserStatusEnum UserStatus { get; private set; }
        public string Role { get; private set; }

        public void SetUserStatusToActive()
        {
            UserStatus = UserStatusEnum.Active;
        }

        public void SetUserStatusToInactive()
        {
            UserStatus = UserStatusEnum.Inactive;
        }

        public void UpdatePhone(int? newPhone)
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
