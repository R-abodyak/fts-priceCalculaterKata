class Product
{
    private String? name = null ;
    private long upc;
    private double price;
    private double taxPercentage = 20  ;
    private double discountPercentage;
    

    public String? Name {
        get { return name ; }

        set { name =value ; }
    }
    public long UPC {
        get { return upc ;}
        set { upc = value ;}
    }

    public double Price {
        get
        {
            return Math.Round(price, 2);
         }
        
        set
        {
            price = Math.Round(value, 2);

        }
    }
    public double TaxPercentage {
        get { return Math.Round(taxPercentage, 2); }
        set { taxPercentage = value; }
    }
    public double DiscountPercentage
    {
        get { return Math.Round(taxPercentage, 2); }
        set { discountPercentage = value; }

    }

    public double calculatePriceAfterTax()
    {
        return Math.Round( price + (( TaxPercentage/100) * price) ,2);
    }

    public double calculateTaxAmount()
    {

        return Math.Round((TaxPercentage / 100) * price ,2);
    }

    public double calculateDiscountAmount()
    {

        return Math.Round((discountPercentage / 100) * price, 2);
    }
    public double calculatePriceAfter()
    {
        return Math.Round (price + calculateTaxAmount() - calculateDiscountAmount());
    }

}
