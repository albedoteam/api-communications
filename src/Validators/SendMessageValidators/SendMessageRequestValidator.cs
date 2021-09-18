namespace Communications.Api.Validators.SendMessageValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.CommunicationService.Requests;

    public class SendMessageRequestValidator : AbstractValidator<SendMessageRequest>
    {
        public SendMessageRequestValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.TemplateId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Subject)
                .NotNull();

            RuleForEach(c => c.Destinations)
                .NotNull()
                .SetValidator(new DestinationAddressValidator());

            RuleForEach(c => c.Parameters)
                .NotNull()
                .SetValidator(new MessageParameterValidator());
        }
    }
}