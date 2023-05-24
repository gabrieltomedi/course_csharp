using System;
using Board;

namespace Chess
{
    internal class Queen : Piece
    {
        public Queen(ChessBoard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        public bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //Up
            position.DefineValues(Position.Line - 1, Position.Column);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line--;
            }

            //NE
            position.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    movements[position.Line, position.Column] = true;
                }
                position.DefineValues(position.Line - 1, position.Column + 1);
            }

            //Right
            position.DefineValues(Position.Line, Position.Column + 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column++;
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

            //Down
            position.DefineValues(Position.Line + 1, Position.Column);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line++;
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

            //Left
            position.DefineValues(Position.Line, Position.Column - 1);
            while (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column--;
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
