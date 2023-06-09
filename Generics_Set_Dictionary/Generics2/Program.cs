using System.Globalization;
using Generics2.Services;
using Generics2.Entities;

namespace Generics2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            Console.WriteLine("---Integer---");
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                list.Add(x);
            }

            CalculationService calculationService = new CalculationService();

            int max = calculationService.Max(list);

            Console.Write("Max: ");
            Console.WriteLine(max);

            List<Product> list2 = new List<Product>();

            Console.WriteLine("---Products---");
            Console.Write("Enter N: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] vect = Console.ReadLine().Split(',');
                string name = vect[0];
                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);

                list2.Add(new Product(name, price));
            }            

            Product max2 = calculationService.Max(list2);

            Console.Write("Max: ");
            Console.WriteLine(max2);
        }
    }
}