using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x=>x.Code).NotEmpty().NotNull().WithMessage("Kod Bod olamaz.");
        RuleFor(x=>x.Name).NotEmpty().NotNull().WithMessage("Name Bod olamaz.");
    }
}
