﻿class Product
{
    private String? name = null ;
    private long upc;
    private double price;
    public List<ProductPercentge> productPercentage;
    public Display display;
   public Product()
    {
        productPercentage = new List<ProductPercentge>();//create pricecalculation obj when create product
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
              
        }
    }





}
