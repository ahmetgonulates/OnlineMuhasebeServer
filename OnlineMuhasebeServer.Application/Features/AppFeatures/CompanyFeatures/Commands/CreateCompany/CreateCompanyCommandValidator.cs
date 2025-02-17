using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(x=>x.DatabaseName).NotNull().WithMessage("Database bilgisi yazilmalidir.");
        RuleFor(x=>x.DatabaseName).NotEmpty().WithMessage("Database bilgisi yazilmalidir.");
        RuleFor(x=>x.ServerName).NotNull().WithMessage("Server bilgisi yazilmalidir.");
        RuleFor(x=>x.ServerName).NotEmpty().WithMessage("Server bilgisi yazilmalidir.");
        RuleFor(x=>x.Name).NotNull().WithMessage("Name bilgisi yazilmalidir.");
        RuleFor(x=>x.Name).NotEmpty().WithMessage("Name bilgisi yazilmalidir.");
    }
}
