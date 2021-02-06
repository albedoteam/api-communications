using System.Text.RegularExpressions;
using Communications.Api.Services.ConfigurationService.Requests;
using FluentValidation;

namespace Communications.Api.Validators.ConfigurationValidators
{
    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.Name)
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