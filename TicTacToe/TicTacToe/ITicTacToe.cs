namespace TicTacToe
{
    public interface ITicTacToe
    {
        void BoardPrint();
        bool EnterCommand();
        bool GetCoord(bool isValidCoord);
        bool CanPlace();
        void PlayerChange();
        bool Referee(string[,] board);
    }
}
