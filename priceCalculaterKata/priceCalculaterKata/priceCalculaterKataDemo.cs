﻿using System;

public class priceCalculaterKataDemo
{
	
        public static void Main(String[] args)
        {
            Product product = new Product();
            Console.WriteLine("Enter Product Name ");
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

        Console.WriteLine(product.Name);







    }
    
}
