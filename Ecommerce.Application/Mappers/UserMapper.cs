
using Ecommerce.Application.DTOs;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Models;

namespace Ecommerce.Application.Mappers
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
            var transactionsList = entity.TransactionsList?
                .SelectMany(t => t.TransactionProductsList.Select(tp => new UserTransactionSummaryDTO
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
                Phone = entity.Phone?.ToString(),
                Address = entity.Address,
                UserStatus = entity.UserStatus,
                TransactionsList = transactionsList
            };
        }
    }
}

