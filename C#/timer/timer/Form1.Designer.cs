namespace timer
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.actualTimeLabel = new System.Windows.Forms.Label();
            this.desireTimeText = new System.Windows.Forms.TextBox();
            this.timeLeftLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textLabel1 = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.choosenHours = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // actualTimeLabel
            // 
            this.actualTimeLabel.AutoSize = true;
            this.actualTimeLabel.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualTimeLabel.Location = new System.Drawing.Point(304, 50);
            this.actualTimeLabel.Name = "actualTimeLabel";
            this.actualTimeLabel.Size = new System.Drawing.Size(136, 32);
            this.actualTimeLabel.TabIndex = 0;
            this.actualTimeLabel.Text = "XX:XX:XX";
            // 
            // desireTimeText
            // 
            this.desireTimeText.Location = new System.Drawing.Point(326, 332);
            this.desireTimeText.Name = "desireTimeText";
            this.desireTimeText.Size = new System.Drawing.Size(100, 22);
            this.desireTimeText.TabIndex = 2;
            // 
            // timeLeftLabel
            // 
            this.timeLeftLabel.AutoSize = true;
            this.timeLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLeftLabel.Location = new System.Drawing.Point(305, 170);
            this.timeLeftLabel.Name = "timeLeftLabel";
            this.timeLeftLabel.Size = new System.Drawing.Size(111, 29);
            this.timeLeftLabel.TabIndex = 3;
            this.timeLeftLabel.Text = "00:00:00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textLabel1
            // 
            this.textLabel1.AutoSize = true;
            this.textLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel1.Location = new System.Drawing.Point(333, 129);
            this.textLabel1.Name = "textLabel1";
            this.textLabel1.Size = new System.Drawing.Size(71, 25);
            this.textLabel1.TabIndex = 5;
            this.textLabel1.Text = "Faltam";
            // 
            // labelText2
            // 
            this.labelText2.AutoSize = true;
            this.labelText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelText2.Location = new System.Drawing.Point(334, 216);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(59, 22);
            this.labelText2.TabIndex = 6;
            this.labelText2.Text = "até às";
            // 
            // choosenHours
            // 
            this.choosenHours.AutoSize = true;
            this.choosenHours.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosenHours.Location = new System.Drawing.Point(333, 262);
            this.choosenHours.Name = "choosenHours";
            this.choosenHours.Size = new System.Drawing.Size(94, 28);
            this.choosenHours.TabIndex = 7;
            this.choosenHours.Text = "00:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.choosenHours);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.textLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeLeftLabel);
            this.Controls.Add(this.desireTimeText);
            this.Controls.Add(this.actualTimeLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label actualTimeLabel;
        private System.Windows.Forms.TextBox desireTimeText;
        private System.Windows.Forms.Label timeLeftLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label textLabel1;
        private System.Windows.Forms.Label labelText2;
        private System.Windows.Forms.Label choosenHours;
    }
}

