using ExtensionMethods.Extensions;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2023, 6, 23, 8, 10, 45);
            Console.WriteLine(dt.ElapsedTime());
        }
    }
}