using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces.AuthInterface
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserEntity user);
    }
}
