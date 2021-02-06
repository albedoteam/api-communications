using System.Text.RegularExpressions;
using Communications.Api.Services.ConfigurationService.Requests;
using FluentValidation;

namespace Communications.Api.Validators.ConfigurationValidators
{
    public class GetValidator : AbstractValidator<Get>
    {
        public GetValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .Matches("^[0-9a-fA-F]{24}$", RegexOptions.IgnoreCase);
        }
    }
}