using Board;

namespace ChessGame_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);

            Console.Write("Position: " + p);
            Console.WriteLine();
        }
    }
}