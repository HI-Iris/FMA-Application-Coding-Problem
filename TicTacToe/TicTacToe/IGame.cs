using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface IGame
    {
        void gameStart();
        void boardPrint();
        bool inputCoord();
        bool checkMove();
        void place(bool moveAccepted);
        int playerChange(int currentPlayer);
        int referee();
        void closeApp();
    }
}
