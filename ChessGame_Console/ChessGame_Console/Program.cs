using Board;
using Chess;

namespace ChessGame_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard(8, 8);

            board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));
            board.PlacePiece(new Rook(board, Color.Black), new Position(1, 3));
            board.PlacePiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintBoard(board);
        }
    }
}