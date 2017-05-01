using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            Game newGame;

            do
            {
                Console.WriteLine("Check & Math");
                Console.WriteLine("How many queens?");
                int queens = Convert.ToInt32(Console.ReadLine());
                newGame = new Game(queens);
                Console.WriteLine("How many solutions?");
                Console.WriteLine("[1] - 1 solution");
                Console.WriteLine("[2] - all solutions");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        {
                            newGame.FindSolution();
                            if (newGame.Results.Count > 0)
                                newGame.Boardgame.fillBoard(newGame.Results[0]);
                            Console.WriteLine(newGame.Boardgame.ToString());
                            Console.WriteLine("Number of promising k-tuples BEFORE the solution :");
                            Console.WriteLine(newGame.kTupleCountString());
                            break;
                        }
                    case 2:
                        {
                            newGame.FindMultipleSolutions();
                            if (newGame.Results.Count > 0 && newGame.Results.Count < 4)
                            {
                                for (int i = 0; i < newGame.Results.Count; i++)
                                {
                                    newGame.Boardgame.fillBoard(newGame.Results[i]);
                                    Console.WriteLine(newGame.Boardgame.ToString());
                                    Console.WriteLine("Number of promising k-tuples for the solution #" + (i + 1) + ", including found solutions, from the start :");
                                    Console.WriteLine(newGame.kTupleCountCumulativeString(i + 1));
                                    Console.WriteLine("------------------------------------");
                                }
                            }
                            else if (newGame.Results.Count > 0)
                                for (int i = 0; i < 4; i++)
                                {
                                    newGame.Boardgame.fillBoard(newGame.Results[i]);
                                    Console.WriteLine(newGame.Boardgame.ToString());
                                    Console.WriteLine("Number of promising k-tuples for the solution #" + (i + 1) + ", including found solutions :");
                                    Console.WriteLine(newGame.kTupleCountCumulativeString(i + 1));
                                    Console.WriteLine("------------------------------------");
                                }

                            Console.WriteLine(newGame.validCountString());
                            Console.WriteLine("TOTAL Number of promising k-tuples :");
                            Console.WriteLine(newGame.kTupleCountString());
                            break;
                        }

                }
                Console.WriteLine("\nPress [Q] to quit, press Enter to continue");
                string quitChoice = Console.ReadLine().ToUpper();
                if (quitChoice == "Q") done = true;
            } while (!done);
        }
    }
}
