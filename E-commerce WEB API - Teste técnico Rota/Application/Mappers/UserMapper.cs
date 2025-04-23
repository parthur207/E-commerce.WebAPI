using E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs;
using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Models;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.Mappers
{
    public class UserMapper
    {
        //Model => entity
        //Entity => DTO

        //User
        public static UserEntity ToCreateUserEntity(CreateUserModel Model)
        {
            return new UserEntity
            (
                Model.Name,
                Model.BirthDate,
                Model.Email,
                Model.Password,
                Model.Phone,
                Model.Address
            );
        }
        //User
        public static UserEntity ToUpdateUserDataEntity(int id, UpdateUserDataModel model)
        {
            return new UserEntity
            (
                model.Name,
                model.Phone,
                model.Address
            );
        }


        public static UserDtoPatern ToUserDtoPatern(UserEntity entity)
        {
            return new UserDtoPatern
            {
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                CreatedAt = entity.CreatedAt,
                Phone = entity.Phone,
                Address = entity.Address,
                TransactionsList = entity.Transactions.Select(x => x.ShoppingList.Select(x => (x.Product.ProductName, x.Quantity)).ToList(),
               //UserStatus = entity.UserStatus            
                };
        }
    }
}

