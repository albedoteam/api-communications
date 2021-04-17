namespace Communications.Api.Validators.ConfigurationValidators
{
    using FluentValidation;
    using Models;

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