using assignment_2.Entities;
using System;

namespace assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comment c1 = new Comment("Have a nice Trip");
            Comment c2 = new Comment("Wow that's awesome!");
            Post p1 = new Post(DateTime.Parse("21/06/2023 13:05:44"), "Traveling to Japan", "I'm visiting japan this month", 12);
            p1.AddComment(c1);
            p1.AddComment(c2);

            Comment c3 = new Comment("Good night");
            Comment c4 = new Comment("May the force be with you!");
            Post p2 = new Post(DateTime.Parse("28/07/2023 23:15:23"), "Traveling to Japan", "I'm visiting japan this month", 12);
            p2.AddComment(c3);
            p2.AddComment (c4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);


        }
    }
}
