using System;

namespace Board
{
    internal class ChessBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public ChessBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, Columns];
        }

        public Piece Piece(int line, int coulumn)
        {
            return Pieces[line, coulumn];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
