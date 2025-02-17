using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateToken(AppUser user, List<string> roles);
    }
}
