namespace mp3ToWav
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
            convertBtn = new Button();
            SuspendLayout();
            // 
            // convertBtn
            // 
            convertBtn.Location = new Point(337, 197);
            convertBtn.Name = "convertBtn";
            convertBtn.Size = new Size(94, 29);
            convertBtn.TabIndex = 0;
            convertBtn.Text = "Convert";
            convertBtn.UseVisualStyleBackColor = true;
            convertBtn.Click += btnConvert;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(convertBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button convertBtn;
    }
}
