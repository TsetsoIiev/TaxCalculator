namespace TaxCalculator.Shared.Models
{
    public class Income
    {
        public Income(double grossIncome, double charitySpent)
        {
            GrossIncome = grossIncome;
            CharitySpent = charitySpent;
        }

        public double GrossIncome { get; set; }

        public double CharitySpent { get; set; }
    }
}
