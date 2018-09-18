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
        public bool EnterCommand(Player currentPlayer)
        {
            Console.WriteLine("Player " + currentPlayer.PlayerId + " enter a coord x,y to place your " + currentPlayer.PlayerPiece + " or enter 'q' to give up:");
            currentPlayer.PlayerCommand = Console.ReadLine();
            Console.WriteLine();
            return Referee.IsValidCoord(currentPlayer.PlayerCommand);
        }
    }
}
