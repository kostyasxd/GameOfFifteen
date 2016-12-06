using System.Drawing;

namespace GameOfFifteen.DataTypes
{
    public static class CoordHelper
    {
        public static Point PixelToGameFieldCoords(Point pixelCoords, int pieceSize)
        {
            return new Point(pixelCoords.X / pieceSize, pixelCoords.Y / pieceSize);
        }

        public static Rectangle RectangleFromGameFieldCoords(Point gfCoords, int pieceSize)
        {
            return new Rectangle(gfCoords.X * pieceSize, gfCoords.Y * pieceSize, pieceSize, pieceSize);
        }
    }
}
