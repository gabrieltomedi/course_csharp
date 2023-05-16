using Assignment1.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace Assignment1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(type == 'i')
                {
                    Console.Write("Heath Expeditures: ");
                    double healthExpeditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, anualIncome, healthExpeditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberOfEmployes = int.Parse(Console.ReadLine());

                    list.Add(new Company(name, anualIncome, numberOfEmployes));
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAYDE: ");
            double sum = 0.0;
            foreach (TaxPayer taxPayer in list)
            {
                Console.WriteLine(taxPayer.Name + ": " + taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));

                sum += taxPayer.Tax();
            }

            Console.WriteLine( );
            Console.WriteLine("Total Taxes: $" + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}