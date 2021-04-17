namespace Communications.Api.Validators.SendMessageValidators
{
    using FluentValidation;
    using Models;

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