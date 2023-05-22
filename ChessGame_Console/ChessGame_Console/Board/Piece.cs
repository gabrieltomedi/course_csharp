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

        public void IncreaseMoveAmount()
        {
            MovementsAmount++;
        }
    }
}
