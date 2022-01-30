using TaxCalculator.Shared.Interfaces;
using TaxCalculator.Shared.Models;

namespace TaxCalculator.Tests
{
    public class TaxObj
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        private readonly Income _model;

        public TaxObj(ITaxCalculatorService taxCalculatorService, Income model)
        {
            _taxCalculatorService = taxCalculatorService;
            _model = model;
        }

        public Taxes Calculate()
        {
            return _taxCalculatorService.CalculateTax(_model);
        }
    }
}
