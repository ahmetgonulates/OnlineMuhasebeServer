using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, UpdateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetByIdAsync(request.Id);
            if (role is null)
                throw new Exception("Role Bulunamadi.");

            if (role.Code != request.Code)
            {
                var checkCode = await _roleService.GetByCode(request.Code);
                if (checkCode is not null)
                    throw new Exception("Bu kod daha once kaydedilmis.");
            }

            role.Name = request.Name;
            role.Code = request.Code;
            await _roleService.UpdateAsync(role);
            return new();
        }
    }
}
