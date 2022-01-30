namespace TaxCalculator.Shared.Settings
{
    public abstract class TaxBase : ITax
    {
        protected double taxableIncome;
        protected int taxPercentage;

        public virtual double CalculateTax()
        {
            return taxableIncome * taxPercentage / 100;
        }
    }
}
