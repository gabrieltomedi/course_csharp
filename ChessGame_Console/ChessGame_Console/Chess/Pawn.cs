using System;
using Board;

namespace Chess
{
    internal class Pawn : Piece
    {
        private ChessMatch Match;

        public Pawn(ChessBoard board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
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

                //# Special Move: En passant
                if (Position.Line == 3)
                {
                    Position leftPos =  new Position(Position.Line, Position.Column - 1);
                    if(Board.IsValidPosition(leftPos) && OpponentExist(leftPos) && Board.Piece(leftPos) == Match.VulnerableToEnPassant)
                    {
                        movements[leftPos.Line - 1, leftPos.Column] = true;
                    }
                    Position RightPos = new Position(Position.Line, Position.Column + 1);
                    if (Board.IsValidPosition(RightPos) && OpponentExist(RightPos) && Board.Piece(RightPos) == Match.VulnerableToEnPassant)
                    {
                        movements[RightPos.Line - 1, RightPos.Column] = true;
                    }
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

                //# Special Move: En passant
                if (Position.Line == 4)
                {
                    Position leftPos = new Position(Position.Line, Position.Column - 1);
                    if (Board.IsValidPosition(leftPos) && OpponentExist(leftPos) && Board.Piece(leftPos) == Match.VulnerableToEnPassant)
                    {
                        movements[leftPos.Line + 1, leftPos.Column] = true;
                    }
                    Position RightPos = new Position(Position.Line, Position.Column + 1);
                    if (Board.IsValidPosition(RightPos) && OpponentExist(RightPos) && Board.Piece(RightPos) == Match.VulnerableToEnPassant)
                    {
                        movements[RightPos.Line + 1, RightPos.Column] = true;
                    }
                }
            }


            return movements;
        }
    }
}
