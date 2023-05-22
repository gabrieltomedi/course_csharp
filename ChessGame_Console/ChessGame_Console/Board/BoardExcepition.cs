using System;

namespace Board
{
    internal class BoardExcepition : Exception
    {
        public BoardExcepition(string msg) : base(msg)
        {
        }
    }
}
