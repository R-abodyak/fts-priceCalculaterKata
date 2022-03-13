public class ProductPercentgeBase
{   private double percentage = 0;
    private String type;
       
    public double Percentage
    {
        get { return Math.Round(percentage, 2); }
        set { percentage = value; }
    }
    public String Type
    {
        get { return type; }
        set { type = value; }
    }

    public  double calculate( double price)
    {

        return Math.Round((percentage / 100) * price, 2);
    }
}