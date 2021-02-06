using System.Text.RegularExpressions;
using Communications.Api.Services.ConfigurationService.Requests;
using FluentValidation;

namespace Communications.Api.Validators.ConfigurationValidators
{
    public class UpdateValidator : AbstractValidator<Update>
    {
        public UpdateValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.Id)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleForEach(c => c.Contracts)
                .NotNull()
                .SetValidator(new ConfigurationContractValidator());
        }
    }
}