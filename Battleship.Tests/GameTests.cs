using System.Collections.Generic;
using Battleship.Domain;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_HasNoWinner_ForPlayersWithShipsNotSunk()
        {
            var game = TestGame.Instance;

            var realPlayerLost = game.RealPlayerLost;
            var computerPlayerLost = game.ComputerPlayerLost;

            realPlayerLost.Should().BeFalse();
            computerPlayerLost.Should().BeFalse();
        }

        [Fact]
        public void Game_IsWonByRealPlayer_ForComputerPlayerWithShipsSunk()
        {
            var sunkShip = new Ship(
                new List<Ship.Position>()
                {
                    new Ship.Position() {IsHit = true},
                    new Ship.Position() {IsHit = true},
                });

            var notSunkShip = new Ship(
                new List<Ship.Position>()
                {
                    new Ship.Position() {IsHit = true},
                    new Ship.Position() {IsHit = false},
                });



            var realPlayer = new Player()
            {
                Ships = new List<Ship> { notSunkShip }
            };

            var computerPlayer = new Player()
            {
                Ships = new List<Ship> { sunkShip }

            };

            var game = new Game
            {
                RealPlayer = realPlayer,
                ComputerPlayer = computerPlayer
            };

            var realPlayerLost = game.RealPlayerLost;
            var computerPlayerLost = game.ComputerPlayerLost;

            realPlayerLost.Should().BeFalse();
            computerPlayerLost.Should().BeTrue();
        }
        [Fact]
        public void Game_IsWonByComputerPlayer_ForRealPlayerWithShipsSunk()
        {
            var sunkShip = new Ship(
                new List<Ship.Position>()
                {
                    new Ship.Position() {IsHit = true},
                    new Ship.Position() {IsHit = true},
                });

            var notSunkShip = new Ship(
                new List<Ship.Position>()
                {
                    new Ship.Position() {IsHit = true},
                    new Ship.Position() {IsHit = false},
                });



            var realPlayer = new Player()
            {
                Ships = new List<Ship> { sunkShip }
            };

            var computerPlayer = new Player()
            {
                Ships = new List<Ship> { notSunkShip }

            };

            var game = new Game
            {
                RealPlayer = realPlayer,
                ComputerPlayer = computerPlayer
            };

            var realPlayerLost = game.RealPlayerLost;
            var computerPlayerLost = game.ComputerPlayerLost;

            realPlayerLost.Should().BeTrue();
            computerPlayerLost.Should().BeFalse();
        }

    }
}
