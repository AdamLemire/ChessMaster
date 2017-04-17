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
            Console.WriteLine(newGame.ToString());

            Console.ReadLine();
        }
    }
}
