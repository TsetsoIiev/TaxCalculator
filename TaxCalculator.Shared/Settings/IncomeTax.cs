namespace TaxCalculator.Shared.Settings
{
    public class IncomeTax : TaxBase
    {
        public IncomeTax(double grossIncome)
        {
            taxableIncome = grossIncome - TaxationSettings.MinimumTaxableAmmount;
            taxPercentage = TaxationSettings.IncomeTaxPercentage;
        }
    }
}
