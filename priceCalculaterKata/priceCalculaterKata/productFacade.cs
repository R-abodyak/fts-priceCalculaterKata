using System.Collections.Generic;

class productFacade
{
    Product product;
    PriceCalculation priceCalculation;
    Dictionary<long, double> dictonary;
   public  productFacade(Product product ,PriceCalculation priceCalculation ,Dictionary<long,double>dictonary )
    {
        this.product = product;
        this.priceCalculation = priceCalculation;
        this.dictonary = dictonary;

    }
    private bool hasSpecialUpc()
    {
        if (dictonary.ContainsKey(product.UPC)) return true;
        return false;

    }
    private double FindTotalDiscount()
    {
        double upcdiscount = (hasSpecialUpc()) ? priceCalculation.calculate(priceCalculation.UpcPercentage) : 0;

        return (Math.Round(priceCalculation.calculate(priceCalculation.DiscountPercentage
            + upcdiscount), 2));
           
    }

    public double calculatePriceAfter()
    {
      
        return Math.Round(product.Price
            + priceCalculation.calculate(priceCalculation.TaxPercentage) 
            - FindTotalDiscount() , 2);
           
    }
    public void Report()
    {  
  
        product.display.display("Final Price is $",calculatePriceAfter() );
        product.display.display("Total Discount Amount is $", FindTotalDiscount());


    }

}
