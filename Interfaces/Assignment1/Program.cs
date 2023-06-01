using Assignment1.Entities;
using Assignment1.Services;
using System.Globalization;

namespace Assignment1
{
    internal class Prorram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data: ");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(number, date, contractValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.processContract(myContract, months);

            Console.WriteLine();
            Console.WriteLine("INSTALLMENT: ");
            foreach(Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }

        }
    }
}