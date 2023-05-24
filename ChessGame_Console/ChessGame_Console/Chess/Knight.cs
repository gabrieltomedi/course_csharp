using System;
using Board;

namespace Chess
{
    internal class Knight : Piece
    {
        public Knight(ChessBoard board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "L";
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

            position.DefineValues(Position.Line - 1, Position.Column - 2);
            if(Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            position.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            position.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            position.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            position.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            position.DefineValues(Position.Line + 2, Position.Column + 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            position.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            position.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            return movements;
        }
    }
}
