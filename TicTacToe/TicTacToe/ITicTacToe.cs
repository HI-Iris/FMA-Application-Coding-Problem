namespace TicTacToe
{
    public interface ITicTacToe
    {
        void boardPrint();
        bool inputCoord();
        bool moveAccepted();
        void place(bool moveAccepted);
        int playerChange(int currentPlayer);
        void referee();
    }
}
