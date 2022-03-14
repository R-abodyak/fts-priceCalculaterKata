using System.Collections.Generic;

//TO-DO there is simillarity in all calculate functions
class productFacade
{
    Product product;

    public List<ProductPercentgeBase> productPercentage;
    Dictionary<long, double> dictonary;
   public  productFacade(Product product , List<ProductPercentgeBase> productPercentage, Dictionary<long,double>dictonary )
    {
        this.product = product;
        this.productPercentage = productPercentage;
        this.dictonary = dictonary;

    }

    public void Report()
    {    // Debug statements
        product.display.display("Cost $",product.Price);
        product.display.display("Tax $", FindTax()); 
        //product.display.display("DiscountBefore $", calculateDiscountBefore());
        //product.display.display("DiscountAfter $", calculateDiscountAfter());   
        product.display.display("Discount $", calculateTotalDiscount());
        DisplayCostSeperatly();
        product.display.display("Total is $  ", calculatePriceAfter());


    }
    public void DisplayCostSeperatly()
    {
        double result = 0;
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type != "cost") continue;
            Cost costObj = (Cost)product.productPercentage[i];
            result = costObj.calculate(product.productPercentage[i].Percentage, priceBeforeTax);
            product.display.display(costObj.Description+" $ ", result);
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
            result +=costObj.calculate(product.productPercentage[i].Percentage, priceBeforeTax);

        }
        return Math.Round(result, 2);
    }
    public double calculateTotalDiscount()
    {
        double initialDiscount = Math.Round(calculateDiscountAfter()+calculateDiscountBefore(), 2);
        return Math.Min(initialDiscount, product.productaccessories.CalculateCapAmount());
    }
    private double calculateupcDiscount(double percentage , double price )
    {
        double upcdiscount = (hasSpecialUpc()) ? new ProductPercentgeBase().calculate(percentage, price) : 0;
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

            return (Math.Round(new ProductPercentgeBase().calculate(product.productPercentage[i].Percentage, priceBeforeTax), 2));



        }
        return 0;

    }
    private double calculateDiscountAfter()

    {
        double result = 0;
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());
        double price = priceBeforeTax;
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
          
            if ((product.productPercentage[i].Type != "discount" && product.productPercentage[i].Type != "upcdiscount")) continue;
            //type casting
            Discount discountObj =(Discount) product.productPercentage[i];
            if (discountObj.IsBefore == true) continue;
            
            double upcdiscount = (hasSpecialUpc()) ? new ProductPercentgeBase ().calculate(product.productPercentage[i].Percentage,price) : 0;

             double discount= product.productPercentage[i].Type == "upcdiscount" ?upcdiscount : new ProductPercentgeBase().calculate
                (product.productPercentage[i].Percentage, price);
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
        double price = product.Price;
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if ((product.productPercentage[i].Type != "discount" && product.productPercentage[i].Type != "upcdiscount")) continue;
           

            Discount discountObj = (Discount) product.productPercentage[i];
            if (discountObj.IsBefore == false) continue;
            

            
                double discount= product.productPercentage[i].Type=="upcdiscount"?

                calculateupcDiscount(product.productPercentage[i].Percentage, price )
                :new ProductPercentgeBase().calculate
                (product.productPercentage[i].Percentage, price);
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
