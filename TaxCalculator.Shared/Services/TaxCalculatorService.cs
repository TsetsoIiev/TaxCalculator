using TaxCalculator.Shared.Interfaces;
using TaxCalculator.Shared.Models;
using TaxCalculator.Shared.Settings;

namespace TaxCalculator.Shared.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public Taxes CalculateTax(Income income)
        {
            var grossIncome = income.GrossIncome;

            if (income.CharitySpent > 0)
            {
                var allowedToSpendOnCharity = grossIncome * TaxationSettings.CharityCauseMaxAllowedPercentage / 100;

                grossIncome = allowedToSpendOnCharity < income.CharitySpent
                    ? grossIncome - allowedToSpendOnCharity
                    : grossIncome - income.CharitySpent;
            }

            if (grossIncome <= TaxationSettings.MinimumTaxableAmmount)
            {
                return new Taxes()
                {
                    GrossIncome = income.GrossIncome,
                    CharitySpent = income.CharitySpent,
                    IncomeTax = 0,
                    SocialTax = 0
                };
            }

            var incomeTax = new IncomeTax(grossIncome).CalculateTax();
            var socialTax = new SocialTax(grossIncome).CalculateTax();

            return new Taxes()
            {
                GrossIncome = income.GrossIncome,
                CharitySpent = income.CharitySpent,
                IncomeTax = incomeTax,
                SocialTax = socialTax
            };
        }
    }
}
