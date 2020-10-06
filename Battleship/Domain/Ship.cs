using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Domain
{
    public class Ship
    {
        public Ship(List<Position> positions)
        {
            Positions = positions;
        }

        public List<Position> Positions { get; }

        public bool IsSunk => Positions.All(p => p.IsHit);

        public class Position
        {
            public int Row { get; set; }
            public char Column { get; set; }
            public bool IsHit { get; set; }

            public override string ToString() => $"{Column}{Row}";

            protected bool Equals(Position other) =>
                Row == other.Row && Column == other.Column;

            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Position) obj);
            }

            public override int GetHashCode()
                => HashCode.Combine(Row, Column);
        }
    }
}
