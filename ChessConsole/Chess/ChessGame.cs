using Chess;
using ChessBoard;

namespace Chess
{
    //This class will implement the mecanics of the game.
    class ChessGame
    {
        public Board Board { get; private set; }
        private int Turn { get; set; }
        private Color ActualPlayer { get; set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            PlacePieces();
        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementAmountMoves();

            Piece capturedPiece = Board.RemovePiece(destination);

            Board.PlacePiece(piece, destination);
        }

        public void PlacePieces()
        {
            //White pieces
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('a',2).ToPosition());
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('b',2).ToPosition());
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('c',2).ToPosition());
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('d',2).ToPosition());
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('e',2).ToPosition());
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('f',2).ToPosition());
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('g',2).ToPosition());
            Board.PlacePiece(new Pawn(Color.White, Board), new ChessPosition('h',2).ToPosition());
            
            //Black pieces
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('a',7).ToPosition());
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('b',7).ToPosition());
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('c',7).ToPosition());
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('d',7).ToPosition());
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('e',7).ToPosition());
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('f',7).ToPosition());
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('g',7).ToPosition());
            Board.PlacePiece(new Pawn(Color.Black, Board), new ChessPosition('h',7).ToPosition());
            
            Board.PlacePiece(new Tower(Color.Black, Board), new ChessPosition('h',8).ToPosition());

        }

    }
}