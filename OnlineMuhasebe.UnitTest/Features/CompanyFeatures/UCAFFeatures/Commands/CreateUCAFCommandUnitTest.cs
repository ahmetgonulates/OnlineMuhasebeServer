using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebe.UnitTest.Features.CompanyFeatures.UCAFFeatures.Commands;

public sealed class CreateUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _ucafService;
    public CreateUCAFCommandUnitTest()
    {
        _ucafService = new();
    }

    [Fact]
    public async Task UCAFShouldBeNull()
    {
        var ucaf = await _ucafService.Object.GetByCode("100.01.001");
        ucaf.ShouldBeNull();
    }

    [Fact]
    public async Task CreateUCAFCommandResponseShouldNotBeNull()
    {
        var command = new CreateUCAFCommand("100.01.001", "TL Kasa", "M", "01951182-dd88-7ece-b8c3-bd76a2bd1552");
        var handler = new CreateUCAFCommandHandler(_ucafService.Object);
        var response = await handler.Handle(command,default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
