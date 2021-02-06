using System.Text.RegularExpressions;
using Communications.Api.Services.ConfigurationService.Requests;
using FluentValidation;

namespace Communications.Api.Validators.ConfigurationValidators
{
    public class DeleteValidator : AbstractValidator<Delete>
    {
        public DeleteValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}