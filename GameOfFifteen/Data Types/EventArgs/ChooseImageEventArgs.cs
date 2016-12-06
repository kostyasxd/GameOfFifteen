using System;
using System.Drawing;

namespace GameOfFifteen.DataTypes
{
    public class ChooseImageEventArgs : EventArgs
    {
        public Bitmap NewImage { get; set; }

        public ChooseImageEventArgs(Bitmap newImage)
        {
            NewImage = newImage;
        }
    }
}