using ChessBoard;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
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
