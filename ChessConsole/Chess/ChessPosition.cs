using ChessBoard;

namespace Chess
{
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
            return new Position(ChessLine - 8, ChessColumn - 'a');
        }

        public override string ToString()
        {
            return "" + ChessColumn + ChessLine;
        }
    }
}