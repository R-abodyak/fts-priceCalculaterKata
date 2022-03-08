class Product
{
    private String? name = null ;
    private long upc;
    private double price;
    private double taxPercentage;

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

}