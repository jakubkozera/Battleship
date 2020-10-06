using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Domain;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class PlayerTests
    {
        private static Game _game;
        private static Player _realPlayer;
        private static Player _computerPlayer;
        static PlayerTests()
        {
            _game = TestGame.Instance;
            _realPlayer = _game.RealPlayer;
            _computerPlayer = _game.ComputerPlayer;
        }

        public static IEnumerable<object[]> ComputerShipsPositions =>
            Helpers.ToMemberData(_computerPlayer.Ships.SelectMany(s => s.Positions));
        public static IEnumerable<object[]> PlayerShipsPositions =>
            Helpers.ToMemberData(_realPlayer.Ships.SelectMany(s => s.Positions));

        [Theory]
        [MemberData(nameof(ComputerShipsPositions))]
        public void RealPlayer_FireAtOpponent_OnShipPosition_ReturnsHitResult(char column, int row)
        {
            var game = TestGame.Instance;

            var realPlayer = game.RealPlayer;
            var computerPlayer = game.ComputerPlayer;

            var position = new Ship.Position()
            {
                Column = column,
                Row = row
            };

            var fireResult = realPlayer.FireAtOpponent(computerPlayer, position);
            fireResult.Should().Be(FireResult.Hit);

            var computerPlayerContainHit = computerPlayer.Hits.Contains(position);
            computerPlayerContainHit.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(PlayerShipsPositions))]
        public void RealPlayer_FireAtOpponent_NotOnShipPosition_ReturnsMissResult(char column, int row)
        {
            var game = TestGame.Instance;

            var realPlayer = game.RealPlayer;
            var computerPlayer = game.ComputerPlayer;

            var position = new Ship.Position()
            {
                Column = column,
                Row = row
            };

            var fireResult = realPlayer.FireAtOpponent(computerPlayer, position);
            fireResult.Should().Be(FireResult.Miss);

            var computerPlayerContainMiss = computerPlayer.Misses.Contains(position);
            computerPlayerContainMiss.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(PlayerShipsPositions))]
        public void ComputerPlayer_FireAtOpponent_OnShipPosition_ReturnsHitResult(char column, int row)
        {
            var game = TestGame.Instance;

            var realPlayer = game.RealPlayer;
            var computerPlayer = game.ComputerPlayer;

            var position = new Ship.Position()
            {
                Column = column,
                Row = row
            };

            var fireResult = computerPlayer.FireAtOpponent(realPlayer, position);
            fireResult.Should().Be(FireResult.Hit);

            var realPlayerContainHit = realPlayer.Hits.Contains(position);
            realPlayerContainHit.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(ComputerShipsPositions))]
        public void ComputerPlayer_FireAtOpponent_NotOnShipPosition_ReturnsMissResult(char column, int row)
        {
            var game = TestGame.Instance;

            var realPlayer = game.RealPlayer;
            var computerPlayer = game.ComputerPlayer;

            var position = new Ship.Position()
            {
                Column = column,
                Row = row
            };

            var fireResult = computerPlayer.FireAtOpponent(realPlayer, position);
            fireResult.Should().Be(FireResult.Miss);

            var realPlayerContainMiss = realPlayer.Misses.Contains(position);
            realPlayerContainMiss.Should().BeTrue();
        }

        [Fact]
        public void RealPlayer_FireAtOpponent_OnEveryShipPosition_ReturnsHitAndSinkResult()
        {
            var game = TestGame.Instance;

            var realPlayer = game.RealPlayer;
            var computerPlayer = game.ComputerPlayer;

            var position1 = new Ship.Position()
            {
                Column = 'E',
                Row = 2
            };
            var position2 = new Ship.Position()
            {
                Column = 'E',
                Row = 3
            };
            var position3 = new Ship.Position()
            {
                Column = 'E',
                Row = 4
            };
            var position4 = new Ship.Position()
            {
                Column = 'E',
                Row = 5
            };

            var fireResult1 = realPlayer.FireAtOpponent(computerPlayer, position1);
            fireResult1.Should().Be(FireResult.Hit);

            var fireResult2 = realPlayer.FireAtOpponent(computerPlayer, position2);
            fireResult2.Should().Be(FireResult.Hit);

            var fireResult3 = realPlayer.FireAtOpponent(computerPlayer, position3);
            fireResult3.Should().Be(FireResult.Hit);

            var fireResult4 = realPlayer.FireAtOpponent(computerPlayer, position4);
            fireResult4.Should().Be(FireResult.HitAndSink);
        }


        [Fact]
        public void ComputerPlayer_FireAtOpponent_OnEveryShipPosition_ReturnsHitAndSinkResult()
        {
            var game = TestGame.Instance;

            var realPlayer = game.RealPlayer;
            var computerPlayer = game.ComputerPlayer;

            var position1 = new Ship.Position()
            {
                Column = 'B',
                Row = 2
            };
            var position2 = new Ship.Position()
            {
                Column = 'B',
                Row = 3
            };
            var position3 = new Ship.Position()
            {
                Column = 'B',
                Row = 4
            };
            var position4 = new Ship.Position()
            {
                Column = 'B',
                Row = 5
            };

            var fireResult1 = computerPlayer.FireAtOpponent(realPlayer, position1);
            fireResult1.Should().Be(FireResult.Hit);

            var fireResult2 = computerPlayer.FireAtOpponent(realPlayer, position2);
            fireResult2.Should().Be(FireResult.Hit);

            var fireResult3 = computerPlayer.FireAtOpponent(realPlayer, position3);
            fireResult3.Should().Be(FireResult.Hit);

            var fireResult4 = computerPlayer.FireAtOpponent(realPlayer, position4);
            fireResult4.Should().Be(FireResult.HitAndSink);
        }
    }
}
