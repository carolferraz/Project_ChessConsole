using ChessBoard;

namespace Chess
{
    class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "H";
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

            //up right
            possiblePosition.DefineNewPosition(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //right up
            possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //right down
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //down right
            possiblePosition.DefineNewPosition(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }

            //down left
            possiblePosition.DefineNewPosition(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //left down
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //left up
            possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //up left
            possiblePosition.DefineNewPosition(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }


            return matrix;
        }
    }
}