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
        public List<List<int>> Results { get; }
        public List<List<int>> KTupleList { get; }
        private int resultsCount = 0;
        private int[] kTupleCount;

        public Game(int queenNumber)
        {
            this.queenNumber = queenNumber;
            Boardgame = new Board(queenNumber);
            Test = new int[queenNumber];
            kTupleCount = new int[queenNumber];
            Results = new List<List<int>>();
            KTupleList = new List<List<int>>();
        }

        public void ClearOldRequest()
        {
            kTupleCount = new int[queenNumber];
            resultsCount = 0;
            Results.Clear();
        }

        //pour trouver la première solution
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
                kTupleCount[0]++;
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
                        kTupleCount[k]++;
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

                        found = FindSolution(k + 1, col, diag45, diag135);
                        if (found) return true;
                    }
                }
            }
            return found;
        }

        //pour trouver toutes les solutions
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
                kTupleCount[0]++;
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
                List<int> kTupleTmp = new List<int>();
                foreach (int val in kTupleCount)
                {
                    kTupleTmp.Add(val);
                }
                KTupleList.Add(kTupleTmp);
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
                        kTupleCount[k]++;
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
                        FindMultipleSolutions(k + 1, col, diag45, diag135);
                    }
                }
            }
        }

        //retourne le nombre de solutions trouvées
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

        public string validCountString()
        {
            return "Number of possible solutions for " + queenNumber + " queens = " + resultsCount + "  <-----";
        }

        //retourne le nombre de k-tuples prometteurs pour l'ensemble du tableau
        public string kTupleCountString()
        {
            string kCountString = "";
            int totalTupleCount = 0;
            for (int i = 0; i < kTupleCount.Length; i++)
            {
                kCountString += "Number of promising " + (i + 1) + "-tuple = " + kTupleCount[i] + "\n";
                totalTupleCount += kTupleCount[i];
            }
            kCountString += "Total number of promising k-tuple, including found solutions = " + totalTupleCount;
            return kCountString;
        }

        //retourne le nombre de k-tuples prometteurs, du départ jusqu'à la solution choisie, incluant les solutions trouvées
        public string kTupleCountCumulativeString(int solution)
        {
            string kCountString = "";
            int totalTupleCount = 0;
            List<int> kTupleTmp = new List<int>();
            foreach (int val in KTupleList[solution - 1])
            {
                kTupleTmp.Add(val);
            }
            for (int i = 0; i < kTupleTmp.Count; i++)
            {
                kCountString += "Number of promising " + (i + 1) + "-tuple = " + kTupleTmp[i] + "\n";
                totalTupleCount += kTupleTmp[i];
            }
            kCountString += "Total number of promising k-tuple = " + totalTupleCount;
            return kCountString;
        }
    }
}
