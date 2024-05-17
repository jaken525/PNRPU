namespace ToysDB
{
    partial class Login
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
            loginTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            statusLabel = new Label();
            rememberСheckBox = new CheckBox();
            SuspendLayout();
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(12, 27);
            loginTextBox.MaxLength = 20;
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(142, 23);
            loginTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 3;
            label2.Text = "Пароль:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 71);
            passwordTextBox.MaxLength = 20;
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(142, 23);
            passwordTextBox.TabIndex = 2;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(12, 125);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(142, 23);
            loginButton.TabIndex = 4;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = Color.Red;
            statusLabel.Location = new Point(12, 155);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 15);
            statusLabel.TabIndex = 5;
            // 
            // rememberСheckBox
            // 
            rememberСheckBox.AutoSize = true;
            rememberСheckBox.Location = new Point(12, 100);
            rememberСheckBox.Name = "rememberСheckBox";
            rememberСheckBox.Size = new Size(132, 19);
            rememberСheckBox.TabIndex = 6;
            rememberСheckBox.Text = "Запомнить аккаунт";
            rememberСheckBox.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(166, 177);
            Controls.Add(rememberСheckBox);
            Controls.Add(statusLabel);
            Controls.Add(loginButton);
            Controls.Add(label2);
            Controls.Add(passwordTextBox);
            Controls.Add(label1);
            Controls.Add(loginTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox loginTextBox;
        private Label label1;
        private Label label2;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label statusLabel;
        private CheckBox rememberСheckBox;
    }
}