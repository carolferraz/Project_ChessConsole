using Chess;
using ChessBoard;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                ChessGame game = new ChessGame();

                while (!game.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.ShowBoard(game.Board);

                        Console.WriteLine();
                        Console.Write("Turn: " + game.Turn);
                        Console.WriteLine();
                        Console.Write("Actual player: " + game.ActualPlayer);
                        Console.WriteLine(" ");
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition();
                        game.ValidateOriginPosition(origin);

                        bool[,] matrixWithPossibleMoves = game.Board.GetPiece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.ShowBoard(game.Board, matrixWithPossibleMoves);


                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition();
                        game.ValidadeDestinyPosition(origin, destiny);

                        game.MakeAMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine("Ops! " + e.Message);
                        Console.ReadLine();

                    }
                }


            }
            catch (BoardException e)
            {
                Console.WriteLine("Ops, we found an error: " + e.Message);
            }
            Console.ReadLine();

        }
    }
}