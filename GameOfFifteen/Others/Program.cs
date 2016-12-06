using GameOfFifteen.Controllers;
using GameOfFifteen.Models;
using GameOfFifteen.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfFifteen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const int gameFieldSideSize = 700;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var defaultPicture = (Bitmap)Resources.ResourceManager.GetObject("default_picture");
            var mainForm = new MainForm();

            var imageTransformer = new ImageTransformationManager(gameFieldSideSize);
            var gameLogic = new GameOfFifteenLogic(imageTransformer, defaultPicture);
            var mainFormController = new MainFormController(mainForm, imageTransformer, gameLogic);

            Application.Run(mainForm);
        }
    }
}
