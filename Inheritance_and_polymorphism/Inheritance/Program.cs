using Inheritance.Entities;
/*
 *  Demostration of Inheritance
 */

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessAccount account = new BusinessAccount(8010, "Jessica Rogers", 100.0, 500.0);
            Console.WriteLine(account.Balance);
        }
    }
}
