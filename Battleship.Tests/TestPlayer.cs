using System;
using System.Collections.Generic;
using Battleship.Domain;

namespace Battleship.Tests
{
    public class TestPlayer
    {
        public static Player RealPlayerInstance => new Player()
        {
            Ships = new List<Ship>()
            {
                new Ship(new List<Ship.Position>()
                {
                    new Ship.Position() { Column = 'A', Row = 1},
                    new Ship.Position() { Column = 'A', Row = 2},
                    new Ship.Position() { Column = 'A', Row = 3},
                    new Ship.Position() { Column = 'A', Row = 4},
                    new Ship.Position() { Column = 'A', Row = 5},
                }),
                new Ship(new List<Ship.Position>()
                {
                    new Ship.Position() { Column = 'B', Row = 2},
                    new Ship.Position() { Column = 'B', Row = 3},
                    new Ship.Position() { Column = 'B', Row = 4},
                    new Ship.Position() { Column = 'B', Row = 5},
                }),
                new Ship(new List<Ship.Position>()
                {
                    new Ship.Position() { Column = 'C', Row = 2},
                    new Ship.Position() { Column = 'C', Row = 3},
                    new Ship.Position() { Column = 'C', Row = 4},
                    new Ship.Position() { Column = 'C', Row = 5},
                })
            }
        };

        public static Player ComputerInstance => new Player()
        {
            Ships = new List<Ship>()
            {
                new Ship(new List<Ship.Position>()
                {
                    new Ship.Position() { Column = 'D', Row = 1},
                    new Ship.Position() { Column = 'D', Row = 2},
                    new Ship.Position() { Column = 'D', Row = 3},
                    new Ship.Position() { Column = 'D', Row = 4},
                    new Ship.Position() { Column = 'D', Row = 5},
                }),
                new Ship(new List<Ship.Position>()
                {
                    new Ship.Position() { Column = 'E', Row = 2},
                    new Ship.Position() { Column = 'E', Row = 3},
                    new Ship.Position() { Column = 'E', Row = 4},
                    new Ship.Position() { Column = 'E', Row = 5},
                }),
                new Ship(new List<Ship.Position>()
                {
                    new Ship.Position() { Column = 'F', Row = 2},
                    new Ship.Position() { Column = 'F', Row = 3},
                    new Ship.Position() { Column = 'F', Row = 4},
                    new Ship.Position() { Column = 'F', Row = 5},
                })
            }
        };
    }
}
