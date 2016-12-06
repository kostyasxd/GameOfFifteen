using GameOfFifteen.DataTypes;
using GameOfFifteen.Models;
using System;

namespace GameOfFifteen.Controllers
{
    public class MainFormController
    {
        private readonly IMainForm View;
        private readonly IImageTransformationManager ImageTransformer;
        private readonly IGameOfFifteenLogic GameLogic;

        public MainFormController(IMainForm view, IImageTransformationManager imageTransformer, IGameOfFifteenLogic gameLogic)
        {
            View = view;
            ImageTransformer = imageTransformer;
            GameLogic = gameLogic;

            #region View Events
            View.NewGameClick += StartNewGame;
            View.NewImageChosen += NewImageChosen;
            View.PieceClick += PieceClicked;
            View.GiveUpClick += GiveUpClicked;
            View.Picture = GameLogic.FullPicture;
            View.GameFieldSizeChange += GameFieldChange;
            #endregion

        }

        private void GameFieldChange(object sender, GameFieldSizeEventArgs e)
        {
            Properties.Settings.Default.GameFieldSize = e.GameFieldSize;
        }

        private void GiveUpClicked(object sender, EventArgs e)
        {
            FinishGame(false);
        }

        private void FinishGame(bool userWon)
        {
            FinishGame(userWon, 0);
        }

        private void FinishGame(bool userWon, int movesCount)
        {
            View.Picture = GameLogic.FullPicture;

            if (userWon)
                View.ShowMessage(string.Format("You won in {0} moves!", movesCount));
            else
                View.ShowMessage("You lost :(");

            GameLogic.GameEnded -= GameEnded;
            View.GameInProgress = false;
        }

        private void NewImageChosen(object sender, ChooseImageEventArgs e)
        {
            var newImage = ImageTransformer.TransformImage(e.NewImage);
            GameLogic.InitGame(newImage);
            View.Picture = GameLogic.FullPicture;
            View.PicturePreview = GameLogic.FullPicture;
        }

        private void PieceClicked(object sender, PieceClickEventArgs e)
        {
            var coords = e.PieceCoords;
            View.Picture = GameLogic.TryMakeMove(coords);
        }

        private void StartNewGame(object sender, EventArgs e)
        {
            View.GameInProgress = true;
            View.Picture = GameLogic.InitGame();
            View.PicturePreview = GameLogic.FullPicture;
            GameLogic.GameEnded += GameEnded;
        }

        private void GameEnded(object sender, GameResultEventArgs e)
        {
            FinishGame(true, e.MovesCount);
        }
    }
}
