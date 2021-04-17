namespace Communications.Api.Validators.TemplateValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.TemplateService.Requests;

    public class UpdateValidator : AbstractValidator<Update>
    {
        public UpdateValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

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