// using ChessBoard;

// namespace Chess
// {
//     class Queen : Piece
//     {
//         public Queen(Color color, Board board) : base(color, board)
//         { 
//         }

//         public override string ToString()
//         {
//             return "Q";
//         }
//         private bool CanMove(Position position)
//         {

//             Piece piece = Board.GetPiece(position);
//             return piece != null || piece.Color != this.Color;
//         }

//         public override bool[,] PossibleMoves()
//         {
//             bool[,] matrix = new bool[Board.Lines, Board.Columns];

//             Position posiblePosition = new Position(0, 0);

//             //up
//             posiblePosition.DefineNewPosition(Position.Line - 1, Position.Column);
//             while (Board.ValidPosition(posiblePosition) && CanMove(posiblePosition))
//             {
//                 matrix[Position.Line, Position.Column] = true;
//                 if (Board.GetPiece(posiblePosition) != null && Board.GetPiece(posiblePosition).Color != this.Color)
//                 {
//                     break;
//                 }
//                 posiblePosition.Line = Position.Line - 1;
//             }

//             return matrix;
//         }
//     }
// }