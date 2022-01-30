namespace TaxCalculator.Shared.Settings
{
    public class SocialTax : TaxBase
    {
        public SocialTax(double grossIncome)
        {
            if (grossIncome > TaxationSettings.SocialTaxMaxTaxableAmmount)
                grossIncome = TaxationSettings.SocialTaxMaxTaxableAmmount;

            taxableIncome = grossIncome - TaxationSettings.MinimumTaxableAmmount;
            taxPercentage = TaxationSettings.SocialTaxPercentage;
        }
    }
}
