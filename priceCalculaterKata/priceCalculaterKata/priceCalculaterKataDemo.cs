using System;

public class priceCalculaterKataDemo
{
	
        public static void Main(String[] args)
        {
            Product product = new Product();
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
        product.Name = "mybook";
        product.UPC = 123;
        product.Price = 10.8;
        Console.WriteLine(product.calculatePriceAfterTax());







    }
    
}
