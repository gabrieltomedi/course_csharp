using Inheritance5.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace Inheritance5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i=1; i<= n; i++)
            {
                Console.WriteLine($"Product #{n} data:");
                Console.Write("Common, used or imported? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(type == 'c')
                {
                    products.Add(new Product(name, price));
                } else if(type == 'u')
                {
                    Console.Write("Manufacture Date: ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, manufactureDate));
                } else
                {
                    Console.Write("Custom fee: ");
                    double customFee = double.Parse(Console.ReadLine());
                    products.Add(new ImportedProduct(name, price, customFee));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product product in products)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }

}
