class ProductPercentge
{  
    private double percentage=0;
    //TODO -geter ,seter
    public bool isbefore;
    public String Type;
    public double Percentage
    {
        get { return Math.Round(percentage, 2); }
        set { percentage = value; }
    }
  

    public static double calculate(double val ,double price)
    {

        return Math.Round((val / 100) * price ,2);
    }

    

}


