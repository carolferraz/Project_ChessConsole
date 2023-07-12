using Chess;
using ChessBoard;

namespace ChessConsole
{
    class Screen
    {
        public static void ShowBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.GetPiece(i, j) == null) Console.Write("- ");
                    else
                    {
                        PrintPiece(board.GetPiece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static Position ReadChessPosition()
        {
            string userPosition = Console.ReadLine();
            char column = userPosition[0];
            int line = int.Parse(userPosition[1] + " ");
            
            return new ChessPosition(column, line).ToPosition();

        }
        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor baseColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(piece);
                Console.ForegroundColor = baseColor;
            }
        }
    }
}