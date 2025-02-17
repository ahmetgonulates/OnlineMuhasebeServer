using MediatR;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
{
    private readonly ICompanyService _companyService;

    public CreateCompanyCommandHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company? company = await _companyService.GetCompanyByName(request.Name);
        if(company is not null)
            throw new Exception("Bu sirket adi zaten mevcut.");

        await _companyService.CreateCompany(request, cancellationToken);
        return new();
    }
}