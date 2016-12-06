using System;

namespace GameOfFifteen.DataTypes
{
    public class GameResultEventArgs : EventArgs
    {
        public int MovesCount { get; set; }

        public GameResultEventArgs(int movesCount)
        {
            MovesCount = movesCount;
        }
    }
}