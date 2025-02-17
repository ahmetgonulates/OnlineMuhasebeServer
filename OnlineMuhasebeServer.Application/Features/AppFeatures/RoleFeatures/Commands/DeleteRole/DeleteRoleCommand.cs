using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed record DeleteRoleCommand(string Id) : ICommand<DeleteRoleCommandResponse>;
}
