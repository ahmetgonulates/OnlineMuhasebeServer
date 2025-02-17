using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Services.AppServices
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateRoleCommand request)
        {
            var role = _mapper.Map<AppRole>(request);
            role.Id = Guid.CreateVersion7().ToString();
            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
        }

        public async Task<IList<AppRole>> GetAllAsync(GetAllRolesQuery request)
        {
            IList<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<AppRole> GetByCode(string code)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Code == code);
            return role;
        }

        public async Task<AppRole> GetByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task UpdateAsync(AppRole request)
        {
            await _roleManager.UpdateAsync(request);
        }
    }
}
