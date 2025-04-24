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


        public static UserDTO ToUserDTO(UserEntity entity)
        {
            var transactionsList = entity.Transactions?
                .SelectMany(t => t.TransactionProducts.Select(tp => new UserTransactionSummaryDTO
                {
                    TransactionId = t.Id,
                    ProductName = tp.Product.ProductName,
                    Category = tp.Product.Category,
                    Quantity = tp.Quantity,
                    TotalPaid = tp.Quantity * tp.Product.Price,
                    TransactionDate = t.TransactionDate,
                    TransactionStatus = t.TransactionStatus
                })).ToList();

            return new UserDTO
            {
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                CreatedAt = entity.CreatedAt,
                Phone = entity.Phone?.ToString(),
                Address = entity.Address,
                UserStatus = entity.UserStatus,
                TransactionsList = transactionsList
            };
        }
    }
}

