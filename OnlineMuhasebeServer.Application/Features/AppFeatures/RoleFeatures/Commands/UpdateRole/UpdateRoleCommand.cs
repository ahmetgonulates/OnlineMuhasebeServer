using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
    public sealed record UpdateRoleCommand(string Id, string Code, string Name) : ICommand<UpdateRoleCommandResponse>;
}
