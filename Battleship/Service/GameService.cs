using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Domain;
using Battleship.Util;

namespace Battleship.Service
{
    public class GameService
    {
        private string _playerFireResult;
        private string _computerFireResult;
        public void Start(Game game)
        {
            while (true)
            {
                Console.Clear();
                DisplayLastRoundResult();
                GameUtil.Display(game);

                var playerTargetPosition = PlayerUtil.GetPlayerTargetShipPosition();
                var playerFireResult = game.RealPlayer.FireAtOpponent(game.ComputerPlayer, playerTargetPosition);

                SaveFireResult(playerFireResult, playerTargetPosition);

                if (game.ComputerPlayerLost)
                {
                    Console.WriteLine("Congratulations you won!");
                    break;
                }

                var computerTargetPosition = PlayerUtil.GenerateTargetShipPositionAgainstPlayer(game.RealPlayer);
                var computerFireResult = game.ComputerPlayer.FireAtOpponent(game.RealPlayer, computerTargetPosition);

                SaveFireResult(computerFireResult, computerTargetPosition, true);

                if (game.RealPlayerLost)
                {
                    Console.WriteLine("You lost!");
                    break;
                }
            }

            Console.WriteLine("Game over");
        }

        private void DisplayLastRoundResult()
        {
            if (!string.IsNullOrEmpty(_playerFireResult))
            {
                Console.WriteLine(_playerFireResult);
                Console.WriteLine(_computerFireResult);
            }
        }


        private void SaveFireResult(FireResult fireResult, Ship.Position position, bool alertForComputer = false)
        {
            var fireResultMessage =
                (alertForComputer ? "Computer" : "Player") + $" fire result at {position} fire result is a {fireResult}";
            if (alertForComputer)
            {
                _computerFireResult = fireResultMessage;
            }
            else
            {
                _playerFireResult = fireResultMessage;
            }
        }
    }
}
