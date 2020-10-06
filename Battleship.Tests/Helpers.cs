using System.Collections.Generic;
using Battleship.Domain;

namespace Battleship.Tests
{
    public static class Helpers
    {
        public static IEnumerable<object[]> ToMemberData(IEnumerable<Ship.Position> positions)
        {
            foreach (var position in positions)
            {
                yield return new object[] {position.Column, position.Row};
            }
        }
    }
}
