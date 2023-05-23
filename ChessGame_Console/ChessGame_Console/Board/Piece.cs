using System;

namespace Board
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementsAmount { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece(ChessBoard board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MovementsAmount = 0;
        }

        public abstract bool[,] PossibleMovements();

        public bool ExistPossibleMove()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMovements()[position.Line, position.Column];
        }        

        public void IncreaseMoveAmount()
        {
            MovementsAmount++;
        }
    }
}
