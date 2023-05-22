using Board;
using Chess;

namespace ChessGame_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChessPosition chessPosition = new ChessPosition('c', 7);

            Console.WriteLine(chessPosition);

            Console.WriteLine(chessPosition.ConvertToPosition());

            Console.WriteLine();
        }
    }
}