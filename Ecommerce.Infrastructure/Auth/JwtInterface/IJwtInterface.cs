using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Auth.JwtInterface
{
    public interface IJwtInterface
    {
        string GenerateToken(int UserId, string userType);
    }
}
