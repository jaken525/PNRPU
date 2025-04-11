namespace InformationSecureLabs
{
    partial class lab2
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
            richTextBoxEncrypt = new RichTextBox();
            label4 = new Label();
            button1 = new Button();
            textBoxQ = new TextBox();
            label3 = new Label();
            textBoxP = new TextBox();
            label2 = new Label();
            label1 = new Label();
            richTextBoxMsg = new RichTextBox();
            textBoxE = new TextBox();
            label5 = new Label();
            label6 = new Label();
            textBoxN = new TextBox();
            label7 = new Label();
            textBoxD = new TextBox();
            label8 = new Label();
            richTextBoxDecrypt = new RichTextBox();
            buttonKeys = new Button();
            SuspendLayout();
            // 
            // richTextBoxEncrypt
            // 
            richTextBoxEncrypt.Location = new Point(12, 272);
            richTextBoxEncrypt.Name = "richTextBoxEncrypt";
            richTextBoxEncrypt.ReadOnly = true;
            richTextBoxEncrypt.Size = new Size(267, 142);
            richTextBoxEncrypt.TabIndex = 7;
            richTextBoxEncrypt.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 254);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 8;
            label4.Text = "Зашифрованное";
            // 
            // button1
            // 
            button1.Location = new Point(12, 228);
            button1.Name = "button1";
            button1.Size = new Size(267, 23);
            button1.TabIndex = 6;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxQ
            // 
            textBoxQ.Location = new Point(179, 141);
            textBoxQ.Name = "textBoxQ";
            textBoxQ.Size = new Size(100, 23);
            textBoxQ.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 144);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 4;
            label3.Text = "q =";
            // 
            // textBoxP
            // 
            textBoxP.Location = new Point(44, 141);
            textBoxP.Name = "textBoxP";
            textBoxP.Size = new Size(100, 23);
            textBoxP.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 144);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 2;
            label2.Text = "p =";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 1;
            label1.Text = "Исходный текст:";
            // 
            // richTextBoxMsg
            // 
            richTextBoxMsg.Location = new Point(12, 27);
            richTextBoxMsg.Name = "richTextBoxMsg";
            richTextBoxMsg.Size = new Size(267, 108);
            richTextBoxMsg.TabIndex = 0;
            richTextBoxMsg.Text = "";
            // 
            // textBoxE
            // 
            textBoxE.Location = new Point(179, 170);
            textBoxE.Name = "textBoxE";
            textBoxE.Size = new Size(100, 23);
            textBoxE.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(148, 173);
            label5.Name = "label5";
            label5.Size = new Size(24, 15);
            label5.TabIndex = 8;
            label5.Text = "e =";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 173);
            label6.Name = "label6";
            label6.Size = new Size(25, 15);
            label6.TabIndex = 6;
            label6.Text = "n =";
            // 
            // textBoxN
            // 
            textBoxN.Location = new Point(44, 170);
            textBoxN.Name = "textBoxN";
            textBoxN.Size = new Size(100, 23);
            textBoxN.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 202);
            label7.Name = "label7";
            label7.Size = new Size(25, 15);
            label7.TabIndex = 8;
            label7.Text = "d =";
            // 
            // textBoxD
            // 
            textBoxD.Location = new Point(44, 199);
            textBoxD.Name = "textBoxD";
            textBoxD.Size = new Size(100, 23);
            textBoxD.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 417);
            label8.Name = "label8";
            label8.Size = new Size(106, 15);
            label8.TabIndex = 8;
            label8.Text = "Расшифрованное";
            // 
            // richTextBoxDecrypt
            // 
            richTextBoxDecrypt.Location = new Point(10, 435);
            richTextBoxDecrypt.Name = "richTextBoxDecrypt";
            richTextBoxDecrypt.ReadOnly = true;
            richTextBoxDecrypt.Size = new Size(267, 142);
            richTextBoxDecrypt.TabIndex = 7;
            richTextBoxDecrypt.Text = "";
            // 
            // buttonKeys
            // 
            buttonKeys.Location = new Point(150, 199);
            buttonKeys.Name = "buttonKeys";
            buttonKeys.Size = new Size(129, 23);
            buttonKeys.TabIndex = 10;
            buttonKeys.Text = "Генерация";
            buttonKeys.UseVisualStyleBackColor = true;
            buttonKeys.Click += buttonKeys_Click;
            // 
            // lab2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 582);
            Controls.Add(buttonKeys);
            Controls.Add(richTextBoxDecrypt);
            Controls.Add(richTextBoxEncrypt);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(textBoxD);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(textBoxE);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(textBoxN);
            Controls.Add(richTextBoxMsg);
            Controls.Add(label1);
            Controls.Add(textBoxQ);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxP);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "lab2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RSA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private RichTextBox richTextBoxMsg;
        private RichTextBox richTextBoxEncrypt;
        private Label label4;
        private Button button1;
        private TextBox textBoxQ;
        private Label label3;
        private TextBox textBoxP;
        private TextBox textBoxE;
        private Label label5;
        private Label label6;
        private TextBox textBoxN;
        private Label label7;
        private TextBox textBoxD;
        private Label label8;
        private RichTextBox richTextBoxDecrypt;
        private Button buttonKeys;
    }
}