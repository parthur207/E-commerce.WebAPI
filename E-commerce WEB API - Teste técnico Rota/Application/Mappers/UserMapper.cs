using E_commerce_WEB_API___Teste_técnico_Rota.Application.Interfaces.Admin;
using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
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


        //Admin
        


    }
}

