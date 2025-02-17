using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebe.UnitTest.Features.AppFeatures.RoleFeatures.Commands
{
    public sealed class CreateRoleCommandUnitTest
    {
        private readonly Mock<IRoleService> _roleServiceMock;

        public CreateRoleCommandUnitTest()
        {
            _roleServiceMock = new();
        }

        [Fact]
        public async Task AppRoleShouldBeNull()
        {
            AppRole appRole = await _roleServiceMock.Object.GetByCode("UCAF.Create");
            appRole.ShouldBeNull();
        }

        [Fact]
        public async Task CreateRoleCommandResponseShouldNotBeNull()
        {
            var command = new CreateRoleCommand(
                Code: "UCAF.Create",
                Name: "Hesap plani kayit etme");

            var handler = new CreateRoleCommandHandler(_roleServiceMock.Object);

            CreateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
