namespace objetivoLinha
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            quantityObjLabel = new Label();
            prodQuant = new Label();
            mediaTimeLabel = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            labelMen = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(148, 46);
            label1.TabIndex = 0;
            label1.Text = "Objetivo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(198, 25);
            label2.Name = "label2";
            label2.Size = new Size(173, 46);
            label2.TabIndex = 1;
            label2.Text = "Produzido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(438, 25);
            label3.Name = "label3";
            label3.Size = new Size(114, 46);
            label3.TabIndex = 2;
            label3.Text = "Média";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(593, 25);
            label4.Name = "label4";
            label4.Size = new Size(204, 46);
            label4.TabIndex = 3;
            label4.Text = "Tempo atual";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(49, 232);
            label5.Name = "label5";
            label5.Size = new Size(297, 46);
            label5.TabIndex = 4;
            label5.Text = "Desvio produzidos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(468, 232);
            label6.Name = "label6";
            label6.Size = new Size(228, 46);
            label6.TabIndex = 5;
            label6.Text = "Desvio tempo";
            // 
            // quantityObjLabel
            // 
            quantityObjLabel.AutoSize = true;
            quantityObjLabel.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            quantityObjLabel.Location = new Point(36, 113);
            quantityObjLabel.Name = "quantityObjLabel";
            quantityObjLabel.Size = new Size(87, 41);
            quantityObjLabel.TabIndex = 6;
            quantityObjLabel.Text = "100";
            // 
            // prodQuant
            // 
            prodQuant.AutoSize = true;
            prodQuant.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            prodQuant.Location = new Point(220, 113);
            prodQuant.Name = "prodQuant";
            prodQuant.Size = new Size(64, 41);
            prodQuant.TabIndex = 7;
            prodQuant.Text = "20";
            // 
            // mediaTimeLabel
            // 
            mediaTimeLabel.AutoSize = true;
            mediaTimeLabel.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            mediaTimeLabel.Location = new Point(438, 113);
            mediaTimeLabel.Name = "mediaTimeLabel";
            mediaTimeLabel.Size = new Size(121, 41);
            mediaTimeLabel.TabIndex = 8;
            mediaTimeLabel.Text = "00:00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(653, 113);
            label10.Name = "label10";
            label10.Size = new Size(121, 41);
            label10.TabIndex = 9;
            label10.Text = "10:00";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(530, 324);
            label11.Name = "label11";
            label11.Size = new Size(121, 41);
            label11.TabIndex = 10;
            label11.Text = "02:55";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(112, 324);
            label12.Name = "label12";
            label12.Size = new Size(50, 41);
            label12.TabIndex = 11;
            label12.Text = "-1";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // labelMen
            // 
            labelMen.AutoSize = true;
            labelMen.Location = new Point(374, 377);
            labelMen.Name = "labelMen";
            labelMen.Size = new Size(50, 20);
            labelMen.TabIndex = 12;
            labelMen.Text = "label7";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelMen);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(mediaTimeLabel);
            Controls.Add(prodQuant);
            Controls.Add(quantityObjLabel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label quantityObjLabel;
        private Label prodQuant;
        private Label mediaTimeLabel;
        private Label label10;
        private Label label11;
        private Label label12;
        private System.Windows.Forms.Timer timer1;
        private Label labelMen;
    }
}