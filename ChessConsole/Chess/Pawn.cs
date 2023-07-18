using ChessBoard;

namespace Chess
{
    class Pawn : Piece
    {
        private ChessGame Game;
        public Pawn(Color color, Board board, ChessGame game) : base(color, board)
        {
            Game = game;
        }

        public override string ToString()
        {
            return "p";
        }
        private bool CanMove(Position position)
        {
            return Board.GetPiece(position) == null;
        }

        private bool ThereIsAnEnemy(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != this.Color;
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position possiblePosition = new Position(0, 0);

            //White
            if (Color == Color.White)
            {
                //first move
                possiblePosition.DefineNewPosition(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition) && AmountMoves == 0)
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }
                //default move
                possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }
                //Has enemy at left
                possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(possiblePosition) && ThereIsAnEnemy(possiblePosition))
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }
                //Has enemy at right
                possiblePosition.DefineNewPosition(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(possiblePosition) && ThereIsAnEnemy(possiblePosition))
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }

                //Special move: En Passant
                if (Position.Line == 3)
                {
                    Position positionLeft = new Position(Position.Line, Position.Column - 1);

                    if (Board.ValidPosition(positionLeft) && ThereIsAnEnemy(positionLeft) && Board.GetPiece(positionLeft) == Game.VulnerableEnPassant)
                    {
                        matrix[positionLeft.Line - 1, positionLeft.Column] = true;
                    }

                    Position positionRight = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(positionRight) && ThereIsAnEnemy(positionRight) && Board.GetPiece(positionRight) == Game.VulnerableEnPassant)
                    {
                        matrix[positionRight.Line - 1, positionRight.Column] = true;
                    }
                }

            }
            else
            {
                //first move
                possiblePosition.DefineNewPosition(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition) && AmountMoves == 0)
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }
                //default move
                possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(possiblePosition) && CanMove(possiblePosition))
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }
                //Has enemy at left
                possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(possiblePosition) && ThereIsAnEnemy(possiblePosition))
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }
                //Has enemy at right
                possiblePosition.DefineNewPosition(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(possiblePosition) && ThereIsAnEnemy(possiblePosition))
                {
                    matrix[possiblePosition.Line, possiblePosition.Column] = true;
                }

                //Special move: En Passant
                if (Position.Line == 4)
                {
                    Position positionLeft = new Position(Position.Line, Position.Column - 1);

                    if (Board.ValidPosition(positionLeft) && ThereIsAnEnemy(positionLeft) && Board.GetPiece(positionLeft) == Game.VulnerableEnPassant)
                    {
                        matrix[positionLeft.Line + 1, positionLeft.Column] = true;
                    }

                    Position positionRight = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(positionRight) && ThereIsAnEnemy(positionRight) && Board.GetPiece(positionRight) == Game.VulnerableEnPassant)
                    {
                        matrix[positionRight.Line + 1, positionRight.Column] = true;
                    }
                }

            }

            return matrix;
        }
    }
}