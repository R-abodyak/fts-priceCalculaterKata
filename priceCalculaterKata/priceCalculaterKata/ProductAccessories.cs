class ProductAccessories
{
    public String discountWay
    { get; set; }
    private (double amount ,ValueType type ) cap;
    private double basePrice;
    private ISO3 currency;
    public ProductAccessories(double basePrice) {
        this.basePrice = basePrice;
        cap.amount = double.PositiveInfinity;//so if cap was not determine ,discount will be taken
    }
    public ISO3 Currency
    {
        get { return currency; }
        set { this.currency = value; }
    }
    public (double amount, ValueType type) CAP {
        set { cap = value; }
        get { return cap; }
    }
    public double CalculateCapAmount()
    {    

        if (CAP.type == ValueType.absolute) return Math.Round(CAP.amount,2);
        
            return Math.Round((CAP.amount / 100) * basePrice, 2);
    }


    //not satisfied with that ,but even in observer Pattern method in observer was public
    public void updateBasePrice(double basePrice)
    {
        this.basePrice = basePrice;


    }
}
public enum ValueType
{
    percentage,
     absolute
}
public enum ISO3
{
    USD,
    GBP,
    JPY
    
}