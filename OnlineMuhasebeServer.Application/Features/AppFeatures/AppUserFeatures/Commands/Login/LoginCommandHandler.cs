using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<AppUser> _userManager;

        public LoginCommandHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.Where(x => x.Email == request.EmailOrUserName || x.UserName == request.EmailOrUserName).FirstOrDefaultAsync();
            if (user is null)
                throw new Exception("Kullanici bulunamadi.");

            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!checkUser)
                throw new Exception("Parola Hatali.");

            LoginCommandResponse response = new(await _jwtProvider.CreateToken(user, new()), user.Email, user.Id, user.NameLastName);
            return response;
        }
    }
}
