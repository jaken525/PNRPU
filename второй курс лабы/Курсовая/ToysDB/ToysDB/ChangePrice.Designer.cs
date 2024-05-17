namespace ToysDB
{
    partial class ChangePrice
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
            saleButton = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            toysComboBox = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            textBox3 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // saleButton
            // 
            saleButton.Location = new Point(6, 116);
            saleButton.Name = "saleButton";
            saleButton.Size = new Size(243, 22);
            saleButton.TabIndex = 12;
            saleButton.Text = "Изменить";
            saleButton.UseVisualStyleBackColor = true;
            saleButton.Click += saleButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(243, 23);
            textBox1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 9;
            label2.Text = "Цена: ";
            // 
            // toysComboBox
            // 
            toysComboBox.FormattingEnabled = true;
            toysComboBox.Location = new Point(6, 37);
            toysComboBox.Name = "toysComboBox";
            toysComboBox.Size = new Size(243, 23);
            toysComboBox.TabIndex = 8;
            toysComboBox.SelectedIndexChanged += toysComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 7;
            label1.Text = "Игрушка:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(saleButton);
            groupBox1.Controls.Add(toysComboBox);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 144);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Изменить цену";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 162);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(255, 185);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Установить скидку";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 125);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(243, 23);
            textBox3.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 107);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 13;
            label5.Text = "Новая цена: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 7;
            label3.Text = "Игрушка:";
            // 
            // button1
            // 
            button1.Location = new Point(6, 154);
            button1.Name = "button1";
            button1.Size = new Size(243, 22);
            button1.TabIndex = 12;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 37);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(243, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 81);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(243, 23);
            textBox2.TabIndex = 11;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 63);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 9;
            label4.Text = "Скидка: ";
            // 
            // ChangePrice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 357);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePrice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Работа с игрушкой";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button saleButton;
        private TextBox textBox1;
        private Label label2;
        private ComboBox toysComboBox;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox3;
        private Label label5;
        private Label label3;
        private Button button1;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label4;
    }
}