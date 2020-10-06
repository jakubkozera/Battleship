using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain
{
    public class Player
    {
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public List<Ship.Position> Hits { get; set; } = new List<Ship.Position>();
        public List<Ship.Position> Misses { get; set; } = new List<Ship.Position>();

        public FireResult FireAtOpponent(Player opponent, Ship.Position shipPosition)
        {
            var fireResult = opponent.TakeFire(shipPosition);
            return fireResult;
        }
        private FireResult TakeFire(Ship.Position shipPosition)
        {
            var hitPosition = Ships
                .SelectMany(s => s.Positions)
                .FirstOrDefault(sp => sp.Equals(shipPosition));

            if (hitPosition != null)
            {
                Hits.Add(shipPosition);
                hitPosition.IsHit = true;

                var hitShip = Ships.First(s => s.Positions.Contains(hitPosition));
                return hitShip.IsSunk ? FireResult.HitAndSink : FireResult.Hit;
            }

            Misses.Add(shipPosition);
            return FireResult.Miss;
        }
    }
}
