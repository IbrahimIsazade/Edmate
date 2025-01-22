using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.AccountModule.Commands.RefreshTokenCommand
{
    internal class RefreshTokenValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenValidator() 
        {
            RuleFor(x => x.AccessToken).NotNull().WithMessage(x => $"{nameof(x.AccessToken)} cant be null");
            RuleFor(x => x.RefreshToken).NotNull().WithMessage(x => $"{nameof(x.RefreshToken)} cant be null");
        }
    }
}
