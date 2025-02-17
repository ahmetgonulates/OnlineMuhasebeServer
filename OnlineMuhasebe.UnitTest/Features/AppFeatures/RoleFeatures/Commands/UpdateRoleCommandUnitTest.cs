using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public sealed class UpdateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public UpdateRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _ = _roleServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task AppRoleCodeShouldBeUnique()
    {
        AppRole checkRoleCode = await _roleServiceMock.Object.GetByCode("UCAF.Create");
        checkRoleCode.ShouldBeNull();
    }

    [Fact]
    public async Task UpdateRoleCommandResponseShouldNotBeNull()
    {
        var command = new UpdateRoleCommand(Id: "01951182-dd88-7ece-b8c3-bd76a2bd1552", Code: "UCAF.Create", Name: "ucaf create role");

        _roleServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());

        var handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);

        UpdateRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
