using System;
using System.Drawing;
using System.Windows.Forms;
using GameOfFifteen.DataTypes;

namespace GameOfFifteen
{
    public interface IMainForm
    {
        event EventHandler NewGameClick;
        event EventHandler GiveUpClick;
        event EventHandler<ChooseImageEventArgs> NewImageChosen;
        event EventHandler<PieceClickEventArgs> PieceClick;
        event EventHandler<GameFieldSizeEventArgs> GameFieldSizeChange;

        Bitmap Picture { set; }
        Bitmap PicturePreview { set; }
        bool GameInProgress { set; }

        void ShowMessage(string message);
    }
    public partial class MainForm : Form, IMainForm
    {
        public Bitmap Picture
        {
            set { PBMain.Image = value; }
        }

        public bool GameInProgress
        {
            set
            {
                BTNNewGame.Enabled = !value;
                BTNChooseImage.Enabled = !value;
                CBGameFieldSize.Enabled = !value;
                BTNGiveUp.Visible = value;
                PBMain.Enabled = value;

            }
        }

        public Bitmap PicturePreview
        {
            set
            {
                PBPreview.Image = value;
            }
        }

        #region IMainForm Events Wrap

        public event EventHandler NewGameClick;
        public event EventHandler<ChooseImageEventArgs> NewImageChosen;
        public event EventHandler<PieceClickEventArgs> PieceClick;
        public event EventHandler GiveUpClick;
        public event EventHandler<GameFieldSizeEventArgs> GameFieldSizeChange;

        public MainForm()
        {
            InitializeComponent();
            CBGameFieldSize.SelectedIndex = 1;
        }

        private void BTNNewGame_Click(object sender, EventArgs e)
        {
            NewGameClick?.Invoke(this, EventArgs.Empty);
        }

        private void BTNChooseImage_Click(object sender, EventArgs e)
        {
            var image = OpenImage();

            if (image != null)
                NewImageChosen?.Invoke(this, new ChooseImageEventArgs(image));
        }
        private void PBMain_Click(object sender, EventArgs e)
        {
            var clickCoords = PBMain.PointToClient(Cursor.Position);
            Console.WriteLine(clickCoords);
            PieceClick?.Invoke(this, new PieceClickEventArgs(clickCoords));
        }

        private void BTNGiveUp_Click(object sender, EventArgs e)
        {
            GiveUpClick?.Invoke(this, EventArgs.Empty);
        }
        private void CBGameFieldSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newSize = int.Parse(CBGameFieldSize.SelectedItem.ToString().Substring(0,1));
            GameFieldSizeChange?.Invoke(this, new GameFieldSizeEventArgs(newSize));
        }
        #endregion

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Game Ended");
        }

        private Bitmap OpenImage()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose picture. Min size is 500x500";
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp, *.gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp, *.gif";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var image = new Bitmap(dialog.FileName);
                    if (image.Width > 500)
                        return image;
                    else
                        MessageBox.Show("Sorry, image size is too small.");
                }
            }
            return null;
        }

    }
}
