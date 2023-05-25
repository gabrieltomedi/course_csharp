using System.Collections.Generic;
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
        public Piece VulnerableToEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Ended = false;
            Check = false;
            VulnerableToEnPassant = null;
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
            //# special move: Castling
            if(piece is King && destination.Column == origin.Column + 2)
            {
                Position origenRook = new Position(origin.Line, origin.Column + 3);
                Position DestinationRook = new Position(origin.Line, origin.Column + 1);
                Piece t = Board.RemovePiece(origenRook);
                t.IncreaseMoveAmount(); 
                Board.PlacePiece(t, DestinationRook);
            }
            if (piece is King && destination.Column == origin.Column - 2)
            {
                Position origenRook = new Position(origin.Line, origin.Column - 4);
                Position DestinationRook = new Position(origin.Line, origin.Column - 1);
                Piece t = Board.RemovePiece(origenRook);
                t.IncreaseMoveAmount();
                Board.PlacePiece(t, DestinationRook);
            }

            //# Special Move: En passant
            if(piece is Pawn)
            {
                if(origin.Column != destination.Column && capturedPiece == null)
                {
                    Position pawnPos;
                    if(piece.Color == Color.White)
                    {
                        pawnPos = new Position(destination.Line +1, destination.Column);
                    }
                    else
                    {
                        pawnPos = new Position(destination.Line - 1, destination.Column);
                    }
                    capturedPiece = Board.RemovePiece(pawnPos);
                    Captured.Add(capturedPiece);
                }
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

            //# special move: Castling
            if (piece is King && destination.Column == origin.Column + 2)
            {
                Position origenRook = new Position(origin.Line, origin.Column + 3);
                Position DestinationRook = new Position(origin.Line, origin.Column + 1);
                Piece t = Board.RemovePiece(DestinationRook);
                t.DecreaseMoveAmount();
                Board.PlacePiece(t, origenRook);
            }
            if (piece is King && destination.Column == origin.Column - 2)
            {
                Position origenRook = new Position(origin.Line, origin.Column - 4);
                Position DestinationRook = new Position(origin.Line, origin.Column - 1);
                Piece t = Board.RemovePiece(DestinationRook);
                t.DecreaseMoveAmount();
                Board.PlacePiece(t, origenRook);
            }

            //# Special Move: En passant
            if (piece is Pawn)
            {
                if (origin.Column != destination.Column && capturedPiece == VulnerableToEnPassant)
                {
                    Piece pawn = Board.RemovePiece(destination);
                    Position pawnPositon;
                    if(piece.Color == Color.White)
                    {
                        pawnPositon = new Position(3, destination.Column);
                    }
                    else
                    {
                        pawnPositon = new Position(4, destination.Column);
                    }
                    Board.PlacePiece(pawn, pawnPositon);
                }
            }
        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(origin, destination);
            if (IsInCheck(CurrentPlayer))
            {
                UndoTheMove(origin, destination, capturedPiece);
                throw new BoardExcepition("You can't put your self in check");
            }

            Piece piece = Board.Piece(destination);

            //# Special Move: Promotion
            if(piece is Pawn)
            {
                if((piece.Color == Color.White && destination.Line == 0 ) || (piece.Color == Color.Black && destination.Line == 7) )
                {
                    piece = Board.RemovePiece(destination);
                    Pieces.Remove(piece);
                    Piece Queen = new Queen(Board, piece.Color);
                    Board.PlacePiece(Queen, destination);
                    Pieces.Add(Queen);
                }
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

            // Special Move: En passant
            if(piece is Pawn && (destination.Line == origin.Line  - 2 || destination.Line == origin.Line + 2))
            {
                VulnerableToEnPassant = piece;
            }
            else
            {
                VulnerableToEnPassant = null;
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
            PlaceNewPiece('e', 1, new King(Board, Color.White, this));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.White));
            PlaceNewPiece('g', 1, new Knight(Board, Color.White));
            PlaceNewPiece('h', 1, new Rook(Board, Color.White));
            PlaceNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.White, this));

            PlaceNewPiece('a', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Black));
            PlaceNewPiece('e', 8, new King(Board, Color.Black, this));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(Board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Black, this));

        }
    }
}
