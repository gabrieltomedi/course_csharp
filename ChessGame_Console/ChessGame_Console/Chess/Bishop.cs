using System;
using Board;

namespace Chess
{
    internal class Bishop : Piece
    {
        public Bishop(ChessBoard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //NE
            position.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.IsValidPosition(position) && CanMove(position) )
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    movements[position.Line, position.Column] = true;
                }
                position.DefineValues(position.Line -1, position.Column + 1);
            }


            //SE
            position.DefineValues(Position.Line + 1, Position.Column + 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    movements[position.Line, position.Column] = true;
                }
                position.DefineValues(position.Line + 1, position.Column + 1);
            }

            //SW
            position.DefineValues(Position.Line + 1, Position.Column - 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    movements[position.Line, position.Column] = true;
                }
                position.DefineValues(position.Line + 1, position.Column - 1);
            }

            //NW
            position.DefineValues(Position.Line - 1, Position.Column - 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    movements[position.Line, position.Column] = true;
                }
                position.DefineValues(position.Line - 1, position.Column - 1);
            }

            return movements;
        }

    }
}
