

class Discount : ProductPercentgeBase
{
    private bool isbefore;
    public Discount(double percentage , bool isbefore , String type) {
        this.Percentage = percentage;
        this.isbefore = isbefore;
        this.Type = type;
    }

    public bool IsBefore
    {
        get { return isbefore; }
        set { isbefore = value; }
    }
    
}

