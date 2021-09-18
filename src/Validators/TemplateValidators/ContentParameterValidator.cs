namespace Communications.Api.Validators.TemplateValidators
{
    using FluentValidation;
    using Models;

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