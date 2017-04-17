using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster
{
    class Board
    {
        public int QueenNumber { get; private set; }
        public int[,] BoardGrid { get; set; }
        public Board(int queenNumber)
        {
            this.QueenNumber = queenNumber;
            BoardGrid = new int[queenNumber,queenNumber];
        }
    }
}
