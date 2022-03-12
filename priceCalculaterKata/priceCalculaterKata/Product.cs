class Product
{
    private String? name = null ;
    private long upc;
    private double price;
    public List<PriceCalculation> priceCalculation;
 

    public Display display;
   public Product()
    {
        priceCalculation = new List<PriceCalculation>();//create pricecalculation obj when create product
        display = new Display();
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
            foreach(var i in priceCalculation ) i.updatePrice(price) ; // best place to pass price
              
        }
    }





}
