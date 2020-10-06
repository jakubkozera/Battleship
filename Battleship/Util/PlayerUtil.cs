using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Domain;

namespace Battleship.Util
{
    public static class PlayerUtil
    {
        public static Ship.Position GenerateTargetShipPositionAgainstPlayer(Player player)
        {
            var random = new Random();
            Ship.Position position;
            do
            {
                position = new Ship.Position()
                {
                    Row = random.Next(1, 10),
                    Column = (char)('A' + random.Next(0, 9))
                };


            } while (!IsTargetable(position, player));

            return position;
        }


        public static Ship.Position GetPlayerTargetShipPosition()
        {
            Console.WriteLine("Input position to fire at:");
            var inputPosition = Console.ReadLine();

            while (!IsValid(inputPosition))
            {
                Console.WriteLine("Input correct position to fire at [format (A-J|1-10)]:");
                inputPosition = Console.ReadLine();
            }

            var shipPosition = new Ship.Position()
            {
                Column = inputPosition![0],
                Row = int.Parse(inputPosition[1..])

            };

            return shipPosition;
        }

        private static bool IsTargetable(Ship.Position position, Player player) =>
            !player.Misses.Contains(position) && !player.Hits.Contains(position);

        private static bool IsValid(string inputPosition)
        {
            if (inputPosition.Length < 2 || inputPosition.Length > 3)
                return false;

            var column = inputPosition[0];
            if (column < 'A' || column> 'J')
                return false;

            var rowAsString = inputPosition[1..];
            if (!int.TryParse(rowAsString, out var row))
                return false;
            
            if(row < 1 || row > 10)
                return false;

            return true;
        }
    }
}
