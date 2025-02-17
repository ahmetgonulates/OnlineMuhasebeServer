using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleCommand request);
        Task DeleteByIdAsync(string id);
        Task UpdateAsync(AppRole request);
        Task<IList<AppRole>> GetAllAsync(GetAllRolesQuery request);
        Task<AppRole> GetByIdAsync(string id);
        Task<AppRole> GetByCode(string code);
    }
}
