﻿class Cost : ProductPercentgeBase
{   private double amount ;
    private bool isPercentage;
    private String description;
    Cost(double amount ,bool isPercentage,String description)
    {
        this.Type = "cost";
        this.amount = amount;
        this.isPercentage = isPercentage;
        this.description = description;
    }

    public double Amount {
        get { return amount; }
        set { amount = value; }
    }
    public bool ispercentage
    {
        get { return isPercentage; }
        set { isPercentage = value; }
    }
    public String Description
    {
        get { return description; }
        set { description = value; }
    }

    public override double  calculate(double price)
    {
        if (!ispercentage) return Amount;

        return base.calculate(price);
       
    }
}

