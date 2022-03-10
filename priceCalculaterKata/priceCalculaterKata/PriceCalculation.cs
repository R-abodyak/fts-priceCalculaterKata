class PriceCalculation
{   private double price;
    private double taxPercentage = 20;
    private double discountPercentage;
  

    public double TaxPercentage
    {
        get { return Math.Round(taxPercentage, 2); }
        set { taxPercentage = value; }
    }
    public double DiscountPercentage
    {
        get { return Math.Round(taxPercentage, 2); }
        set { discountPercentage = value; }

    }

    public void updatePrice(double price1)
    {
        price = price1;

    }
    public double calculateTaxAmount()
    {

        return Math.Round((TaxPercentage / 100) * price, 2);
    }

    public double calculateDiscountAmount()
    {

        return Math.Round((discountPercentage / 100) * price, 2);
    }
    


}
