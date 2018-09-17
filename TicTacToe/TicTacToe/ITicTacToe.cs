namespace TicTacToe
{
    public interface ITicTacToe
    {
        void BoardPrint();
        bool InputCoord();
        bool MoveAccepted();
        void Place(bool moveAccepted);
        int PlayerChange(int currentPlayer);
        bool Referee(string[,] board);
    }
}
