﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, CreateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetByCode(request.Code);
            if (role is not null)
                throw new Exception("Bu rol zaten mevcut.");

            await _roleService.AddAsync(request);
            return new();
        }
    }
}
