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

        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public bool PieceExist(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (PieceExist(position))
            {
                throw new BoardExcepition("There is already a piece in this position");
            }

            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool IsValidPosition(Position position)
        {
            if(position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!IsValidPosition(position))
            {
                throw new BoardExcepition("Invalid Position");
            }
        }
    }
}
