namespace TaxCalculator.Shared.Models
{
    public class TaxPayer
    {
        public string FullName { get; set; }
        
        public string SSN { get; set; }

        public double GrossIncome { get; set; }

        public double? CharitySpent { get; set; }
    }
}
