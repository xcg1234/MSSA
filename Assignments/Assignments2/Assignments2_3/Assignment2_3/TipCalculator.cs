public class TipCalculator
{
    public decimal BillAmount { get; set; }
    public decimal TipPercentage { get; set; }
    public TipCalculator(decimal billAmount, decimal tipPercentage)

    {
        BillAmount = billAmount;
        TipPercentage = tipPercentage;
    }
    public decimal CalculateTip()
    {
        if (BillAmount < 0)
        {
            throw new ArgumentException("Bill amount cannot be negative.");
        }

        if (TipPercentage < 0)
        {
            throw new ArgumentException("Tip percentage cannot be negative.");
        }

        return BillAmount * (TipPercentage / 100);
    }
}
