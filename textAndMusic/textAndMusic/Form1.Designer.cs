namespace textAndMusic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSelectSongs = new Button();
            panel1 = new Panel();
            buttonClose = new Button();
            label1 = new Label();
            listBox1 = new ListBox();
            mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // btnSelectSongs
            // 
            btnSelectSongs.BackColor = Color.IndianRed;
            btnSelectSongs.Location = new Point(622, 401);
            btnSelectSongs.Name = "btnSelectSongs";
            btnSelectSongs.Size = new Size(162, 56);
            btnSelectSongs.TabIndex = 0;
            btnSelectSongs.Text = "Selecionar Musicas";
            btnSelectSongs.UseVisualStyleBackColor = false;
            btnSelectSongs.Click += btnSelect;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 255);
            panel1.Controls.Add(buttonClose);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(814, 74);
            panel1.TabIndex = 1;
            // 
            // buttonClose
            // 
            buttonClose.BackColor = Color.FromArgb(255, 128, 128);
            buttonClose.BackgroundImageLayout = ImageLayout.None;
            buttonClose.Font = new Font("Ravie", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            buttonClose.Location = new Point(736, 9);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(66, 62);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "X";
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += btnClose;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(199, 50);
            label1.TabIndex = 2;
            label1.Text = "Toca discos";
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(622, 91);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(162, 304);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // mediaPlayer
            // 
            mediaPlayer.Enabled = true;
            mediaPlayer.Location = new Point(12, 91);
            mediaPlayer.Name = "mediaPlayer";
            mediaPlayer.OcxState = (AxHost.State)resources.GetObject("mediaPlayer.OcxState");
            mediaPlayer.Size = new Size(604, 359);
            mediaPlayer.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 478);
            Controls.Add(mediaPlayer);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Controls.Add(btnSelectSongs);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Music Player";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mediaPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelectSongs;
        private Panel panel1;
        private Label label1;
        private Button buttonClose;
        private ListBox listBox1;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
    }
}
