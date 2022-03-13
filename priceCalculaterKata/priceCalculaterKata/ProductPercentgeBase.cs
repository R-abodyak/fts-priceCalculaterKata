public class ProductPercentgeBase
{   private double percentage = 0;
    private String type;
    public ProductPercentgeBase(double percentage,String type)
    {
        this.percentage = percentage;
        this.type = type;
    }
   public ProductPercentgeBase() { }
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

    public  virtual double  calculate( double percentage ,double price)
    {

        return Math.Round((percentage / 100) * price, 2);
    }
}