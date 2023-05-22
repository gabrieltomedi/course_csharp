using Board;
using Chess;

namespace ChessGame_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessBoard board = new ChessBoard(8, 8);

                board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));                
                board.PlacePiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PlacePiece(new King(board, Color.Black), new Position(0, 2));

                board.PlacePiece(new Rook(board, Color.White), new Position(3, 5));

                Screen.PrintBoard(board);
            }
            catch (BoardExcepition e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
    }
}