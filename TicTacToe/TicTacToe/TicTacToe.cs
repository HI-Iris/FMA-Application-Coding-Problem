using System;
using System.Collections.Generic;
using System.Threading;

namespace TicTacToe
{
    public class TicTacToe
    {
        private const string DefaultBoard = ".";
        private const string Welcome = "Welcome to Tic Tac Toe!\n";
        private const string Win = "Well done you've won the game!\n";
        private const string Draw = "Draw!\n";
        private const string GiveUp = "Player gives up, game over!";
        private const string BoardPrint = "Here's the current board:";
        private const string AppClose = "Application will be closed in 5 seconds:";
        private const string PlaceTaken = "\nOh no, a piece is already placed on this place! Try somewhere else...\n";
        private const string InvalidInput = "\nInvalid input. Please try again.\n";
        private const string MoveAccepted = "\nMove accepted\n";
        private const int MaxNumOfRowsX = 3;
        private const int MaxNumOfColsY = 3;
        private bool PlayerWin { set; get; }
        private GameBoard TicBoard { get; set; }
        private Player CurrentTicPlayer { set; get; }
        private List<Player> TicPlayers { get; }
        private Referee TicReferee { set; get; }
        private InputCoord TicInputCoord { set; get; }

        public TicTacToe()
        {
            PlayerWin = false;
            TicReferee = new Referee();
            TicInputCoord = new InputCoord();
            TicPlayers = new List<Player> { new Player(1, "X"), new Player(2, "O") };
            CurrentTicPlayer = TicPlayers[0];
            TicBoard = new GameBoard(MaxNumOfRowsX, MaxNumOfColsY, DefaultBoard) { PieceCount = 0 };
        }

        //Start the game
        public void GameStart()
        {
            Console.WriteLine(Welcome);
            Console.WriteLine(BoardPrint);
            TicBoard.PrintBoard(TicBoard.Board);
            do
            {
                Console.WriteLine("Player " + CurrentTicPlayer.PlayerId + " enter a coord x,y to place your " + CurrentTicPlayer.PlayerPiece + " or enter 'q' to give up:");
                CurrentTicPlayer.PlayerCommand = CurrentTicPlayer.EnterCommand();
                var validCommand = TicReferee.IsValidCommand(CurrentTicPlayer.PlayerCommand);
                switch (validCommand)
                {
                    case 1:
                        TicInputCoord = TicInputCoord.GetCoord(CurrentTicPlayer);
                        break;
                    case 2:
                        Console.WriteLine(GiveUp);
                        GameEnd();
                        break;
                    default:
                        Console.WriteLine(InvalidInput);
                        continue;
                }
                var canPlace = TicReferee.CanPlace(TicBoard, TicInputCoord, TicPlayers);
                if (canPlace)
                {
                    Console.WriteLine(MoveAccepted);
                    Place();
                    PlayerChange();
                    Console.WriteLine(BoardPrint);
                    TicBoard.PrintBoard(TicBoard.Board);
                }
                else
                {
                    Console.WriteLine(PlaceTaken);
                    continue;
                }
                PlayerWin = TicReferee.IsWin(TicBoard.Board, MaxNumOfRowsX, MaxNumOfColsY, DefaultBoard);
                if (PlayerWin) break;
            } while (TicBoard.PieceCount != MaxNumOfRowsX * MaxNumOfColsY);
            Console.WriteLine(PlayerWin ? Win : Draw);
            GameEnd();
        }

        //End the game
        public void GameEnd()
        {
            Console.WriteLine(AppClose);
            for (var i = 5; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }

        //Place the piece on board
        public void Place()
        {
            switch (CurrentTicPlayer.PlayerId)
            {
                case 1:
                    TicBoard.Board[TicInputCoord.CoordX, TicInputCoord.CoordY] = TicPlayers[0].PlayerPiece;
                    TicBoard.PieceCount++;
                    break;
                default:
                    TicBoard.Board[TicInputCoord.CoordX, TicInputCoord.CoordY] = TicPlayers[1].PlayerPiece;
                    TicBoard.PieceCount++;
                    break;
            }
        }

        //Change the player
        public void PlayerChange()
        {
            CurrentTicPlayer = (CurrentTicPlayer.PlayerId == 1) ? TicPlayers[1] : TicPlayers[0];
        }
    }
}

