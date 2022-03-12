using System.Collections.Generic;

class productFacade
{
    Product product;

    public List<ProductPercentge> productPercentage;
    Dictionary<long, double> dictonary;
   public  productFacade(Product product , List<ProductPercentge> productPercentage, Dictionary<long,double>dictonary )
    {
        this.product = product;
        this.productPercentage = productPercentage;
        this.dictonary = dictonary;

    }

    public void Report()
    {    // Debug statements
        //product.display.display("DiscountBefore $", calculateDiscountBefore());
       // product.display.display("Tax $", FindTax());
       // product.display.display("DiscountAfter $", calculateDiscountAfter());
        product.display.display("Final Price is $", calculatePriceAfter());
        product.display.display("Total Discount Amount is $", calculateTotalDiscount());


    }
    public double calculatePriceAfter()
    {

        return Math.Round(product.Price
            + CalculateTax()-calculateTotalDiscount(), 2);

    }
    public double calculateTotalDiscount()
    {

        return Math.Round(calculateDiscountAfter()+calculateDiscountBefore(), 2);

    }
    private double calculateupcDiscount(double percentage , double price )
    {
        double upcdiscount = (hasSpecialUpc()) ? ProductPercentge.calculate(percentage, price) : 0;
        return upcdiscount;
    }
    private bool hasSpecialUpc()
    {
        if (dictonary.ContainsKey(product.UPC)) return true;
        return false;

    }
    private double CalculateTax()
    {
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());

        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type != "tax") continue;

            return (Math.Round(ProductPercentge.calculate(product.productPercentage[i].Percentage, priceBeforeTax), 2));



        }
        return 0;

    }
    private double calculateDiscountAfter()

    {
        double result = 0;
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type == "tax") continue;
            if (product.productPercentage[i].IsBefore == true) continue;
            double upcdiscount = (hasSpecialUpc()) ? ProductPercentge.calculate(product.productPercentage[i].Percentage,priceBeforeTax) : 0;

             result += product.productPercentage[i].Type == "upcdiscount" ?upcdiscount : ProductPercentge.calculate
                (product.productPercentage[i].Percentage, priceBeforeTax);

                
               


        }
        return result;
           
    }
    private double calculateDiscountBefore()
    {
        double result = 0;
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].IsBefore == false) continue;

            result += product.productPercentage[i].Type=="upcdiscount"?

                calculateupcDiscount(product.productPercentage[i].Percentage, product.Price )
                : ProductPercentge.calculate
                (product.productPercentage[i].Percentage, product.Price);

        }
       
        return result;
    }

    private double PriceBeforeTax(double calculateDiscountBefore)
    {
        return product.Price - calculateDiscountBefore;
    }
   
   

}
