using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id bilgisi bos olamaz.");
        RuleFor(x=>x.Code).NotEmpty().NotNull().WithMessage("Kod Bod olamaz.");
        RuleFor(x=>x.Name).NotEmpty().NotNull().WithMessage("Name Bod olamaz.");
    }
}
