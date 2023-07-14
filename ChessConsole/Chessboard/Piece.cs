namespace ChessBoard
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece()
        {
        }

        public Piece(Color color, Board board)
        {
            Color = color;
            Board = board;
            Position = null;
            AmountMoves = 0;
        }

        public void IncrementAmountMoves()
        {
            AmountMoves++;
        }
        public void DecrementAmountMoves()
        {
            AmountMoves--;
        }

        public bool ThereIsPossibleMoves() //We create this method to check in the ChessGame, where are the mechanics of the game, if it will send a error in case that the piece is blocked.
        {
            bool[,] moves = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (moves[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position destiny)
        {
            return PossibleMoves()[destiny.Line, destiny.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}