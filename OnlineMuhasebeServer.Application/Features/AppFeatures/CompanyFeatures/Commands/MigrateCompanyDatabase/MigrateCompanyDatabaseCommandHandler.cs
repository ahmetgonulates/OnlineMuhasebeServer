using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateCompanyDatabaseCommandHandler : ICommandHandler<MigrateCompanyDatabaseCommand, MigrateCompanyDatabaseCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabaseCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabaseCommandResponse> Handle(MigrateCompanyDatabaseCommand request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabases();
            return new();
        }
    }
}
