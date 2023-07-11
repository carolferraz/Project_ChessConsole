using ChessBoard;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        { 
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}