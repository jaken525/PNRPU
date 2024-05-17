namespace ToysDB
{
    partial class SaleToy
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
            label1 = new Label();
            toysComboBox = new ComboBox();
            label2 = new Label();
            countLabel = new Label();
            textBox1 = new TextBox();
            saleButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 0;
            label1.Text = "Игрушка на продажу:";
            // 
            // toysComboBox
            // 
            toysComboBox.FormattingEnabled = true;
            toysComboBox.Location = new Point(145, 12);
            toysComboBox.Name = "toysComboBox";
            toysComboBox.Size = new Size(123, 23);
            toysComboBox.TabIndex = 1;
            toysComboBox.SelectedIndexChanged += toysComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 3;
            label2.Text = "Количество: ";
            // 
            // countLabel
            // 
            countLabel.AutoSize = true;
            countLabel.Location = new Point(12, 45);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(141, 15);
            countLabel.TabIndex = 4;
            countLabel.Text = "Количество в магазине: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(166, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(102, 23);
            textBox1.TabIndex = 5;
            // 
            // saleButton
            // 
            saleButton.Location = new Point(12, 100);
            saleButton.Name = "saleButton";
            saleButton.Size = new Size(256, 22);
            saleButton.TabIndex = 6;
            saleButton.Text = "Продать";
            saleButton.UseVisualStyleBackColor = true;
            saleButton.Click += saleButton_Click;
            // 
            // SaleToy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 134);
            Controls.Add(saleButton);
            Controls.Add(textBox1);
            Controls.Add(countLabel);
            Controls.Add(label2);
            Controls.Add(toysComboBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaleToy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Продажа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox toysComboBox;
        private Label label2;
        private Label countLabel;
        private TextBox textBox1;
        private Button saleButton;
    }
}