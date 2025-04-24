
using Ecommerce.Domain.Enuns;
using System.Net;
using System.Numerics;

namespace Ecommerce.Application.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Phone { get; set; }
        public string Address { get; set; }
        public UserStatusEnum UserStatus { get; set; }

        public List<UserTransactionSummaryDTO>? TransactionsList { get; set; }
    }
}
