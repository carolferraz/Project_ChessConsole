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
        private bool CanMove(Position position)
        {

            Piece piece = Board.GetPiece(position);
            return piece == null || piece.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position possiblePosition = new Position(0, 0);

            //up
            possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.Line = possiblePosition.Line - 1;
            }
            //diagonal northeast
            possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.DefineNewPosition(possiblePosition.Line - 1, possiblePosition.Column + 1);
            }
            //left
            possiblePosition.DefineNewPosition(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.Column = possiblePosition.Column + 1;
            }
            //diagonal southeast
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.DefineNewPosition(possiblePosition.Line + 1, possiblePosition.Column + 1);

            }
            //down
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.Line = possiblePosition.Line + 1;
            }
            //diagonal southwest
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.DefineNewPosition(possiblePosition.Line + 1, possiblePosition.Column - 1);
            }
            //right
            possiblePosition.DefineNewPosition(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.Column = possiblePosition.Column - 1;
            }
            //Diagonal northwest
            possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
                if (Board.GetPiece(possiblePosition) != null && Board.GetPiece(possiblePosition).Color != this.Color)
                {
                    break;
                }
                possiblePosition.DefineNewPosition(possiblePosition.Line - 1, possiblePosition.Column - 1);

            }

            return matrix;
        }
    }
}
