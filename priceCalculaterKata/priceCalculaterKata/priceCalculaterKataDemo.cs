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
        ProductPercentgeBase twentyPercenTax = new ProductPercentgeBase(20, "tax");
        ProductPercentgeBase twentyonePercenTax = new Discount(21, false, "tax");

        ProductPercentgeBase Udiscount = new Discount(15, false, "discount");
        ProductPercentgeBase Udiscount2 = new Discount(11, false, "discount");

        ProductPercentgeBase upc = new Discount(7, false, "upcdiscount");
        ProductPercentgeBase packging = new Cost(1,true,"packging cost");
        ProductPercentgeBase transport = new Cost(2.2, false, "transport cost");

        Dictionary<long, double> mydictionary = new Dictionary<long, double>();

        Product product = new Product();
        //product.discountWay = "additive";
        product.discountWay = "multiplicative";
        Product product2 = new Product();
        product.Name = "mybook";
        product.UPC = 123;
        product.Price = 20.25;
        mydictionary.Add(product.UPC, product.Price);
        product.addPercentage(twentyonePercenTax);
      
        product.addPercentage(Udiscount); 
        product.addPercentage(upc);
        product.addPercentage(transport);
        product.addPercentage(packging);

        

        product2.Name = "mychair";
        product2.UPC = 129;
        product2.Price = 20.25;
        product2.addPercentage(twentyonePercenTax);
        product2.addPercentage(upc);
        product2.addPercentage(Udiscount);
        productFacade productfacade2 = new productFacade(product2, product2.productPercentage, mydictionary);
        productFacade productfacade = new productFacade(product,product.productPercentage, mydictionary);
        productfacade.Report();
        //productfacade2.Report();






    }
    
}
