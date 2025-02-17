using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Commands.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.EmailOrUserName).NotNull().WithMessage("Mail ya da kullanici adi yazmalisiniz.");
            RuleFor(x => x.EmailOrUserName).NotEmpty().WithMessage("Mail ya da kullanici adi yazmalisiniz.");
            RuleFor(x => x.Password).NotNull().WithMessage("Parola bilgisi bos olamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola bilgisi bos olamaz.");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Parola Min 6 karakter olmali.");
            RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("En az 1 buyuk harf icermeli.");
            RuleFor(x => x.Password).Matches("[a-z]").WithMessage("En az 1 kucuk harf icermeli.");
            RuleFor(x => x.Password).Matches("[0-9]").WithMessage("En az 1 rakam icermeli.");
            RuleFor(x => x.Password).Matches("[a-zA-Z-0-9]").WithMessage("En az 1 ozel karakter icermeli.");
        }
    }
}
