using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed record CreateRoleCommand(string Name, string Code) : ICommand<CreateRoleCommandResponse>;
}
