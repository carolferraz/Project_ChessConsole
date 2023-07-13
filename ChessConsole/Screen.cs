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
                    PrintPiece(board.GetPiece(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ShowBoard(Board board, bool[,] isAPossibleMoves)
        {
            ConsoleColor originBg = Console.BackgroundColor;
            ConsoleColor changedBg = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (isAPossibleMoves[i, j])
                    {
                        Console.BackgroundColor = changedBg;
                    }
                    else
                    {
                        Console.BackgroundColor = originBg;
                    }

                    PrintPiece(board.GetPiece(i, j));
                    Console.BackgroundColor = originBg;
                }
                Console.WriteLine();
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}