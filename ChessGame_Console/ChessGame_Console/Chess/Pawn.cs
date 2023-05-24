using System;
using Board;

namespace Chess
{
    internal class Pawn : Piece
    {
        public Pawn(ChessBoard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        public bool OpponentExist(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }

        public bool PositionFree(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            if(Color == Color.White)
            {
                position.DefineValues(Position.Line - 1, Position.Column);
                if(Board.IsValidPosition(position) && PositionFree(position))
                {
                    movements[position.Line, position.Column] = true;
                }

                position.DefineValues(Position.Line - 2, Position.Column);
                if (Board.IsValidPosition(position) && PositionFree(position) && MovementsAmount == 0)
                {
                    movements[position.Line, position.Column] = true;
                }

                position.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.IsValidPosition(position) && OpponentExist(position))
                {
                    movements[position.Line, position.Column] = true;
                }

                position.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.IsValidPosition(position) && OpponentExist(position))
                {
                    movements[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.DefineValues(Position.Line + 1, Position.Column);
                if (Board.IsValidPosition(position) && PositionFree(position))
                {
                    movements[position.Line, position.Column] = true;
                }

                position.DefineValues(Position.Line + 2, Position.Column);
                if (Board.IsValidPosition(position) && PositionFree(position) && MovementsAmount == 0)
                {
                    movements[position.Line, position.Column] = true;
                }

                position.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.IsValidPosition(position) && OpponentExist(position))
                {
                    movements[position.Line, position.Column] = true;
                }

                position.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.IsValidPosition(position) && OpponentExist(position))
                {
                    movements[position.Line, position.Column] = true;
                }
            }


            return movements;
        }
    }
}
