using System;
using System.Linq;
using Battleship.Domain;

namespace Battleship.Util
{
    public static class GameUtil
    {
        public static Game CreateNewGame()
        {
            var computer = new Player()
            {
                Ships = ShipUtil.GeneratePlayerShips()
            };

            var realPlayer = new Player()
            {
                Ships = ShipUtil.GeneratePlayerShips()
            };
            var newGame = new Game()
            {
                ComputerPlayer = computer,
                RealPlayer = realPlayer
            };

            return newGame;
        }

        public static void Display(Game game)
        {
            Console.WriteLine("Your board");
            DisplayBoard(game.RealPlayer, false);
            Console.WriteLine("*********************");
            Console.WriteLine("Computer board");
            DisplayBoard(game.ComputerPlayer);
        }

        private static void DisplayBoard(Player player, bool hidePlayerShips = true)
        {
            DisplayHeaderRow();
   
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i} \t");

                for (int j = 0; j < 10; j++)
                {
                    var position = new Ship.Position()
                    {
                        Row = i,
                        Column = (char)('A' + j)
                    };
                    var positionMark = GetPositionMark(position, player, hidePlayerShips);

                    Console.Write($"{positionMark} ");


                }

                Console.WriteLine();

            }

        }

        private static void DisplayHeaderRow()
        {
            Console.Write("\t");

            for (int i = 0; i < 10; i++)
            {
                var column = (char)('A' + i);
                Console.Write($"{column} ");
            }

            Console.WriteLine();

        }

        private static string GetPositionMark(Ship.Position position, Player player, bool hidePlayerShips)
        {
            if (player.Hits.Contains(position))
                return "X";
            if (player.Misses.Contains(position))
                return "O";
            if (!hidePlayerShips && player.Ships.Any(s => s.Positions.Contains(position)))
                return "S";

            return "-";
        }
    }
}
