using TaxCalculator.Shared.Models;

namespace TaxCalculator.Shared.Interfaces
{
    public interface ITaxCalculatorService
    {
        public Taxes CalculateTax(Income income);
    }
}
