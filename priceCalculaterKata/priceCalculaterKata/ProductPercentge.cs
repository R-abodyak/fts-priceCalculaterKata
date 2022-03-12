class ProductPercentge
{  
    private double percentage=0;
    //TODO -geter ,seter
    private bool isbefore;
    private String type;
    public ProductPercentge(double percentage , bool isbefore , String type) {
        this.percentage = percentage;
        this.isbefore = isbefore;
        this.type = type;
    }
    public double Percentage
    {
        get { return Math.Round(percentage, 2); }
        set { percentage = value; }
    }
    public bool IsBefore
    {
        get { return isbefore; }
        set { isbefore = value; }
    }
    public String Type
    {
        get { return type; }
        set { type = value; }
    }


    public static double calculate(double val ,double price)
    {

        return Math.Round((val / 100) * price ,2);
    }

    

}


