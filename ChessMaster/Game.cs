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
        public Board Boardgame { get; }
        public int[] Test { get; }
        //private bool found = false;
        public List<List<int>> Results { get; }
        private int resultsCount = 0;

        public Game(int queenNumber)
        {
            this.queenNumber = queenNumber;
            Boardgame = new Board(queenNumber);
            Test = new int[queenNumber];
            Results = new List<List<int>>();
        }

        public void ClearOldRequest()
        {
            resultsCount = 0;
            Results.Clear();
        }

        public bool FindSolution()
        {
            ClearOldRequest();
            bool found = false;
                for (int j = 1; j < queenNumber + 1; j++)
                {
                    for (int m = 1; m < queenNumber; m++)
                        Test[m] = 0;
                    Test[0] = j;
                    List<int> col = new List<int>();
                    List<int> diag45 = new List<int>();
                    List<int> diag135 = new List<int>();
                    col.Add(Test[0]);
                    diag45.Add(Test[0]);
                    diag135.Add(Test[0]);
                    //Console.WriteLine("k[0] = " + Test[0]);
                    found = FindSolution(1, col, diag45, diag135);
                    if (found) return true;
                }

            return false;
        }

        public bool FindSolution(int k, List<int> inputCol, List<int> inputDiag45, List<int> inputDiag135)
        {
            bool found = false;
            if (k == queenNumber)
            {
                List<int> testTmp = new List<int>();
                foreach (int val in Test)
                {
                    testTmp.Add(val);
                }
                Results.Add(testTmp);
                resultsCount++;
                found = true;
            }
            else
            {
                for (int j = 1; j < queenNumber + 1; j++)
                {
                    for (int m = k + 1; m < queenNumber; m++)
                        Test[m] = 0;

                    if (!inputCol.Contains(j) && !inputDiag45.Contains(j - k) && !inputDiag135.Contains(j + k))
                    {
                        Test[k] = j;
                        List<int> col = new List<int>();
                        foreach (int val in inputCol)
                        {
                            col.Add(val);
                        }
                        col.Add(j);
                        List<int> diag45 = new List<int>();
                        foreach (int val in inputDiag45)
                        {
                            diag45.Add(val);
                        }
                        diag45.Add(j - k);
                        List<int> diag135 = new List<int>(inputDiag135);
                        foreach (int val in inputDiag135)
                        {
                            diag135.Add(val);
                        }
                        diag135.Add(j + k);
                        //Console.WriteLine("next, marche à k= " + k + " j= " + j);

                        found = FindSolution(k + 1, col, diag45, diag135);
                        if (found) return true;
                    }
                    //else Console.WriteLine("bloqué à k= "+k+" j= "+j);
                }
            }
            return found;
        }

        public void FindMultipleSolutions()
        {
            ClearOldRequest();
            for (int j = 1; j < queenNumber + 1; j++)
            {
                for (int m = 1; m < queenNumber; m++)
                    Test[m] = 0;
                Test[0] = j;
                List<int> col = new List<int>();
                List<int> diag45 = new List<int>();
                List<int> diag135 = new List<int>();
                col.Add(Test[0]);
                diag45.Add(Test[0]);
                diag135.Add(Test[0]);
                //Console.WriteLine("k[0] = " + Test[0]);
                FindMultipleSolutions(1, col, diag45, diag135);
            }
        }

        public void FindMultipleSolutions(int k, List<int> inputCol, List<int> inputDiag45, List<int> inputDiag135)
        {
            if (k == queenNumber)
            {
                List<int> testTmp = new List<int>();
                foreach (int val in Test)
                {
                    testTmp.Add(val);
                }
                Results.Add(testTmp);
                resultsCount++;
            }
            else
            {
                for (int j = 1; j < queenNumber + 1; j++)
                {
                    for (int m = k + 1; m < queenNumber; m++)
                        Test[m] = 0;

                    if (!inputCol.Contains(j) && !inputDiag45.Contains(j - k) && !inputDiag135.Contains(j + k))
                    {
                        Test[k] = j;
                        List<int> col = new List<int>();
                        foreach (int val in inputCol)
                        {
                            col.Add(val);
                        }
                        col.Add(j);
                        List<int> diag45 = new List<int>();
                        foreach (int val in inputDiag45)
                        {
                            diag45.Add(val);
                        }
                        diag45.Add(j - k);
                        List<int> diag135 = new List<int>(inputDiag135);
                        foreach (int val in inputDiag135)
                        {
                            diag135.Add(val);
                        }
                        diag135.Add(j + k);
                        //Console.WriteLine("next, marche à k= " + k + " j= " + j);

                        FindMultipleSolutions(k + 1, col, diag45, diag135);
                    }
                    //else Console.WriteLine("bloqué à k= "+k+" j= "+j);
                }
            }
        }


        public string resultsString()
        {
            string result = "";
            for (int a = 0; a < resultsCount; a++)
            {
                foreach (int i in Results[a])
                    result += i + " ";
                result += "\n";
            }
            return result + "count = " + resultsCount;
        }

        public override string ToString()
        {
            return ("\n");
        }
    }
}
