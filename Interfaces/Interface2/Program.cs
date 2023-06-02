using Interface2.Model.Entities;
using Interface2.Model.Enums;

namespace Interface2
{
    internal class program
    {
        static void Main(string[] args)
        {
            IShape s1 = new Circle() { Radius = 2.0, Color = Color.White };
            IShape s2 = new Rectangle() { Width = 3.5, Height = 4.2, Color = Color.White };

            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}