using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Domain;

namespace Battleship.Util
{
    public static class ShipUtil
    {
        private const int _boardRange = 10;
        public static List<Ship> GeneratePlayerShips()
        {
            var ships = new List<Ship>();
            var battleShip = GetShip(5, ships);
            ships.Add(battleShip);

            var destroyer1 = GetShip(4, ships);
            ships.Add(destroyer1);

            var destroyer2 = GetShip(4, ships);
            ships.Add(destroyer2);

            return ships;
        }

        private static Ship GetShip(int width, List<Ship> ships)
        {
            var random = new Random();

            while (true)
            {
                var randomShipPosition = GenerateRandomShipPosition();

                if (!IsPositionOccupied(randomShipPosition, ships))
                {
                    var randomDirection = (Direction)random.Next(0, 4);
                    var canPlaceShip = CanPlaceShip(randomDirection, randomShipPosition, width, ships, out var placedShipPositions);
                    if (canPlaceShip)
                    {
                        var placedShip = new Ship(placedShipPositions);
                        return placedShip;
                    }
                }
            }
        }


        private static bool CanPlaceShip(Direction direction, Ship.Position position, int width, List<Ship> ships, out List<Ship.Position> placedShipPositions)
        {
            placedShipPositions = new List<Ship.Position> { position };

            for (int i = 1; i < width; i++)
            {
                position = GetNextPosition(position, direction);
                if (IsPositionOccupied(position, ships) || !IsInBoundaries(position))
                {
                    return false;
                }
                placedShipPositions.Add(position);
            }

            return true;
        }

        private static bool IsInBoundaries(Ship.Position position)
            => position.Row >= 1 && position.Row <= 10
            && position.Column >= 'A' && position.Column <= 'J';

        private static Ship.Position GetNextPosition(Ship.Position position, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Ship.Position()
                    {
                        Column = position.Column,
                        Row = position.Row + 1
                    };
                case Direction.Right:
                    return new Ship.Position()
                    {
                        Column = (char)(position.Column + 1),
                        Row = position.Row
                    };
                case Direction.Down:
                    return new Ship.Position()
                    {
                        Column = position.Column,
                        Row = position.Row - 1
                    };
                case Direction.Left:
                    return new Ship.Position()
                    {
                        Column = (char)(position.Column - 1),
                        Row = position.Row
                    };
                default:
                    throw new InvalidEnumArgumentException($"{direction} is invalid argument");
            }
        }


        private static bool IsPositionOccupied(Ship.Position shipPosition, List<Ship> ships)
            => ships.Any(s => s.Positions.Contains(shipPosition));

        private static Ship.Position GenerateRandomShipPosition()
        {
            var random = new Random();
            var randomRow = random.Next(1, _boardRange + 1);
            var randomColumn = (char)('A' + random.Next(0, _boardRange));

            var randomShipPosition = new Ship.Position()
            {
                Row = randomRow,
                Column = randomColumn
            };

            return randomShipPosition;
        }
    }
}
