using System.Collections.Generic;

namespace TicTacToe
{
    public class InputCoord
    {
        public int CoordX;
        public int CoordY;

        //Check the command and place piece, if it is a valid coordinate and movement then place the piece, if not, promote the input again
        public InputCoord GetCoord(List<Player> players, Player currentPlayer)
        {
            var coordArray = currentPlayer.PlayerCommand.Split(',');
            var coord = new InputCoord();
            coord.CoordX = int.Parse(coordArray[0]) - 1;
            coord.CoordY = int.Parse(coordArray[1]) - 1;
            return coord;
        }
    }
}
