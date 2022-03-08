class Product
{
    private String? name = null ;
    private long upc;
    private float price;

    public String? Name { get; set; }
    public long UPC { get; set; }
    public float Price {
        get; 
        set(float number ){
        Math.Round(inputValue, 2);
      }
    }


    public static void Main(String [] args)
    {



    }

}