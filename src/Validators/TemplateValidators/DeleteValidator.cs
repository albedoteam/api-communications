namespace Communications.Api.Validators.TemplateValidators
{
    using System.Text.RegularExpressions;
    using FluentValidation;
    using Services.TemplateService.Requests;

    public class DeleteValidator : AbstractValidator<Delete>
    {
        public DeleteValidator()
        {
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);

            RuleFor(c => c.Id)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}