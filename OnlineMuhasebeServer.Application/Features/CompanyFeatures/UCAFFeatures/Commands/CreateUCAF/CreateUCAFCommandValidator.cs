using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

public sealed class CreateUCAFCommandValidator : AbstractValidator<CreateUCAFCommand>
{
    public CreateUCAFCommandValidator()
    {
        RuleFor(x=>x.Code).NotEmpty().NotNull().WithMessage("Kod bos olamaz");
        RuleFor(x=>x.Code).MinimumLength(4).WithMessage("En az 4 karakter olmali.");
        RuleFor(x=>x.Name).NotEmpty().NotNull().WithMessage("Name alani bos olamaz.");
        RuleFor(x=>x.CompanyId).NotNull().NotEmpty().WithMessage("CompanyId bos olamaz");
        RuleFor(x=>x.Type).NotNull().NotEmpty().WithMessage("Type bos olamaz");
        RuleFor(x=>x.Type).MaximumLength(1).WithMessage("Maksimum 1 karakter olmali");
    }
}
