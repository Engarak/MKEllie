namespace MKNaomi
{
    partial class frmMKEllie
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMKEllie));
            this.grpGames = new System.Windows.Forms.GroupBox();
            this.lstGamesList = new System.Windows.Forms.ListBox();
            this.grpGameDetails = new System.Windows.Forms.GroupBox();
            this.pctBoxArt = new System.Windows.Forms.PictureBox();
            this.lblGameInfo = new System.Windows.Forms.Label();
            this.grpOperations = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.lbl3DSIP = new System.Windows.Forms.Label();
            this.txt3DSIP = new System.Windows.Forms.TextBox();
            this.btnSendGame = new System.Windows.Forms.Button();
            this.btnRomPath = new System.Windows.Forms.Button();
            this.strStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.fbdRomPath = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrColorChange = new System.Windows.Forms.Timer(this.components);
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.grpGames.SuspendLayout();
            this.grpGameDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxArt)).BeginInit();
            this.grpOperations.SuspendLayout();
            this.strStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGames
            // 
            this.grpGames.Controls.Add(this.lstGamesList);
            this.grpGames.Location = new System.Drawing.Point(12, 12);
            this.grpGames.Name = "grpGames";
            this.grpGames.Size = new System.Drawing.Size(443, 569);
            this.grpGames.TabIndex = 0;
            this.grpGames.TabStop = false;
            this.grpGames.Text = "Games to Send";
            // 
            // lstGamesList
            // 
            this.lstGamesList.FormattingEnabled = true;
            this.lstGamesList.Location = new System.Drawing.Point(6, 19);
            this.lstGamesList.Name = "lstGamesList";
            this.lstGamesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstGamesList.Size = new System.Drawing.Size(431, 537);
            this.lstGamesList.TabIndex = 0;
            this.lstGamesList.SelectedIndexChanged += new System.EventHandler(this.lstGamesList_SelectedIndexChanged);
            // 
            // grpGameDetails
            // 
            this.grpGameDetails.Controls.Add(this.pctBoxArt);
            this.grpGameDetails.Controls.Add(this.lblGameInfo);
            this.grpGameDetails.Location = new System.Drawing.Point(461, 12);
            this.grpGameDetails.Name = "grpGameDetails";
            this.grpGameDetails.Size = new System.Drawing.Size(342, 278);
            this.grpGameDetails.TabIndex = 1;
            this.grpGameDetails.TabStop = false;
            this.grpGameDetails.Text = "Game Details";
            // 
            // pctBoxArt
            // 
            this.pctBoxArt.BackgroundImage = global::MKEllie.Properties.Resources._3dsLogo;
            this.pctBoxArt.InitialImage = ((System.Drawing.Image)(resources.GetObject("pctBoxArt.InitialImage")));
            this.pctBoxArt.Location = new System.Drawing.Point(89, 19);
            this.pctBoxArt.Name = "pctBoxArt";
            this.pctBoxArt.Size = new System.Drawing.Size(164, 130);
            this.pctBoxArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxArt.TabIndex = 1;
            this.pctBoxArt.TabStop = false;
            // 
            // lblGameInfo
            // 
            this.lblGameInfo.Location = new System.Drawing.Point(28, 152);
            this.lblGameInfo.Name = "lblGameInfo";
            this.lblGameInfo.Size = new System.Drawing.Size(269, 123);
            this.lblGameInfo.TabIndex = 0;
            this.lblGameInfo.Text = "Select a game to display information";
            this.lblGameInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpOperations
            // 
            this.grpOperations.Controls.Add(this.label1);
            this.grpOperations.Controls.Add(this.cboCountry);
            this.grpOperations.Controls.Add(this.lbl3DSIP);
            this.grpOperations.Controls.Add(this.txt3DSIP);
            this.grpOperations.Controls.Add(this.btnSendGame);
            this.grpOperations.Controls.Add(this.btnRomPath);
            this.grpOperations.Location = new System.Drawing.Point(461, 303);
            this.grpOperations.Name = "grpOperations";
            this.grpOperations.Size = new System.Drawing.Size(342, 278);
            this.grpOperations.TabIndex = 2;
            this.grpOperations.TabStop = false;
            this.grpOperations.Text = "Operations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Country Preference:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboCountry
            // 
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Items.AddRange(new object[] {
            "USA",
            "EUR",
            "TWN",
            "JPN",
            "KOR",
            "ITA",
            "FRA",
            "GER",
            "CHN"});
            this.cboCountry.Location = new System.Drawing.Point(31, 207);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(275, 21);
            this.cboCountry.TabIndex = 5;
            this.cboCountry.Text = "USA";
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // lbl3DSIP
            // 
            this.lbl3DSIP.AutoSize = true;
            this.lbl3DSIP.Location = new System.Drawing.Point(6, 38);
            this.lbl3DSIP.Name = "lbl3DSIP";
            this.lbl3DSIP.Size = new System.Drawing.Size(217, 13);
            this.lbl3DSIP.TabIndex = 4;
            this.lbl3DSIP.Text = "3DS IP Address (as displayed on 2DS/3DS):";
            // 
            // txt3DSIP
            // 
            this.txt3DSIP.Location = new System.Drawing.Point(31, 65);
            this.txt3DSIP.Name = "txt3DSIP";
            this.txt3DSIP.Size = new System.Drawing.Size(275, 20);
            this.txt3DSIP.TabIndex = 3;
            // 
            // btnSendGame
            // 
            this.btnSendGame.Location = new System.Drawing.Point(194, 117);
            this.btnSendGame.Name = "btnSendGame";
            this.btnSendGame.Size = new System.Drawing.Size(112, 23);
            this.btnSendGame.TabIndex = 2;
            this.btnSendGame.Text = "Send Game(s)";
            this.btnSendGame.UseVisualStyleBackColor = true;
            this.btnSendGame.Click += new System.EventHandler(this.btnSendGame_Click);
            // 
            // btnRomPath
            // 
            this.btnRomPath.Location = new System.Drawing.Point(31, 117);
            this.btnRomPath.Name = "btnRomPath";
            this.btnRomPath.Size = new System.Drawing.Size(112, 23);
            this.btnRomPath.TabIndex = 1;
            this.btnRomPath.Text = "&Change Rom Path";
            this.btnRomPath.UseVisualStyleBackColor = true;
            this.btnRomPath.Click += new System.EventHandler(this.btnRomPath_Click);
            // 
            // strStatusStrip
            // 
            this.strStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.strStatusStrip.Location = new System.Drawing.Point(0, 588);
            this.strStatusStrip.Name = "strStatusStrip";
            this.strStatusStrip.Size = new System.Drawing.Size(815, 22);
            this.strStatusStrip.TabIndex = 3;
            this.strStatusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 17);
            this.lblStatus.Text = "Welcome!";
            // 
            // tmrColorChange
            // 
            this.tmrColorChange.Interval = 1000;
            this.tmrColorChange.Tick += new System.EventHandler(this.tmrColorChange_Tick);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmMKEllie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 610);
            this.Controls.Add(this.grpOperations);
            this.Controls.Add(this.strStatusStrip);
            this.Controls.Add(this.grpGameDetails);
            this.Controls.Add(this.grpGames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMKEllie";
            this.Text = "MKEllie";
            this.Load += new System.EventHandler(this.frmMKEllie_Load);
            this.grpGames.ResumeLayout(false);
            this.grpGameDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxArt)).EndInit();
            this.grpOperations.ResumeLayout(false);
            this.grpOperations.PerformLayout();
            this.strStatusStrip.ResumeLayout(false);
            this.strStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGames;
        private System.Windows.Forms.GroupBox grpGameDetails;
        private System.Windows.Forms.GroupBox grpOperations;
        private System.Windows.Forms.ListBox lstGamesList;
        private System.Windows.Forms.StatusStrip strStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblGameInfo;
        private System.Windows.Forms.Button btnRomPath;
        private System.Windows.Forms.FolderBrowserDialog fbdRomPath;
        private System.Windows.Forms.Button btnSendGame;
        private System.Windows.Forms.Label lbl3DSIP;
        private System.Windows.Forms.TextBox txt3DSIP;
        private System.Windows.Forms.Timer tmrColorChange;
        private System.Windows.Forms.PictureBox pctBoxArt;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCountry;
    }
}

