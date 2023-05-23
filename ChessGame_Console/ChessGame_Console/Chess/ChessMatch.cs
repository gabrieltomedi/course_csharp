using System;
using Board;

namespace Chess
{
    internal class ChessMatch
    {
        public ChessBoard Board { get; private set; }
        public  int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Ended { get; private set; }

        public ChessMatch()
        {
            Board= new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Ended = false;
            PlacePieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMoveAmount();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);

        }

        public void MakeAMove(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidaeOriginPosition(Position position)
        {
            if(Board.Piece(position) == null)
            {
                throw new BoardExcepition("There is no piece in this position!");
            }
            if(CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardExcepition("The piece in this position is not yours!");
            }
            if (!Board.Piece(position).ExistPossibleMove())
            {
                throw new BoardExcepition("There is no possible move for this piece");
            }
        }

        public void ValidaeDesinationPos(Position  origin, Position destination)
        {
            if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardExcepition("Invalid Movement!");
            }
        }

        public void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer=Color.White;
            }
        }

        private void PlacePieces()
        {
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c',1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
