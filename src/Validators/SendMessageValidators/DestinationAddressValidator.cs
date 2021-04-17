namespace Communications.Api.Validators.SendMessageValidators
{
    using FluentValidation;
    using Models;

    public class DestinationAddressValidator : AbstractValidator<DestinationAddress>
    {
        public DestinationAddressValidator()
        {
            RuleFor(d => d.Name)
                .NotNull();

            RuleFor(d => d.Address)
                .NotNull();
        }
    }
}