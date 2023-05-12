using Inheritance4.Entities;
using System.Globalization;

namespace Inheritance4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeesList = new List<Employee>();

            Console.Write("Enter the number of employeed: ");
            int n = int.Parse(Console.ReadLine());                    

            for( int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Employee #{i} data:");
                Console.Write("Outsourced (y/n)? ");
                char outsourced = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                if(outsourced == 'y')
                {
                    Console.Write("Additional charge: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    employeesList.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
                } else
                {
                    employeesList.Add(new Employee(name, hours, valuePerHour));
                }              
            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS:");
            foreach (Employee employee in employeesList)
            {
                Console.WriteLine(employee.Name + " - $" + employee.Paymente());
            }
        }
    }
}
