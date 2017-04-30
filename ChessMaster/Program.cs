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
            int queens;
            Game newGame;
            Console.WriteLine("Check & Math");
            Console.WriteLine("How many queens?");
            queens = Convert.ToInt32(Console.ReadLine());
            newGame = new Game(queens);
            newGame.FindSolution();
            // Console.WriteLine(newGame.ToString());
            Console.WriteLine(newGame.resultsString());
            //Console.WriteLine("resultat : " + newGame.Test[0] + newGame.Test[1] + newGame.Test[2] + newGame.Test[3]);
            if (newGame.Results.Count > 0)
                newGame.Boardgame.fillBoard(newGame.Results[0]);
            Console.WriteLine(newGame.Boardgame.ToString());
            newGame.FindMultipleSolutions();
            Console.WriteLine(newGame.resultsString());
            Console.ReadLine();
        }
    }
}
