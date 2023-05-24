using Board;

namespace Chess
{
    internal class King : Piece
    {
        private ChessMatch Match;

        public King(ChessBoard board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;  
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        private bool TestRookForEspecialMove(Position possiton)
        {
            Piece p = Board.Piece(possiton);
            return p != null && p is Rook && p.Color == Color && p.MovementsAmount == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //Up
            position.DefineValues(Position.Line - 1, Position.Column);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //NE
            position.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //Right
            position.DefineValues(Position.Line, Position.Column + 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //SE
            position.DefineValues(Position.Line + 1, Position.Column + 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //Down
            position.DefineValues(Position.Line + 1, Position.Column);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //SW
            position.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //Left
            position.DefineValues(Position.Line, Position.Column - 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //NW
            position.DefineValues(Position.Line -1, Position.Column - 1);
            if (Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
            }

            //# special move: Castling
            if (MovementsAmount == 0 && !Match.Check)
            {
                Position RookPos = new Position(Position.Line, Position.Column + 3);
                if (TestRookForEspecialMove(RookPos))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        movements[Position.Line, Position.Column + 2] = true;
                    }
                }

                Position RookPos2 = new Position(Position.Line, Position.Column + 3);
                if (TestRookForEspecialMove(RookPos2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        movements[Position.Line, Position.Column - 2] = true;
                    }
                }
            }         


            return movements;
        }
    }
}
