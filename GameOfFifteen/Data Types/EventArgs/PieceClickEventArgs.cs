using System;
using System.Drawing;

namespace GameOfFifteen.DataTypes
{
    public class PieceClickEventArgs : EventArgs
    {
        public Point PieceCoords { get; set; }

        public PieceClickEventArgs(Point pieceCoords)
        {
            PieceCoords = pieceCoords;
        }
    }
}