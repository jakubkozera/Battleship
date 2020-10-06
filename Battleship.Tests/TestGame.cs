using Battleship.Domain;

namespace Battleship.Tests
{
    public class TestGame
    {
        public static Game Instance => new Game
        {
            RealPlayer = TestPlayer.RealPlayerInstance,
            ComputerPlayer = TestPlayer.ComputerInstance
        };
    }
}
