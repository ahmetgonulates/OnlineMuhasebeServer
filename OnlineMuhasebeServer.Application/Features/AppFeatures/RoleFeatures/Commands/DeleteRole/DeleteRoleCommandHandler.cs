using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, DeleteRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleService.GetByIdAsync(request.Id);
            if (role is null)
                throw new Exception("Role Bulunamadi.");
            await _roleService.DeleteByIdAsync(role.Id);
            return new();
        }
    }
}
