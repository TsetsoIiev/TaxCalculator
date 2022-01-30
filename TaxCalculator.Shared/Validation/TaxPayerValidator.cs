using FluentValidation;
using TaxCalculator.Shared.Models;

namespace TaxCalculator.Shared.Validation
{
    public class TaxPayerValidator : AbstractValidator<TaxPayer>
    {
        public TaxPayerValidator()
        {
            RuleFor(p => p.FullName)
                .NotNull()
                .Matches(@"^([ \u00c0-\u01ffa-zA-Z'\-])+$")
                .WithMessage("Please enter valid name.");

            RuleFor(p => p.SSN)
                .NotNull()
                .Length(5, 10)
                .Must(x =>
                {
                    return int.TryParse(x, out int ssn);
                })
                .WithMessage("Please enter valid SSN number.");

            RuleFor(p => p.GrossIncome)
                .GreaterThan(0)
                .WithMessage("Gross incomee must be greater than 0.");
        }
    }
}
