using ChessBoard;

namespace Chess
{
    //This class defines the positions of board as the user will see.
    class ChessPosition
    {
        public char ChessColumn { get; set; }
        public int ChessLine { get; set; }

        public ChessPosition()
        {
        }

        public ChessPosition(char chessColumn, int chessLine)
        {
            ChessColumn = chessColumn;
            ChessLine = chessLine;
        }

        public Position ToPosition()
        {
            return new Position(8 - ChessLine, ChessColumn - 'a');
        }

        public override string ToString()
        {
            return "" + ChessColumn + ChessLine;
        }
    }
}