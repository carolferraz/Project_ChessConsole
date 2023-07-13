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

            Position posiblePosition = new Position(0, 0);

            //up
            posiblePosition.DefineNewPosition(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }
            //northest
            posiblePosition.DefineNewPosition(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }
            //right
            posiblePosition.DefineNewPosition(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }
            //southeast
            posiblePosition.DefineNewPosition(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }

            //down
            posiblePosition.DefineNewPosition(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }
            //southwest
            posiblePosition.DefineNewPosition(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }
            //left
            posiblePosition.DefineNewPosition(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }
            //northwest
            posiblePosition.DefineNewPosition(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
            {
                matrix[posiblePosition.Line, posiblePosition.Column] = true;
            }


            return matrix;
        }
    }
}