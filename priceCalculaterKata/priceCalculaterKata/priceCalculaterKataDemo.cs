﻿using System;

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
        ProductPercentge twentyPercenTax = new ProductPercentge(20, false, "tax");
        ProductPercentge twentyonePercenTax = new ProductPercentge(21, false, "tax");

        ProductPercentge Udiscount = new ProductPercentge(15, false, "discount");
        ProductPercentge upc = new ProductPercentge(7, false, "upcdiscount");
        Dictionary<long, double> mydictionary = new Dictionary<long, double>();

        Product product = new Product();
        Product product2 = new Product();
        product.Name = "mybook";
        product.UPC = 123;
        product.Price = 20.25;
        mydictionary.Add(product.UPC, product.Price);
        product.addPercentage(twentyPercenTax);
        product.addPercentage(upc);
        product.addPercentage(Udiscount);

        

        product2.Name = "mychair";
        product2.UPC = 129;
        product2.Price = 20.25;
        product2.addPercentage(twentyonePercenTax);
        product2.addPercentage(upc);
        product2.addPercentage(Udiscount);
        productFacade productfacade2 = new productFacade(product2, product2.productPercentage, mydictionary);
        productFacade productfacade = new productFacade(product,product.productPercentage, mydictionary);
        productfacade.Report();
        productfacade2.Report();






    }
    
}
