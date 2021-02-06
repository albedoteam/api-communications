using System.Text.RegularExpressions;
using Communications.Api.Services.TemplateService.Requests;
using FluentValidation;

namespace Communications.Api.Validators.TemplateValidators
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

            RuleFor(c => c.ContentPattern)
                .NotEmpty();

            RuleForEach(c => c.ContentParameters)
                .NotNull()
                .SetValidator(new ContentParameterValidator());
        }
    }
}