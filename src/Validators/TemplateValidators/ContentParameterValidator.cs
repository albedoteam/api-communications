using Communications.Api.Models;
using FluentValidation;

namespace Communications.Api.Validators.TemplateValidators
{
    public class ContentParameterValidator : AbstractValidator<ContentParameter>
    {
        public ContentParameterValidator()
        {
            RuleFor(c => c.Key)
                .NotEmpty();

            RuleFor(c => c.Value)
                .NotEmpty();
        }
    }
}