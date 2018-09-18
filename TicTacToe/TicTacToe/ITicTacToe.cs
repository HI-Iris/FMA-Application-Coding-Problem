namespace TicTacToe
{
    public interface ITicTacToe
    {
        bool GetCoord(bool isValidCoord);
        void Place();
        void PlayerChange();
    }
}
