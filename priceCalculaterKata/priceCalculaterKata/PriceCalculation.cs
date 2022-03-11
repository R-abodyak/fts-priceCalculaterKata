class PriceCalculation
{   private double price;
    private double percentage;
    bool isBefore;
    public double Percentage
    {
        get { return Math.Round(percentage, 2); }
        set { percentage = value; }
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

