using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster
{
    class Board
    {
        private int queenNumber;
        public int[,] BoardGrid { get; set; }
        private List<int> validSolution;

        public Board(int queenNumber)
        {
            this.queenNumber = queenNumber;
            BoardGrid = new int[queenNumber, queenNumber];
        }

        public void fillBoard(List<int> validSolution)
        {
            this.validSolution = new List<int>(validSolution);
        }

        public override string ToString()
        {
            if (validSolution == null)
                return "No solution found";

            string ulCorner = "╔";
            string llCorner = "╚";
            string urCorner = "╗";
            string lrCorner = "╝";
            string vertical = "║";
            string horizontal = "═";

            string topHorizontalLine = "";
            string fullOutput = "";
            string cases = "";

            int numbersLeft = queenNumber;

            string espace = " ";

            //ligne du haut
            topHorizontalLine = ulCorner;

            while (numbersLeft > 0)
            {
                if (numbersLeft == 1)
                {
                    topHorizontalLine += horizontal + horizontal + horizontal + horizontal + urCorner;
                }
                else topHorizontalLine += horizontal + horizontal + horizontal + horizontal + horizontal;
                numbersLeft--;
            }

            //ligne du bas
            string bottomLine = "\n" + llCorner;
            numbersLeft = queenNumber;

            while (numbersLeft > 0)
            {
                if (numbersLeft == 1)
                {
                    bottomLine += horizontal + horizontal + horizontal + horizontal + lrCorner;
                }
                else bottomLine += horizontal + horizontal + horizontal + horizontal + horizontal;
                numbersLeft--;
            }

            //cases du tableau
            for (int line = 0; line < queenNumber; line++)
            {
                int numberSquareLeft = queenNumber;
                int casePosition = 0;
                if (line != 0)
                {
                    cases += "\n" + vertical;
                    while (numberSquareLeft > 0 && line != 0)
                    {
                        cases += horizontal + horizontal + horizontal + horizontal + vertical;
                        numberSquareLeft--;
                    }
                }

                cases += "\n" + vertical;
                numberSquareLeft = queenNumber;
                while (numberSquareLeft > 0)
                {
                    if (validSolution[line] - 1 == casePosition)
                    {
                        cases += espace + " X" + espace + vertical;
                    }
                    else cases += espace + espace + espace + espace + vertical;
                    numberSquareLeft--;
                    casePosition++;
                }
            }
            return (topHorizontalLine + cases + bottomLine);
        }
    }
}
