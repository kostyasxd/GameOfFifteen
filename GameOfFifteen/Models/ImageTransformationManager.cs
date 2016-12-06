using GameOfFifteen.DataTypes;
using System.Drawing;

namespace GameOfFifteen.Models
{
    public interface IImageTransformationManager
    {
        Bitmap TransformImage(Bitmap image);
        Bitmap CutLastPiece(Bitmap image);
        Bitmap SwapPieces(Bitmap input, Point gfCoords, Point spaceCoords);
    }

    public class ImageTransformationManager : IImageTransformationManager
    {
        private int GameFieldSidePixelSize;
        private int GameFieldSize
        {
            get
            {
                return Properties.Settings.Default.GameFieldSize;
            }
        }

        public ImageTransformationManager(int canvasSideSize)
        {
            GameFieldSidePixelSize = canvasSideSize;
        }

        public Bitmap CutLastPiece(Bitmap input)
        {
            var copy = new Bitmap(input);
            FillPieceWithWhiteColor(copy, new Point(GameFieldSize - 1, GameFieldSize - 1));
            return copy;
        }

        public Bitmap SwapPieces(Bitmap input, Point gfCoords, Point spaceCoords)
        {
            var temp = input.Clone(CoordHelper.RectangleFromGameFieldCoords(gfCoords, GameFieldSidePixelSize / GameFieldSize), input.PixelFormat);
            FillPieceWithWhiteColor(input, gfCoords);
            DrawPieceInCoords(input, temp, spaceCoords);
            return input;
        }
        private void FillPieceWithWhiteColor(Bitmap input, Point pieceGFCoords)
        {
            using (var graphics = Graphics.FromImage(input))
            {
                var whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, CoordHelper.RectangleFromGameFieldCoords(new Point(pieceGFCoords.X, pieceGFCoords.Y), GameFieldSidePixelSize / GameFieldSize));
            }
        }

        private void DrawPieceInCoords(Bitmap input, Bitmap pieceToDraw, Point gfCoordsToDrawIn)
        {
            using (var graphics = Graphics.FromImage(input))
            {
                graphics.DrawImage(pieceToDraw, CoordHelper.RectangleFromGameFieldCoords(gfCoordsToDrawIn, GameFieldSidePixelSize / GameFieldSize));
            }
        }
        /// <summary>
        /// Scales/Cuts image to use it on square game field;
        /// </summary>
        /// <param name="input"></param>
        public Bitmap TransformImage(Bitmap input)
        {
            //will rotate image to make width always >= height
            bool wasRotated = false;

            if (input.Width < input.Height)
            {
                input.RotateFlip(RotateFlipType.Rotate90FlipNone);
                wasRotated = true;
            }

            //scaling
            float ratio = (float)input.Height / (float)GameFieldSidePixelSize;
            input = new Bitmap(input, new Size((int)(input.Width / ratio), GameFieldSidePixelSize));

            int xStartPos = (int)((float)(input.Width - GameFieldSidePixelSize) / 2);

            var result = input.Clone(new Rectangle(xStartPos, 0, GameFieldSidePixelSize, GameFieldSidePixelSize), input.PixelFormat);

            //rotating back if needed
            if (wasRotated)
                result.RotateFlip(RotateFlipType.Rotate270FlipNone);

            return result;
        }

    }
}
