namespace Communications.Api.Validators.TemplateValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.TemplateService.Requests;

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