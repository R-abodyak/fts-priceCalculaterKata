class PriceCalculation
{   private double price;
    private double percentage;
    //TODO -geter ,seter
    public bool isbefore;
    public String Type;
    public double Percentage
    {
        get { return Math.Round(percentage, 2); }
        set { percentage = value; }
    }
  

    public void updatePrice(double price1)
    {
        price = price1;

    }
    public static double calculate(double val ,double price)
    {

        return Math.Round((val / 100) * price ,2);
    }

    

}


