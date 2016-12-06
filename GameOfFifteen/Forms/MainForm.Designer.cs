namespace GameOfFifteen
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBMain = new System.Windows.Forms.PictureBox();
            this.PMenu = new System.Windows.Forms.Panel();
            this.CBGameFieldSize = new System.Windows.Forms.ComboBox();
            this.BTNGiveUp = new System.Windows.Forms.Button();
            this.BTNChooseImage = new System.Windows.Forms.Button();
            this.BTNNewGame = new System.Windows.Forms.Button();
            this.LBLMenuTitle = new System.Windows.Forms.Label();
            this.PBPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBMain)).BeginInit();
            this.PMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // PBMain
            // 
            this.PBMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBMain.Enabled = false;
            this.PBMain.Location = new System.Drawing.Point(12, 12);
            this.PBMain.Name = "PBMain";
            this.PBMain.Size = new System.Drawing.Size(700, 700);
            this.PBMain.TabIndex = 0;
            this.PBMain.TabStop = false;
            this.PBMain.Click += new System.EventHandler(this.PBMain_Click);
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.PaleGreen;
            this.PMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PMenu.Controls.Add(this.CBGameFieldSize);
            this.PMenu.Controls.Add(this.BTNGiveUp);
            this.PMenu.Controls.Add(this.BTNChooseImage);
            this.PMenu.Controls.Add(this.BTNNewGame);
            this.PMenu.Location = new System.Drawing.Point(729, 105);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(286, 246);
            this.PMenu.TabIndex = 1;
            // 
            // CBGameFieldSize
            // 
            this.CBGameFieldSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBGameFieldSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBGameFieldSize.FormattingEnabled = true;
            this.CBGameFieldSize.Items.AddRange(new object[] {
            "3x3",
            "4x4",
            "5x5"});
            this.CBGameFieldSize.Location = new System.Drawing.Point(4, 60);
            this.CBGameFieldSize.Name = "CBGameFieldSize";
            this.CBGameFieldSize.Size = new System.Drawing.Size(277, 37);
            this.CBGameFieldSize.TabIndex = 3;
            this.CBGameFieldSize.SelectedIndexChanged += new System.EventHandler(this.CBGameFieldSize_SelectedIndexChanged);
            // 
            // BTNGiveUp
            // 
            this.BTNGiveUp.Location = new System.Drawing.Point(3, 168);
            this.BTNGiveUp.Name = "BTNGiveUp";
            this.BTNGiveUp.Size = new System.Drawing.Size(278, 40);
            this.BTNGiveUp.TabIndex = 2;
            this.BTNGiveUp.Text = "Give up";
            this.BTNGiveUp.UseVisualStyleBackColor = true;
            this.BTNGiveUp.Visible = false;
            this.BTNGiveUp.Click += new System.EventHandler(this.BTNGiveUp_Click);
            // 
            // BTNChooseImage
            // 
            this.BTNChooseImage.Location = new System.Drawing.Point(3, 106);
            this.BTNChooseImage.Name = "BTNChooseImage";
            this.BTNChooseImage.Size = new System.Drawing.Size(278, 40);
            this.BTNChooseImage.TabIndex = 1;
            this.BTNChooseImage.Text = "Choose Image";
            this.BTNChooseImage.UseVisualStyleBackColor = true;
            this.BTNChooseImage.Click += new System.EventHandler(this.BTNChooseImage_Click);
            // 
            // BTNNewGame
            // 
            this.BTNNewGame.Location = new System.Drawing.Point(3, 3);
            this.BTNNewGame.Name = "BTNNewGame";
            this.BTNNewGame.Size = new System.Drawing.Size(278, 40);
            this.BTNNewGame.TabIndex = 0;
            this.BTNNewGame.Text = "New Game";
            this.BTNNewGame.UseVisualStyleBackColor = true;
            this.BTNNewGame.Click += new System.EventHandler(this.BTNNewGame_Click);
            // 
            // LBLMenuTitle
            // 
            this.LBLMenuTitle.Location = new System.Drawing.Point(729, 73);
            this.LBLMenuTitle.Name = "LBLMenuTitle";
            this.LBLMenuTitle.Size = new System.Drawing.Size(286, 25);
            this.LBLMenuTitle.TabIndex = 2;
            this.LBLMenuTitle.Text = "Menu";
            this.LBLMenuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBPreview
            // 
            this.PBPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBPreview.Location = new System.Drawing.Point(729, 357);
            this.PBPreview.Name = "PBPreview";
            this.PBPreview.Size = new System.Drawing.Size(286, 290);
            this.PBPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBPreview.TabIndex = 3;
            this.PBPreview.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 723);
            this.Controls.Add(this.PBPreview);
            this.Controls.Add(this.LBLMenuTitle);
            this.Controls.Add(this.PMenu);
            this.Controls.Add(this.PBMain);
            this.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Of Fifteen";
            ((System.ComponentModel.ISupportInitialize)(this.PBMain)).EndInit();
            this.PMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBMain;
        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Button BTNNewGame;
        private System.Windows.Forms.Label LBLMenuTitle;
        private System.Windows.Forms.Button BTNChooseImage;
        private System.Windows.Forms.PictureBox PBPreview;
        private System.Windows.Forms.Button BTNGiveUp;
        private System.Windows.Forms.ComboBox CBGameFieldSize;
    }
}

