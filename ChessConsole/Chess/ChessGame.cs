using Chess;
using ChessBoard;
using System.Collections.Generic;

namespace Chess
{
    //This class will implement the mecanics of the game.
    class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; protected set; }
        public bool Finished { get; private set; }
        public bool Check { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;


        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece ExecuteAMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementAmountMoves();

            Piece capturedPiece = Board.RemovePiece(destination);

            Board.PlacePiece(piece, destination);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        private void UndoAMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DecrementAmountMoves();
            Board.PlacePiece(piece, origin);

            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }

        }
        public void MakeAMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteAMove(origin, destination);

            if (IsInCheck(ActualPlayer))
            {
                UndoAMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check.");
            }

            if (IsInCheck(Adversary(ActualPlayer)))
            {
                Check = true;
            }
            else Check = false;


            if (IsInCheckMate(Adversary(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.GetPiece(position) == null)
            {
                throw new BoardException("There is no piece in this position. Try again!");
            }
            if (ActualPlayer != Board.GetPiece(position).Color)
            {
                throw new BoardException("You are trying to move a piece with the wrong color. Try again!");
            }
            if (!Board.GetPiece(position).ThereIsPossibleMoves())
            {
                throw new BoardException("Sorry, but this piece can't move. Try again!");
            }
        }


        public void ValidadeDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.GetPiece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("This destiny position is not valid. Thay again!");
            }
        }

        private void ChangePlayer()
        {
            ActualPlayer = ActualPlayer == Color.White ? Color.Black : Color.White;
        }

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> piecesCapturedByColor = new HashSet<Piece>();

            foreach (Piece piece in CapturedPieces)
            {
                if (color == piece.Color)
                {
                    piecesCapturedByColor.Add(piece);
                }
            }

            return piecesCapturedByColor;
        }
        public HashSet<Piece> PiecesInTheGameByColor(Color color)
        {
            HashSet<Piece> piecesInTheGameByColor = new HashSet<Piece>();

            foreach (Piece piece in Pieces)
            {
                if (color == piece.Color)
                {
                    piecesInTheGameByColor.Add(piece);
                }
            }

            piecesInTheGameByColor.ExceptWith(CapturedPiecesByColor(color));
            return piecesInTheGameByColor;
        }


        private Color Adversary(Color color)
        {
            return color == Color.White ? Color.Black : Color.White;
        }

        private Piece King(Color color)
        {
            foreach (Piece piece in PiecesInTheGameByColor(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            //If there is no king with this color on the board, we throw a message telling this to the user.
            Piece king = King(color) ?? throw new BoardException("There is no " + color + " king in the game.");


            foreach (Piece piece in PiecesInTheGameByColor(Adversary(color))) //Here we are checking in the true moves of all adversary pieces if there is some that can match with the king position. If there is one, it will return true, if it look in all the matrix and there is none, it will return false.
            {

                bool[,] matrix = piece.PossibleMoves();
                if (matrix[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInCheckMate(Color color)
        {
            if (!IsInCheck(color)) return false;

            foreach (Piece piece in PiecesInTheGameByColor(color)) //Here we will go through all the pieces in the game an check in the possible moves (only the true ones), if if can make a move that will change the status of IsInCheck. If it changes, we need to Undo the move, and replace the captured piece on the board.
            {
                bool[,] matrix = piece.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteAMove(origin, destiny);
                            bool stillInCheck = IsInCheck(color);
                            UndoAMove(origin, destiny, capturedPiece);

                            if (!stillInCheck)
                            {
                                return false;
                            }
                        }
                    }

                }

            }

            return true;
        }

        private void CreateNewPiece(char column, int line, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }

        public void PlacePieces()
        {
            //White pieces
           
            CreateNewPiece('c', 2, new Tower(Color.White, Board));
            CreateNewPiece('d', 7, new Tower(Color.White, Board));
            CreateNewPiece('d', 1, new King(Color.White, Board));

            //Black pieces
            CreateNewPiece('a', 7, new Tower(Color.Black, Board));
            CreateNewPiece('h', 7, new Tower(Color.Black, Board));
            CreateNewPiece('a', 8, new King(Color.Black, Board));

        }

    }
}