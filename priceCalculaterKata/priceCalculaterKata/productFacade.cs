class productFacade
{
    Product product;
    productFacade(Product p)
    {
        product = p;
    }
    public void priceCalcAndReport()
    {
        double result =product.calculatePriceAfter();
        product.display.display("Final Price is $", result);
        product.display.display("Discount Amount is $", product.priceCalculation.calculateDiscountAmount());


    }

}
