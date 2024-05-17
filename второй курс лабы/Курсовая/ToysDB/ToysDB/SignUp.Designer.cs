namespace ToysDB
{
    partial class SignUp
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
            employeeDataGroupBox = new GroupBox();
            label6 = new Label();
            shopComboBox = new ComboBox();
            label5 = new Label();
            genderComboBox = new ComboBox();
            label4 = new Label();
            ageTextBox = new TextBox();
            label3 = new Label();
            patronymicTextBox = new TextBox();
            label2 = new Label();
            surnameTextBox = new TextBox();
            label1 = new Label();
            nameTextBox = new TextBox();
            signButton = new Button();
            statusRichTextBox = new RichTextBox();
            label7 = new Label();
            employeeDataGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // employeeDataGroupBox
            // 
            employeeDataGroupBox.Controls.Add(label6);
            employeeDataGroupBox.Controls.Add(shopComboBox);
            employeeDataGroupBox.Controls.Add(label5);
            employeeDataGroupBox.Controls.Add(genderComboBox);
            employeeDataGroupBox.Controls.Add(label4);
            employeeDataGroupBox.Controls.Add(ageTextBox);
            employeeDataGroupBox.Controls.Add(label3);
            employeeDataGroupBox.Controls.Add(patronymicTextBox);
            employeeDataGroupBox.Controls.Add(label2);
            employeeDataGroupBox.Controls.Add(surnameTextBox);
            employeeDataGroupBox.Controls.Add(label1);
            employeeDataGroupBox.Controls.Add(nameTextBox);
            employeeDataGroupBox.Location = new Point(12, 12);
            employeeDataGroupBox.Name = "employeeDataGroupBox";
            employeeDataGroupBox.Size = new Size(224, 197);
            employeeDataGroupBox.TabIndex = 0;
            employeeDataGroupBox.TabStop = false;
            employeeDataGroupBox.Text = "Информация работника";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 170);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 11;
            label6.Text = "Магазин: ";
            // 
            // shopComboBox
            // 
            shopComboBox.FormattingEnabled = true;
            shopComboBox.Location = new Point(76, 167);
            shopComboBox.Name = "shopComboBox";
            shopComboBox.Size = new Size(142, 23);
            shopComboBox.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 141);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 9;
            label5.Text = "Пол: ";
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Items.AddRange(new object[] { "Мужчина", "Женщина", "Боевой вертолёт", "Пакет из пятёрочки" });
            genderComboBox.Location = new Point(76, 138);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(142, 23);
            genderComboBox.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 112);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 7;
            label4.Text = "Возраст: ";
            // 
            // ageTextBox
            // 
            ageTextBox.Location = new Point(76, 109);
            ageTextBox.MaxLength = 3;
            ageTextBox.Name = "ageTextBox";
            ageTextBox.Size = new Size(142, 23);
            ageTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 83);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 5;
            label3.Text = "Отчество: ";
            // 
            // patronymicTextBox
            // 
            patronymicTextBox.Location = new Point(76, 80);
            patronymicTextBox.Name = "patronymicTextBox";
            patronymicTextBox.Size = new Size(142, 23);
            patronymicTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 54);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "Фамилия: ";
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(76, 51);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(142, 23);
            surnameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 1;
            label1.Text = "Имя: ";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(76, 22);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(142, 23);
            nameTextBox.TabIndex = 0;
            // 
            // signButton
            // 
            signButton.Location = new Point(12, 215);
            signButton.Name = "signButton";
            signButton.Size = new Size(224, 23);
            signButton.TabIndex = 1;
            signButton.Text = "Зарегистрировать";
            signButton.UseVisualStyleBackColor = true;
            signButton.Click += signButton_Click;
            // 
            // statusRichTextBox
            // 
            statusRichTextBox.Location = new Point(12, 259);
            statusRichTextBox.Name = "statusRichTextBox";
            statusRichTextBox.ReadOnly = true;
            statusRichTextBox.Size = new Size(224, 109);
            statusRichTextBox.TabIndex = 2;
            statusRichTextBox.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 241);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 3;
            label7.Text = "Статус:";
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 380);
            Controls.Add(label7);
            Controls.Add(statusRichTextBox);
            Controls.Add(signButton);
            Controls.Add(employeeDataGroupBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            employeeDataGroupBox.ResumeLayout(false);
            employeeDataGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox employeeDataGroupBox;
        private Label label3;
        private TextBox patronymicTextBox;
        private Label label2;
        private TextBox surnameTextBox;
        private Label label1;
        private TextBox nameTextBox;
        private Label label4;
        private TextBox ageTextBox;
        private Label label6;
        private ComboBox shopComboBox;
        private Label label5;
        private ComboBox genderComboBox;
        private Button signButton;
        private RichTextBox statusRichTextBox;
        private Label label7;
    }
}