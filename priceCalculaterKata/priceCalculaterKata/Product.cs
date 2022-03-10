 class Product
{
    private String? name = null ;
    private long upc;
    private double price;
    public PriceCalculation priceCalculation; //compostion 

   public Product()
    {
        priceCalculation = new PriceCalculation();//create pricecalculation obj when create product

    }
    
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
           priceCalculation.updatePrice(price) ; // best place to pass price
        }
    }


    public double calculatePriceAfter()
    {
        
        return Math.Round(price + priceCalculation.calculateTaxAmount() - priceCalculation.calculateDiscountAmount(), 2);
    }


}
