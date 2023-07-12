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
                    Console.Clear();
                    Screen.ShowBoard(game.Board);

                    Console.WriteLine("Origem: ");
                    Position origin = Screen.ReadChessPosition();
                    Console.WriteLine("Destino: ");
                    Position destiny = Screen.ReadChessPosition();

                    game.MakeAMove(origin, destiny);
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