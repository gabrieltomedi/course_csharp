using Interface4_IComparable.Entities;

namespace Interface4_IComparable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\temp\in.txt";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    List<Employee> list = new List<Employee>();
                    while (!sr.EndOfStream)
                    {
                        list.Add(new Employee(sr.ReadLine()));    
                    }
                    list.Sort();
                    foreach (Employee employee in list)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(ex.Message);   
            }
        }
    }
}