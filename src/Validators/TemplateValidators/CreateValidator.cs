using System.Text.RegularExpressions;
using Communications.Api.Services.TemplateService.Requests;
using FluentValidation;

namespace Communications.Api.Validators.TemplateValidators
{
    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Name)
                .NotEmpty();

            RuleFor(c => c.ContentPattern)
                .NotEmpty();

            RuleForEach(c => c.ContentParameters)
                .NotNull()
                .SetValidator(new ContentParameterValidator());
        }
    }
}