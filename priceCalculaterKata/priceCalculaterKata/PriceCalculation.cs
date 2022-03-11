class PriceCalculation
{   private double price;
    private double taxPercentage = 20;
    private double discountPercentage;
    private double upcPercentage;

    public double TaxPercentage
    {
        get { return Math.Round(taxPercentage, 2); }
        set { taxPercentage = value; }
    }
    public double DiscountPercentage
    {
        get { return Math.Round(discountPercentage, 2); }
        set { discountPercentage = value; }

    }
    public double UpcPercentage
    {
        get { return Math.Round(upcPercentage, 2); }
        set { upcPercentage = value; }

    }

    public void updatePrice(double price1)
    {
        price = price1;

    }
    public double calculate(double val ,double price)
    {

        return Math.Round((val / 100) * price ,2);
    }

    


}
