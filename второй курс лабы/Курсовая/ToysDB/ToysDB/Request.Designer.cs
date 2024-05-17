namespace ToysDB
{
    partial class Request
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
            productComboBox = new ComboBox();
            label2 = new Label();
            countTextBox = new TextBox();
            requestButton = new Button();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Продукт:";
            // 
            // productComboBox
            // 
            productComboBox.FormattingEnabled = true;
            productComboBox.Location = new Point(12, 27);
            productComboBox.Name = "productComboBox";
            productComboBox.Size = new Size(276, 23);
            productComboBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 2;
            label2.Text = "Количество:";
            // 
            // countTextBox
            // 
            countTextBox.Location = new Point(12, 71);
            countTextBox.Name = "countTextBox";
            countTextBox.Size = new Size(276, 23);
            countTextBox.TabIndex = 3;
            // 
            // requestButton
            // 
            requestButton.Location = new Point(12, 100);
            requestButton.Name = "requestButton";
            requestButton.Size = new Size(276, 23);
            requestButton.TabIndex = 4;
            requestButton.Text = "Составить заявку";
            requestButton.UseVisualStyleBackColor = true;
            requestButton.Click += requestButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(239, 15);
            label3.TabIndex = 5;
            label3.Text = "Список игрушек, которых нет в магазине:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 144);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(276, 123);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // Request
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 279);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(requestButton);
            Controls.Add(countTextBox);
            Controls.Add(label2);
            Controls.Add(productComboBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Request";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заявка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox productComboBox;
        private Label label2;
        private TextBox countTextBox;
        private Button requestButton;
        private Label label3;
        private RichTextBox richTextBox1;
    }
}