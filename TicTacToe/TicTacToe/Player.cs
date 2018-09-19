using System;

namespace TicTacToe
{
    public class Player
    {
        public int PlayerId { set; get; }
        public string PlayerPiece { set; get; }
        public string PlayerCommand { set; get; }

        public Player(int playerId, string playerPiece)
        {
            PlayerId = playerId;
            PlayerPiece = playerPiece;
        }

        //Player enter a command
        public string EnterCommand()
        {
            return Console.ReadLine();
        }
    }
}
