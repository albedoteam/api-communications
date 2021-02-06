using Communications.Api.Models;
using FluentValidation;

namespace Communications.Api.Validators.ConfigurationValidators
{
    public class FromAddressValidator : AbstractValidator<FromAddress>
    {
        public FromAddressValidator()
        {
            RuleFor(f => f.Name)
                .NotEmpty();

            RuleFor(f => f.Address)
                .NotEmpty();
        }
    }
}