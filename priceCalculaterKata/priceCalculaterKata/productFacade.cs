using System.Collections.Generic;

//TO-DO there is simillarity in all calculate functions
class productFacade
{
    Product product;
    private double price;
    public List<ProductPercentgeBase> productPercentage;
    Dictionary<long, double> dictonary;
    public int Percision = 4;
   public  productFacade(Product product , List<ProductPercentgeBase> productPercentage, Dictionary<long,double>dictonary )
    {
        this.product = product;
        this.productPercentage = productPercentage;
        this.dictonary = dictonary;
        price = product.Price;
    }

    public void Report()
    {    // Debug statements
        product.display.display("Cost ",product.productaccessories.Currency,product.Price );
        product.display.display("Tax ",product.productaccessories.Currency, FindTax()); 
        //product.display.display("DiscountBefore $", calculateDiscountBefore());
        //product.display.display("DiscountAfter $", calculateDiscountAfter());   
        product.display.display("Discount ",product.productaccessories.Currency, calculateTotalDiscount());
        DisplayCostSeperatly();
        product.display.display("Total is " , product.productaccessories.Currency, calculatePriceAfter());
        Console.WriteLine();


    }
    public void DisplayCostSeperatly()
    {
        double result = 0;
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type != "cost") continue;
            Cost costObj = (Cost)product.productPercentage[i];
            result = costObj.calculate(product.productPercentage[i].Percentage, priceBeforeTax, Percision);
            product.display.display(costObj.Description,product.productaccessories.Currency, result);
        }

    }
    public double calculatePriceAfter()
    {

        return Math.Round(product.Price
            + FindTax()-calculateTotalDiscount()+calculateCost(), 2);

    }
    
    public double calculateCost()
    {
        double result = 0;
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type != "cost") continue;
            Cost costObj = (Cost)product.productPercentage[i];
            result +=costObj.calculate(product.productPercentage[i].Percentage, priceBeforeTax, Percision);

        }
        return Math.Round(result, Percision);
    }
    public double calculateTotalDiscount()
    {
        double initialDiscount = Math.Round(calculateDiscountAfter()+calculateDiscountBefore(), Percision);
        return Math.Min(initialDiscount, product.productaccessories.CalculateCapAmount());
    }
    private double calculateupcDiscount(double percentage , double price )
    {
        double upcdiscount = (hasSpecialUpc()) ? new ProductPercentgeBase().calculate(percentage, price, Percision) : 0;
        return upcdiscount;
    }
    private bool hasSpecialUpc()
    {
        if (dictonary.ContainsKey(product.UPC)) return true;
        return false;

    }
    private double FindTax()
    {
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());

        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type != "tax") continue;

            return (Math.Round(new ProductPercentgeBase().calculate(product.productPercentage[i].Percentage, priceBeforeTax, Percision), Percision));



        }
        return 0;

    }
    private double calculateDiscountAfter()

    {
        double result = 0;
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());
        price = product.productaccessories.discountWay == "multiplicative"? price: priceBeforeTax;
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
          
            if ((product.productPercentage[i].Type != "discount" && product.productPercentage[i].Type != "upcdiscount")) continue;
            //type casting
            Discount discountObj =(Discount) product.productPercentage[i];
            if (discountObj.IsBefore == true) continue;
            
            double upcdiscount = (hasSpecialUpc()) ? new ProductPercentgeBase ().calculate(product.productPercentage[i].Percentage,price, Percision) : 0;

             double discount= product.productPercentage[i].Type == "upcdiscount" ?upcdiscount : new ProductPercentgeBase().calculate
                (product.productPercentage[i].Percentage, price, Percision);
            if (product.productaccessories.discountWay == "multiplicative")
            {
                
                price -= discount;
                

            }
            result += discount;


        }
     

        return result;
           
    }
    private double calculateDiscountBefore()
    {
        double result = 0;
         price = product.Price;
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if ((product.productPercentage[i].Type != "discount" && product.productPercentage[i].Type != "upcdiscount")) continue;
           

            Discount discountObj = (Discount) product.productPercentage[i];
            if (discountObj.IsBefore == false) continue;
            

            
                double discount= product.productPercentage[i].Type=="upcdiscount"?

                calculateupcDiscount(product.productPercentage[i].Percentage, price )
                :new ProductPercentgeBase().calculate
                (product.productPercentage[i].Percentage, price, Percision);
            if(product.productaccessories.discountWay=="multiplicative")
            {
                price -= discount;
                
            }
            result += discount;

        }
        return result;
    }

    private double PriceBeforeTax(double calculateDiscountBefore)
    {
        return product.Price - calculateDiscountBefore;
    }
   
   

}
