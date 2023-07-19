using Chess;
using ChessBoard;
using System;

namespace ChessConsole
{
    class Screen
    {
        public static void PrintGame(ChessGame game)
        {
            ShowBoard(game.Board);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.Write("Round: " + game.Round);
            Console.WriteLine();
            if (!game.Finished)
            {
                Console.Write("Actual player: " + game.ActualPlayer);
                Console.WriteLine();
                if (game.Check)
                {
                    Console.WriteLine(">> CHECK! <<");
                }
            }
            else
            {
                Console.WriteLine(">> CHECKMATE! <<");
                Console.WriteLine(game.ActualPlayer + " is the winner!");
            }
            Console.WriteLine();
        }

        public static void PrintCapturedPieces(ChessGame game)
        {
            ConsoleColor originColor = Console.ForegroundColor;

            Console.WriteLine("Captured pieces:");
            Console.Write("White pieces:");
            PrintPiecesInTheCollection(game.CapturedPiecesByColor(Color.White));
            Console.WriteLine();
            Console.Write("Black pieces:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintPiecesInTheCollection(game.CapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = originColor;
        }

        public static void PrintPiecesInTheCollection(HashSet<Piece> collection)
        {
            Console.Write("[");
            foreach (Piece piece in collection)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
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

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (isAPossibleMoves[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
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
            char[] validColumns = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            char[] validLines = { '1', '2', '3', '4', '5', '6', '7', '8' };

            string userPosition = Console.ReadLine();

            if (userPosition.Length != 2)
            {
                throw new BoardException("Something went wrong. Looks like this is the wrong format. Try again!");
            }

            if (!validColumns.Contains(userPosition[0]) || !validLines.Contains(userPosition[1]))
            {
                throw new BoardException("Something went wrong. Looks like this is the wrong format. Try again!");
            }

            char column = userPosition[0];
            int line = int.Parse(userPosition[1] + " ");

            // if(column.GetType() != typeof(char) || line.GetType() != typeof(int))
            // {
            //     throw new BoardException("Something went wrong. Looks like this is the wrong format. Try again!");
            // }


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