﻿using System.Collections.Generic;
using Board;

namespace Chess
{
    internal class ChessMatch
    {
        public ChessBoard Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Ended { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Ended = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();


            PlacePieces();
        }

        public Piece ExecuteMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMoveAmount();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoTheMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destination);
            piece.DecreaseMoveAmount();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destination);
                Captured.Remove(capturedPiece);
            }

            Board.PlacePiece(piece, origin);
        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(origin, destination);
            if (IsInCheck(CurrentPlayer))
            {
                UndoTheMove(origin, destination, capturedPiece);
                throw new BoardExcepition("You can't put your self in check");
            }

            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckmateTest(Opponent(CurrentPlayer)))
            {
                Ended = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

        }

        public void ValidaeOriginPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardExcepition("There is no piece in this position!");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardExcepition("The piece in this position is not yours!");
            }
            if (!Board.Piece(position).ExistPossibleMove())
            {
                throw new BoardExcepition("There is no possible move for this piece");
            }
        }

        public void ValidaeDesinationPos(Position origin, Position destination)
        {
            if (!Board.Piece(origin).PossibbleMove(destination))
            {
                throw new BoardExcepition("Invalid Movement!");
            }
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturesPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in Captured)
            {
                if (p.Color == color)
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

        private Piece PieceKing(Color color)
        {
            foreach (Piece p in PiecesInGame(color))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece k = PieceKing(color);
            if (k == null)
            {
                throw new BoardExcepition("There is no king of this color.");
            }

            foreach (Piece p in PiecesInGame(Opponent(color)))
            {
                bool[,] possibleMoves = p.PossibleMovements();
                if (possibleMoves[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece p in PiecesInGame(color))
            {
                bool[,] possibleMoves = p.PossibleMovements();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (possibleMoves[i, j])
                        {
                            Position origin = p.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPìece = ExecuteMovement(origin, destination);
                            bool checkTest = IsInCheck(color);
                            UndoTheMove(origin, destination, capturedPìece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('a', 1, new Rook(Board, Color.White));
            PlaceNewPiece('b', 1, new Knight(Board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('d', 1, new Queen(Board, Color.White));
            PlaceNewPiece('e', 1, new King(Board, Color.White));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White));

            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black));

        }
    }
}
