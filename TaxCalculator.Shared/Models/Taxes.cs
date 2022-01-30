namespace TaxCalculator.Shared.Models
{
    public class Taxes
    {
        public double GrossIncome { get; set; }

        public double CharitySpent { get; set; }

        public double IncomeTax { get; set; }

        public double SocialTax { get; set; }

        public double TotalTax => IncomeTax + SocialTax;

        public double NetIncome => GrossIncome - TotalTax;
    }
}
