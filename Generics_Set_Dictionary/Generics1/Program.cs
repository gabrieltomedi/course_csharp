using Generics1.Services;

namespace Generics1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintService<int> printService = new PrintService<int>();

            Console.Write("How many values? ");
            int n = int.Parse(Console.ReadLine());  

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                printService.AddValues(x);
            }

            printService.Print();
            Console.WriteLine("First: " + printService.GetFirst());

            Console.WriteLine("\n-----string-----\n");
            PrintService<string> printService2 = new PrintService<string>();

            Console.Write("How many values? ");
             n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string x = Console.ReadLine();
                printService2.AddValues(x);
            }

            printService2.Print();
            Console.WriteLine("First: " + printService2.GetFirst());
        }
    }
}