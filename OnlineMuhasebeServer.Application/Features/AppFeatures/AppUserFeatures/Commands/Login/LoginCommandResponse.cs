namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Commands.Login
{
    public sealed record LoginCommandResponse(string token, string email, string userId, string nameLastName);
}
