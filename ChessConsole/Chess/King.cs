using ChessBoard;

namespace Chess
{
    class King : Piece
    {
        private ChessGame Game { get; set; }

        public King(Color color, Board board, ChessGame game) : base(color, board)
        {
            Game = game;
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

        private bool CanCastleKingWithRook(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece is Rook && piece != null && piece.Color == Color && piece.AmountMoves == 0;
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

            //Special move castle
            if (!Game.Check && AmountMoves == 0)
            {
                //King side castle
                Position towerPosition1 = new Position(Position.Line, Position.Column + 3);
                if (CanCastleKingWithRook(towerPosition1))
                {
                    Position sideKingEmpty1 = new Position(Position.Line, Position.Column + 1);
                    Position sideKingEmpty2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.GetPiece(sideKingEmpty1) == null && Board.GetPiece(sideKingEmpty2) == null)
                    {
                        matrix[Position.Line, Position.Column + 2] = true;
                    }
                }
                //Queen side castle
                Position towerPosition2 = new Position(Position.Line, Position.Column - 4);
                if (CanCastleKingWithRook(towerPosition2))
                {
                    Position sideKingEmpty1 = new Position(Position.Line, Position.Column - 1);
                    Position sideKingEmpty2 = new Position(Position.Line, Position.Column - 2);
                    Position sideKingEmpty3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.GetPiece(sideKingEmpty1) == null && Board.GetPiece(sideKingEmpty2) == null && Board.GetPiece(sideKingEmpty3) == null)
                    {
                        matrix[Position.Line, Position.Column - 2] = true;
                    }
                }

            }


            return matrix;
        }
    }
}