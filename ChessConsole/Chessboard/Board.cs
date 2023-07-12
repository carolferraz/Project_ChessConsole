namespace ChessBoard
{
    //This class defines the structure of the board itself.
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
        public Piece GetPiece(Position position)
        {
            return _pieces[position.Line, position.Column];
        }

        public bool HasPiece(Position position)
        {
            CheckValidPosition(position);
            return GetPiece(position) != null;
        }

        public void PlacePiece(Piece passedPiece, Position passedPosition)
        {
            if (HasPiece(passedPosition))
            {
                throw new BoardException("The board already has a piece in this position.");
            }
            _pieces[passedPosition.Line, passedPosition.Column] = passedPiece;
            passedPiece.Position = passedPosition;
        }

        public Piece RemovePiece(Position passedPosition)
        {
            if(GetPiece(passedPosition) == null) return null;
            
            Piece removedPiece = GetPiece(passedPosition);
            removedPiece.Position = null;
            _pieces[passedPosition.Line, passedPosition.Column] = null;
            return removedPiece;
            
        }

        public bool ValidPosition(Position position)    
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void CheckValidPosition (Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }

    }
}