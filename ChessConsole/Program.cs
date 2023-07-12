using Chess;
using ChessBoard;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try{

            Board board = new Board(8, 8);

            board.PlacePiece(new King(Color.Black, board), new Position(0,0));
            board.PlacePiece(new King(Color.Black, board), new Position(1,3));
            board.PlacePiece(new Tower(Color.Black, board), new Position(2,4));
            board.PlacePiece(new Tower(Color.Black, board), new Position(6,4));
            board.PlacePiece(new King(Color.White, board), new Position(7,0));
            board.PlacePiece(new King(Color.White, board), new Position(7,5));
            board.PlacePiece(new King(Color.White, board), new Position(6,8));

            Screen.ShowBoard(board);

            }
            catch (BoardException e)
            {
                Console.WriteLine("Ops, we found an error: " + e.Message);
            }
            Console.ReadLine();

        }
    }
}