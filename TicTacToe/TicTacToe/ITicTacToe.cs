namespace TicTacToe
{
    public interface ITicTacToe
    {
        void boardPrint();
        bool inputCoord();
        bool moveAccepted();
        void place(bool moveAccepted);
        int playerChange(int currentPlayer);
        bool referee(string[,] board);
    }
}
