using System;
using System.Linq;
using Battleship.Util;

namespace Battleship.Domain
{
    public class Game
    {
        public Player ComputerPlayer { get; set; }
        public Player RealPlayer { get; set; }

        public bool ComputerPlayerLost => ComputerPlayer.Ships.All(s => s.IsSunk);
        public bool RealPlayerLost => RealPlayer.Ships.All(s => s.IsSunk);

    }
}
