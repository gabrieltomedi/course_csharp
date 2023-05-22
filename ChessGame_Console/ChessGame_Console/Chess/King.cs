using Board;

namespace Chess
{
    internal class King : Piece
    {
        public King(ChessBoard board, Color color) : base(board, color)
        {
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

            return movements;
        }
    }
}
