using System.Collections.Generic;
using Battleship.Domain;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class ShipTests
    {
        [Fact]
        public void Ship_IsNotSunk_ForNonHitPosition()
        {
            var shipPositions = new List<Ship.Position>
            {
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 1,
                    IsHit = true
                },
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 2,
                    IsHit = true
                },
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 3,
                    IsHit = true
                },
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 4,
                },
            };

            var ship = new Ship(shipPositions);

            var isShipSunk = ship.IsSunk;

            isShipSunk.Should().BeFalse();
        }

        [Fact]
        public void Ship_IsSunk_ForAllHitPosition()
        {
            var shipPositions = new List<Ship.Position>
            {
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 1,
                    IsHit = true
                },
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 2,
                    IsHit = true
                },
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 3,
                    IsHit = true
                },
                new Ship.Position()
                {
                    Column = 'A',
                    Row = 4,
                    IsHit = true

                },
            };

            var ship = new Ship(shipPositions);

            var isShipSunk = ship.IsSunk;

            isShipSunk.Should().BeTrue();
        }
    }
}
