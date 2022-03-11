using System;

class priceCalculaterKataDemo
{     
	
        public static void Main(String[] args)
        {

        /* comment user input for faster testing 
         * 
         * Console.WriteLine("Enter Product Name ");
          product.Name = Console.ReadLine();
          Console.WriteLine("Enter Product upc ");
          String? input = Console.ReadLine();
        //adding null check later
          product.UPC = long.Parse(input);
         Console.WriteLine("Enter Product price ");
        input = Console.ReadLine();
         product.Price = double.Parse(input);
      Console.WriteLine("product Name is " + 
          product.Name + "\n upc is " + product.UPC + "\n price is "+ product.Price);
        */
        Product product = new Product();
        Product product2 = new Product();
        product.Name = "mybook";
        product.UPC = 123;
        product.Price = 20.25;
        product.priceCalculation.TaxPercentage = 20;
        product.priceCalculation.DiscountPercentage = 15;
        product.priceCalculation.UpcPercentage = 7;

        product2.Name = "mychair";
        product2.UPC = 129;
        product2.Price = 20.25;
        product2.priceCalculation.TaxPercentage = 20;
        product2.priceCalculation.DiscountPercentage = 15;
        product2.priceCalculation.UpcPercentage = 7;

        Dictionary<long, double> mydictionary = new Dictionary<long, double>();
        mydictionary.Add(product.UPC, product.Price);
        productFacade productfacade2 = new productFacade(product2, product2.priceCalculation, mydictionary);
        productFacade productfacade = new productFacade(product,product.priceCalculation, mydictionary);
        productfacade.Report();
        productfacade2.Report();






    }
    
}
