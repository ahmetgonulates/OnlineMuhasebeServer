using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Queries;

public sealed class GetAllRolesQueryUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public GetAllRolesQueryUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task GetAllRolesQueryResponseNotBeNull()
    {
        _roleServiceMock.Setup(x=>x.GetAllAsync(new())).ReturnsAsync(new List<AppRole>());
    }
}
