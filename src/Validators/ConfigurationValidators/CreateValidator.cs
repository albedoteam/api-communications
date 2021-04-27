namespace Communications.Api.Validators.ConfigurationValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.ConfigurationService.Requests;

    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.DisplayName)
                .NotEmpty();

            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleForEach(c => c.Contracts)
                .NotNull()
                .SetValidator(new ConfigurationContractValidator());
        }
    }
}