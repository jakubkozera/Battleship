using System;
using Battleship.Service;
using Battleship.Util;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start new game!");
            Console.ReadLine();

            var game = GameUtil.CreateNewGame();
            var gameService = new GameService();
            gameService.Start(game);
        }
    }
}
