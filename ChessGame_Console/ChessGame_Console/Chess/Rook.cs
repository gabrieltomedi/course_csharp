using Board;

namespace Chess
{
    internal class Rook : Piece
    {
        public Rook(ChessBoard board, Color color) : base(board, color)
        {
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
            while(Board.IsValidPosition(position) && CanMove(position))
            {
                movements[position.Line, position.Column] = true;
                if(Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line--;
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

            //Right
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

            return movements;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
