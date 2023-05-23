using System.Collections.Generic;
using Board;

namespace Chess
{
    internal class ChessMatch
    {
        public ChessBoard Board { get; private set; }
        public  int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Ended { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;


        public ChessMatch()
        {
            Board= new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Ended = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();

            PlacePieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMoveAmount();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturesPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in Captured)
            {
                if(p.Color == color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in Pieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(CapturesPieces(color));
            return aux;
        }

        public void PlaceNewPiece( char column, int line, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('c', 1, new Rook(Board, Color.White));
            PlaceNewPiece('c', 2, new Rook(Board, Color.White));
            PlaceNewPiece('d', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 2, new Rook(Board, Color.White));
            PlaceNewPiece('e', 1, new Rook(Board, Color.White));
            PlaceNewPiece('d', 1, new King(Board, Color.White));

            PlaceNewPiece('c', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('c', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 7, new Rook(Board, Color.Black));
            PlaceNewPiece('e', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('d', 8, new King(Board, Color.Black));
        }
    }
}
