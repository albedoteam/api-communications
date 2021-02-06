using Communications.Api.Models;
using FluentValidation;

namespace Communications.Api.Validators.SendMessageValidators
{
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