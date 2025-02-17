using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebe.UnitTest.Features.AppFeatures.CompanyFeatures.Commands;

public sealed class CreateCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> _companyService;
    public CreateCompanyCommandUnitTest()
    {
        _companyService = new();
    }

    [Fact]
    public async Task CompanyShouldBeNull()
    {
        Company company = (await _companyService.Object.GetCompanyByName("Test Company Name"))!;
        company.ShouldBeNull();
    }

    [Fact]
    public async Task CreateCompanyCommandResponseShouldNotBeNull()
    {
        var command = new CreateCompanyCommand(
            Name: "Company Test",
            ServerName: "localhost",
            DatabaseName: "Company2Db",
            UserId: "",
            Password: "");

        var handler = new CreateCompanyCommandHandler(_companyService.Object);

        var response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeNullOrEmpty();
    }
}
