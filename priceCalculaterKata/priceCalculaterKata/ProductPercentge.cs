

class ProductPercentge : ProductPercentgeBase
{
    private bool isbefore;
    private String type;
    public ProductPercentge(double percentage , bool isbefore , String type) {
        this.percentage = percentage;
        this.isbefore = isbefore;
        this.type = type;
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
}

class Cost : ProductPercentge
{
   
}

