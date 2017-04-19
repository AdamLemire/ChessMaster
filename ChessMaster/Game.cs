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
      
        public string FindSolution(int k, List<int> col, List<int> diag45, List<int> diag135)
        {
            
            string result="";
            if (k == queenNumber)
            {
                result = "found ";
                foreach (int i in test)
                {
                    result += i + ",";
                }
            }
            else
                for (int j = 1; j == queenNumber; j++)
                {
                    if (!col.Contains(j) && !diag45.Contains(j - k) && !diag135.Contains(j + k))
                    {
                        test[k] = j;
                        List<int> newCol = col;
                        newCol.Add(j);
                        List<int> newDiag45 = diag45;
                        newDiag45.Add(j - k);
                        List<int> newDiag135 = diag135;
                        newDiag135.Add(j + k);
                        FindSolution(k + 1, newCol, newDiag45, newDiag135);
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
