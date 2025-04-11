namespace InformationSecureLabs
{
    partial class lab4
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
            button1 = new Button();
            richTextBox3 = new RichTextBox();
            label3 = new Label();
            richTextBox2 = new RichTextBox();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 363);
            button1.Name = "button1";
            button1.Size = new Size(239, 23);
            button1.TabIndex = 13;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(12, 261);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new Size(239, 96);
            richTextBox3.TabIndex = 12;
            richTextBox3.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 243);
            label3.Name = "label3";
            label3.Size = new Size(143, 15);
            label3.TabIndex = 11;
            label3.Text = "Расшифрованный текст:";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(12, 144);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(239, 96);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 126);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 9;
            label2.Text = "Зашифрованный текст:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(239, 96);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 7;
            label1.Text = "Исходный текст:";
            // 
            // lab4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 396);
            Controls.Add(button1);
            Controls.Add(richTextBox3);
            Controls.Add(label3);
            Controls.Add(richTextBox2);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "lab4";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Блочное шифрование";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RichTextBox richTextBox3;
        private Label label3;
        private RichTextBox richTextBox2;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label1;
    }
}