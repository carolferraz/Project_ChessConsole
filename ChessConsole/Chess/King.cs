using ChessBoard;

namespace Chess
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "K";
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
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //northest
            possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //right
            possiblePosition.DefineNewPosition(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //southeast
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }

            //down
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //southwest
            possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //left
            possiblePosition.DefineNewPosition(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }
            //northwest
            possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
            {
                matrix[possiblePosition.Line, possiblePosition.Column] = true;
            }


            return matrix;
        }
    }
}