using System;

namespace GameOfFifteen.DataTypes
{
    public class GameFieldSizeEventArgs : EventArgs
    {
        public int GameFieldSize { get; set; }

        public GameFieldSizeEventArgs(int gameFieldSize)
        {
            GameFieldSize = gameFieldSize;
        }
    }
}