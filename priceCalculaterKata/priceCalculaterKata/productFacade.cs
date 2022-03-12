using System.Collections.Generic;

class productFacade
{
    Product product;
    ProductPercentge priceCalculation;
    Dictionary<long, double> dictonary;
   public  productFacade(Product product ,ProductPercentge priceCalculation ,Dictionary<long,double>dictonary )
    {
        this.product = product;
        this.priceCalculation = priceCalculation;
        this.dictonary = dictonary;

    }

    public void Report()
    {

        product.display.display("Final Price is $", calculatePriceAfter());
        product.display.display("Total Discount Amount is $", calculateTotalDiscount());


    }
    public double calculatePriceAfter()
    {

        return Math.Round(product.Price
            + FindTax()-calculateTotalDiscount(), 2);

    }
    public double calculateTotalDiscount()
    {

        return Math.Round(calculateDiscountAfter()+calculateDiscountBefore(), 2);

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

            return (Math.Round(ProductPercentge.calculate(product.productPercentage[i].Percentage, priceBeforeTax), 2));



        }
        return 0;

    }
    private double calculateDiscountAfter()

    {
        double priceBeforeTax = PriceBeforeTax(calculateDiscountBefore());
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type != "discount") continue;
            if (product.productPercentage[i].isbefore == true) continue;
            double upcdiscount = (hasSpecialUpc()) ? ProductPercentge.calculate(product.productPercentage[i].Percentage,priceBeforeTax) : 0;
           
            return (Math.Round(upcdiscount, 2));
            

        }
        return 0;
           
    }
    private double calculateDiscountBefore()
    {
        double result = 0;
        for (int i = 0; i < product.productPercentage.Count; i++)
        {
            if (product.productPercentage[i].Type != "discount") continue;
            if (product.productPercentage[i].isbefore == false) continue;
            result += ProductPercentge.calculate
                (product.productPercentage[i].Percentage, product.Price);

        }
       
        return result;
    }

    private double PriceBeforeTax(double discountBeforeAmount)
    {
        return product.Price - discountBeforeAmount;
    }

   

}
