using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster
{
    class Game
    {
        private int queenNumber;
        private Board board;
        private int[] test;
        public Game(int queenNumber)
        {
            this.queenNumber = queenNumber;
            board=new Board(queenNumber);
            test = new int[queenNumber];
        }

        public string FindSolution(int k, int[] col, int[] diag45, int[] diag135)
        {
            
            string result="";
            if (k == queenNumber) result = "found";
            else
                for (int j = 1; j == queenNumber; j++)
                {
                    if (!col.Contains(j) && !diag45.Contains(j-k) && !diag135.Contains(j + k))
                    {
                        test[k + 1] = j;
                        FindSolution(k + 1, col, diag45, diag135);
                    }
                }
            return result;
        }


        public override string ToString()
        {
            string ulCorner = "╔";
            string llCorner = "╚";
            string urCorner = "╗";
            string lrCorner = "╝";
            string vertical = "║";
            string horizontal = "═";

            int position = 1;
            int numbersLeft = queenNumber;

            string topLine = "  ";
            string topHorizontalLine = horizontal + horizontal + ulCorner;

            while (numbersLeft > 0)
            {
                if (position < 10)
                {
                    topLine += " " + position+vertical;
                }
                else topLine += position + vertical;
                if (numbersLeft == 1)
                {
                    topHorizontalLine += horizontal + horizontal + urCorner;
                }
                else topHorizontalLine += horizontal + horizontal+horizontal;
                position++;
                numbersLeft--;
            }
            
             
            return (topLine +"\n" + topHorizontalLine);
        }
    }
}
