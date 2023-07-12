using System;

namespace ChessBoard
{
    class BoardException : ApplicationException
    {
        public BoardException(string message) : base(message)
        {}
    }
}