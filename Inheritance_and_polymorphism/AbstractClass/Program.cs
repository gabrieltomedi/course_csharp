using AbstractClass.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Account acc1 = new Account(1001, "Alan", 500.0); //Can't be done because class is abstract
            List<Account> list = new List<Account>();

            list.Add(new SavingsAccount(1001, "Alan", 500.0, 0.01));
            list.Add(new BusinessAccount(1002, "Lucia", 500.0, 400.0));
            list.Add(new SavingsAccount(1003, "Bruno", 500.0, 0.01));
            list.Add(new BusinessAccount(1004, "Alan", 500.0, 500.0));

            double sum = 0.0;
            foreach (Account account in list)
            {
                sum += account.Balance;
            }

            Console.WriteLine("Total Balance: " + sum.ToString("F2", CultureInfo.InvariantCulture));

            foreach (Account account in list)
            {
                account.Withdraw(10.0);
            }

            foreach (Account account in list)
            {
                Console.WriteLine("Update balacen dor account " 
                    + account.Number
                    + ": "
                    + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
