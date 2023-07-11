namespace ChessBoard
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] _pieces;

        public Board()
        {
        }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            _pieces = new Piece[Lines, Columns];
        }

        public Piece GetPiece(int line, int columns)
        {
            return _pieces[line, columns];
        }

        public void PlacePiece(Piece passedPiece, Position passedPosition)
        {
            _pieces[passedPosition.Line, passedPosition.Column] = passedPiece;
            passedPiece.Position = passedPosition;
        }
    }
}