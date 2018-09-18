using System;
using System.Collections.Generic;
using System.Threading;

namespace TicTacToe
{
    public class TicTacToe : ITicTacToe, IGame
    {
        private int MaxNumOfRowsX { get; }
        private int MaxNumOfColsY { get; }
        private bool PlayerWin { set; get; }
        private GameBoard TicBoard { get; set; }
        private Player CurrentPlayer { set; get; }
        private List<Player> Players { get; }
        private Referee TicReferee { set; get; }

        public TicTacToe()
        {
            MaxNumOfRowsX = 3;
            MaxNumOfColsY = 3;
            PlayerWin = false;
            TicReferee = new Referee();
            Players = new List<Player> { new Player(1, "X"), new Player(2, "O") };
            CurrentPlayer = Players[0];
            TicBoard = new GameBoard(MaxNumOfRowsX, MaxNumOfColsY);
            TicBoard.PieceCount = 0;
        }

        //Start the game
        public void GameStart()
        {
            Console.WriteLine(ConstString.Welcome);
            TicBoard.PrintBoard(TicBoard.Board);
            do
            {
                var validCoord = CurrentPlayer.EnterCommand(CurrentPlayer);
                var canPlace = GetCoord(validCoord);
                if (canPlace)
                {
                    Place();
                    PlayerChange();
                    TicBoard.PrintBoard(TicBoard.Board);
                }
                PlayerWin = TicReferee.IsWin(TicBoard.Board, MaxNumOfRowsX, MaxNumOfColsY);
                if (PlayerWin) break;
            } while (TicBoard.PieceCount != MaxNumOfRowsX * MaxNumOfColsY);
            Console.WriteLine(PlayerWin ? ConstString.Win : ConstString.Draw);
            GameEnd();
        }

        //End the game
        public void GameEnd()
        {
            Console.WriteLine(ConstString.AppClose);
            for (var i = 5; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }

        //Check the command and place piece, if it is a valid coordinate and movement then place the piece, if not, promote the input again
        public bool GetCoord(bool isValidCoord)
        {
            if (isValidCoord)
            {
                var coordArray = CurrentPlayer.PlayerCommand.Split(',');
                TicBoard.InputCoordX = int.Parse(coordArray[0]) - 1;
                TicBoard.InputCoordY = int.Parse(coordArray[1]) - 1;
                return TicReferee.CanPlace(TicBoard, Players);
            }
            if (CurrentPlayer.PlayerCommand.ToLower() == "q")
            {
                Console.WriteLine(ConstString.GiveUp);
                GameEnd();
            }
            else
            {
                Console.WriteLine(ConstString.InvalidInput);
            }
            return false;
        }

        //Place the piece on board if the movement is acceptable
        //Or return to do-while loop, promote player to input a command again
        public void Place()
        {
            switch (CurrentPlayer.PlayerId)
            {
                case 1:
                    TicBoard.Board[TicBoard.InputCoordX, TicBoard.InputCoordY] = Players[0].PlayerPiece;
                    TicBoard.PieceCount++;
                    break;
                default:
                    TicBoard.Board[TicBoard.InputCoordX, TicBoard.InputCoordY] = Players[1].PlayerPiece;
                    TicBoard.PieceCount++;
                    break;
            }
        }

        //Change the player
        public void PlayerChange()
        {
            CurrentPlayer = (CurrentPlayer.PlayerId == 1) ? Players[1] : Players[0];
        }



    }
}

