using Communications.Api.Models;
using FluentValidation;

namespace Communications.Api.Validators.ConfigurationValidators
{
    public class ConfigurationContractValidator : AbstractValidator<ConfigurationContract>
    {
        public ConfigurationContractValidator()
        {
            RuleFor(c => c.From)
                .NotNull()
                .SetValidator(new FromAddressValidator());
        }
    }
}