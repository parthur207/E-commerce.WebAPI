using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Enuns;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Numerics;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Application.DTOs
{
    public class UserDtoPatern
    {

        public string Name { get;  set; }
        public DateTime BirthDate { get;  set; }
        public string Email { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public int? Phone { get;  set; }
        public string Address { get;  set; } 
        public List<(string,int)>?TransactionsList { get; set; }
        public UserStatusEnum UserStatus { get; set; }
    }
}
