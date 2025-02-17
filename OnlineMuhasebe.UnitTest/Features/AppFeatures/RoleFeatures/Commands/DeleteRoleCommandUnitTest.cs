using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public sealed class DeleteRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public DeleteRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _ = _roleServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task DeleteRoleCommandResponseShouldNotBeNull()
    {
        DeleteRoleCommand command = new DeleteRoleCommand("01951182-dd88-7ece-b8c3-bd76a2bd1552");

        _roleServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new AppRole());

        var handler = new DeleteRoleCommandHandler(_roleServiceMock.Object);

        DeleteRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
