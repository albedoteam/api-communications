namespace Communications.Api.Validators.ConfigurationValidators
{
    using FluentValidation;
    using Models;

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