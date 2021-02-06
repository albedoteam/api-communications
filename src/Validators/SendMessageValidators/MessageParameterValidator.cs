using Communications.Api.Models;
using FluentValidation;

namespace Communications.Api.Validators.SendMessageValidators
{
    public class MessageParameterValidator : AbstractValidator<MessageParameter>
    {
        public MessageParameterValidator()
        {
            RuleFor(d => d.Key)
                .NotNull();

            RuleFor(d => d.Value)
                .NotNull();
        }
    }
}