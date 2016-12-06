using System;
using System.Drawing;
using GameOfFifteen.DataTypes;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GameOfFifteen.Models
{
    public interface IGameOfFifteenLogic
    {
        event EventHandler<GameResultEventArgs> GameEnded;

        Bitmap InitGame(Bitmap picture);
        Bitmap InitGame();
        Bitmap FullPicture { get; }
        Bitmap CurrentPicture { get; }
        Bitmap TryMakeMove(Point piecePointCoords);

    }

    public class GameOfFifteenLogic : IGameOfFifteenLogic
    {
        private readonly IImageTransformationManager ImageTransformer;

        private int GameFieldSize
        {
            get
            {
                return Properties.Settings.Default.GameFieldSize;
            }
        }

        private Bitmap _fullPicture; //stores original picture (16 pieces)
        public Bitmap FullPicture
        {
            get
            {
                return _fullPicture;
            }
        }

        private Bitmap _currentPicture; // stores current state of picture (15 pieces)
        public Bitmap CurrentPicture
        {
            get
            {
                return _currentPicture;
            }
        }

        private Bitmap _finalPicture; //stores "win condition" state of picture (15 pieces)

        private int PieceSize
        {
            get
            {
                return _fullPicture.Width / GameFieldSize - 1;
            }
        }

        private Point SpaceCoords;

        public event EventHandler<GameResultEventArgs> GameEnded;

        private int MovesCount;

        public GameOfFifteenLogic(IImageTransformationManager imageTransformer, Bitmap picture)
        {
            ImageTransformer = imageTransformer;
            _fullPicture = new Bitmap(picture);
        }

        /// <summary>
        /// Makes Move and returns picture after it.
        /// </summary>
        /// <param name="pieceToMove"></param>
        /// <returns></returns>
        public Bitmap TryMakeMove(Point piecePixelCoords)
        {
            if (PieceIsMovable(piecePixelCoords, false))
            {
                MovePiece(piecePixelCoords, false);
                MovesCount++;
            }

            return CurrentPicture;
        }

        /// <summary>
        /// Inits game with new picture.
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public Bitmap InitGame(Bitmap picture)
        {
            _fullPicture = new Bitmap(picture);

            SpaceCoords = new Point(GameFieldSize - 1, GameFieldSize - 1);
            _finalPicture = ImageTransformer.CutLastPiece(_fullPicture);
            _currentPicture = new Bitmap(_finalPicture);
            Shuffle();
            MovesCount = 1;

            return CurrentPicture;
        }

        /// <summary>
        /// Inits game with old picture.
        /// </summary>
        /// <returns></returns>
        public Bitmap InitGame()
        {
            return InitGame(_fullPicture);
        }

        private void Shuffle(int movesCount = 150)
        {
            var rand = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < movesCount; i++)
            {
                Point pieceToMoveCoords;
                bool randomPieceIsGoodToMove = false;
                var isHorizontalMove = i % 2;
                do
                {
                    if (isHorizontalMove == 1)
                        pieceToMoveCoords = new Point(SpaceCoords.X, SpaceCoords.Y + (rand.Next(0, 2) * 2 - 1));
                    else
                        pieceToMoveCoords = new Point(SpaceCoords.X + (rand.Next(0, 2) * 2 - 1), SpaceCoords.Y);

                    if (pieceToMoveCoords.X <= GameFieldSize - 1
                        && pieceToMoveCoords.Y <= GameFieldSize - 1
                        && pieceToMoveCoords.X >= 0
                        && pieceToMoveCoords.Y >= 0)
                    {
                        randomPieceIsGoodToMove = true;
                    }
                }
                while (!randomPieceIsGoodToMove);
                MovePiece(pieceToMoveCoords, true);

            }
        }

        private bool PieceIsMovable(Point pieceCoords, bool gameFieldCoords)
        {
            if (!gameFieldCoords)
                pieceCoords = CoordHelper.PixelToGameFieldCoords(pieceCoords, PieceSize);

            var delta = Math.Abs(SpaceCoords.X - pieceCoords.X) + Math.Abs(SpaceCoords.Y - pieceCoords.Y);
            if (delta == 1)
                return true;
            else
                return false;
        }

        private void CheckWinCondition()
        {
            if (CompareBitmaps(_currentPicture, _finalPicture))
            {
                _currentPicture = new Bitmap(_fullPicture);
                GameEnded?.Invoke(this, new GameResultEventArgs(MovesCount));
            }
        }
        private void MovePiece(Point pieceCoords, bool gameFieldCoords)
        {
            if (!gameFieldCoords)
                pieceCoords = CoordHelper.PixelToGameFieldCoords(pieceCoords, PieceSize);

            _currentPicture = ImageTransformer.SwapPieces(_currentPicture, pieceCoords, SpaceCoords);
            SpaceCoords = pieceCoords;

            if (SpaceCoords.X == GameFieldSize - 1 && SpaceCoords.Y == GameFieldSize - 1)
                CheckWinCondition();
        }

        private bool CompareBitmaps(Bitmap left, Bitmap right)
        {
            if (Equals(left, right))
                return true;
            if (left == null || right == null)
                return false;
            if (!left.Size.Equals(right.Size) || !left.PixelFormat.Equals(right.PixelFormat))
                return false;

            Bitmap leftBitmap = left as Bitmap;
            Bitmap rightBitmap = right as Bitmap;
            if (leftBitmap == null || rightBitmap == null)
                return true;

            #region Optimized code for performance

            int bytes = left.Width * left.Height * (Image.GetPixelFormatSize(left.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bmd1 = leftBitmap.LockBits(new Rectangle(0, 0, leftBitmap.Width - 1, leftBitmap.Height - 1), ImageLockMode.ReadOnly, leftBitmap.PixelFormat);
            BitmapData bmd2 = rightBitmap.LockBits(new Rectangle(0, 0, rightBitmap.Width - 1, rightBitmap.Height - 1), ImageLockMode.ReadOnly, rightBitmap.PixelFormat);

            Marshal.Copy(bmd1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bmd2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            leftBitmap.UnlockBits(bmd1);
            rightBitmap.UnlockBits(bmd2);

            #endregion

            return result;
        }

    }
}
