namespace objetivoLinha
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
            label1 = new Label();
            modelNameText = new TextBox();
            addBtn = new Button();
            listBox1 = new ListBox();
            label2 = new Label();
            quantityText = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 23);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Adicionar à fila";
            // 
            // modelNameText
            // 
            modelNameText.Location = new Point(161, 120);
            modelNameText.Name = "modelNameText";
            modelNameText.Size = new Size(125, 27);
            modelNameText.TabIndex = 1;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(176, 338);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 29);
            addBtn.TabIndex = 2;
            addBtn.Text = "Adicionar";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(421, 23);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(352, 404);
            listBox1.TabIndex = 3;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 84);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 5;
            label2.Text = "Modelo";
            // 
            // quantityText
            // 
            quantityText.Location = new Point(161, 253);
            quantityText.Name = "quantityText";
            quantityText.Size = new Size(125, 27);
            quantityText.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(176, 220);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 9;
            label4.Text = "Quantidade";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(quantityText);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(addBtn);
            Controls.Add(modelNameText);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox modelNameText;
        private Button addBtn;
        private ListBox listBox1;
        private Label label2;
        private TextBox quantityText;
        private Label label4;
    }
}
