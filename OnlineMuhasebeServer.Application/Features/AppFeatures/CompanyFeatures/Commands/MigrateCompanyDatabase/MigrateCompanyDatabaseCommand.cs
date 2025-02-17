using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed record MigrateCompanyDatabaseCommand() : ICommand<MigrateCompanyDatabaseCommandResponse>;
}
