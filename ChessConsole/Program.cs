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

                    Console.WriteLine(" ");
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition();

                    bool[,] matrixWithPossibleMoves = game.Board.GetPiece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.ShowBoard(game.Board, matrixWithPossibleMoves);


                    Console.WriteLine(" ");
                    Console.Write("Destino: ");
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