namespace ToysDB
{
    partial class Window
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
            components = new System.ComponentModel.Container();
            tableNameGroupBox = new GroupBox();
            dataGridView1 = new DataGridView();
            loginButton = new Button();
            controlsGroupBox = new GroupBox();
            changeDataButton = new Button();
            additionalButton = new Button();
            signUpButton = new Button();
            queryGroupBox = new GroupBox();
            button8 = new Button();
            button7 = new Button();
            button5 = new Button();
            button2 = new Button();
            button1 = new Button();
            button4 = new Button();
            button3 = new Button();
            saleButton = new Button();
            updateButton = new Button();
            tablesComboBox = new ComboBox();
            choiceTableLable = new Label();
            sqlButton = new Button();
            accountNameLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            shopLabel = new Label();
            rightsLabel = new Label();
            tableNameGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            controlsGroupBox.SuspendLayout();
            queryGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // tableNameGroupBox
            // 
            tableNameGroupBox.Controls.Add(dataGridView1);
            tableNameGroupBox.Location = new Point(12, 12);
            tableNameGroupBox.Name = "tableNameGroupBox";
            tableNameGroupBox.Size = new Size(674, 546);
            tableNameGroupBox.TabIndex = 0;
            tableNameGroupBox.TabStop = false;
            tableNameGroupBox.Text = "Таблица";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(662, 518);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.UserAddedRow += dataGridView1_UserAddedRow;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(862, 12);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(55, 23);
            loginButton.TabIndex = 1;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // controlsGroupBox
            // 
            controlsGroupBox.Controls.Add(changeDataButton);
            controlsGroupBox.Controls.Add(additionalButton);
            controlsGroupBox.Controls.Add(signUpButton);
            controlsGroupBox.Controls.Add(queryGroupBox);
            controlsGroupBox.Controls.Add(updateButton);
            controlsGroupBox.Controls.Add(tablesComboBox);
            controlsGroupBox.Controls.Add(choiceTableLable);
            controlsGroupBox.Controls.Add(sqlButton);
            controlsGroupBox.Location = new Point(692, 78);
            controlsGroupBox.Name = "controlsGroupBox";
            controlsGroupBox.Size = new Size(225, 480);
            controlsGroupBox.TabIndex = 2;
            controlsGroupBox.TabStop = false;
            controlsGroupBox.Text = "Управление";
            // 
            // changeDataButton
            // 
            changeDataButton.Location = new Point(6, 167);
            changeDataButton.Name = "changeDataButton";
            changeDataButton.Size = new Size(213, 23);
            changeDataButton.TabIndex = 12;
            changeDataButton.Text = "Сменить логин или пароль";
            changeDataButton.UseVisualStyleBackColor = true;
            changeDataButton.Click += changeDataButton_Click;
            // 
            // additionalButton
            // 
            additionalButton.Location = new Point(6, 51);
            additionalButton.Name = "additionalButton";
            additionalButton.Size = new Size(213, 23);
            additionalButton.TabIndex = 6;
            additionalButton.Text = "Показать дополнительную таблицу";
            additionalButton.UseVisualStyleBackColor = true;
            additionalButton.Click += additionalButton_Click;
            // 
            // signUpButton
            // 
            signUpButton.Location = new Point(6, 138);
            signUpButton.Name = "signUpButton";
            signUpButton.Size = new Size(213, 23);
            signUpButton.TabIndex = 9;
            signUpButton.Text = "Зарегистрировать работника";
            signUpButton.UseVisualStyleBackColor = true;
            signUpButton.Click += signUpButton_Click;
            // 
            // queryGroupBox
            // 
            queryGroupBox.Controls.Add(button8);
            queryGroupBox.Controls.Add(button7);
            queryGroupBox.Controls.Add(button5);
            queryGroupBox.Controls.Add(button2);
            queryGroupBox.Controls.Add(button1);
            queryGroupBox.Controls.Add(button4);
            queryGroupBox.Controls.Add(button3);
            queryGroupBox.Controls.Add(saleButton);
            queryGroupBox.Location = new Point(6, 196);
            queryGroupBox.Name = "queryGroupBox";
            queryGroupBox.Size = new Size(213, 278);
            queryGroupBox.TabIndex = 5;
            queryGroupBox.TabStop = false;
            queryGroupBox.Text = "Запросы";
            // 
            // button8
            // 
            button8.Location = new Point(6, 243);
            button8.Name = "button8";
            button8.Size = new Size(201, 29);
            button8.TabIndex = 11;
            button8.Text = "Игрушки со скидкой";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(6, 214);
            button7.Name = "button7";
            button7.Size = new Size(201, 23);
            button7.TabIndex = 10;
            button7.Text = "Склад магазина";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button5
            // 
            button5.Location = new Point(6, 185);
            button5.Name = "button5";
            button5.Size = new Size(201, 23);
            button5.TabIndex = 8;
            button5.Text = "Установить скидку на игрушку";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(6, 156);
            button2.Name = "button2";
            button2.Size = new Size(201, 23);
            button2.TabIndex = 7;
            button2.Text = "Изменить цену на игрушку";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(6, 127);
            button1.Name = "button1";
            button1.Size = new Size(201, 23);
            button1.TabIndex = 6;
            button1.Text = "Закупка перспективных игрушек";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(6, 80);
            button4.Name = "button4";
            button4.Size = new Size(201, 41);
            button4.TabIndex = 5;
            button4.Text = "Увеличение поставок популярных игрушек";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(6, 51);
            button3.Name = "button3";
            button3.Size = new Size(201, 23);
            button3.TabIndex = 4;
            button3.Text = "Оформить заявку";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // saleButton
            // 
            saleButton.Location = new Point(6, 22);
            saleButton.Name = "saleButton";
            saleButton.Size = new Size(201, 23);
            saleButton.TabIndex = 3;
            saleButton.Text = "Продать игрушку";
            saleButton.UseVisualStyleBackColor = true;
            saleButton.Click += saleButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(6, 109);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(213, 23);
            updateButton.TabIndex = 4;
            updateButton.Text = "Обновить таблицы";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // tablesComboBox
            // 
            tablesComboBox.FormattingEnabled = true;
            tablesComboBox.Location = new Point(111, 80);
            tablesComboBox.Name = "tablesComboBox";
            tablesComboBox.Size = new Size(108, 23);
            tablesComboBox.TabIndex = 2;
            tablesComboBox.SelectedIndexChanged += tablesComboBox_SelectedIndexChanged;
            // 
            // choiceTableLable
            // 
            choiceTableLable.AutoSize = true;
            choiceTableLable.Location = new Point(6, 83);
            choiceTableLable.Name = "choiceTableLable";
            choiceTableLable.Size = new Size(101, 15);
            choiceTableLable.TabIndex = 1;
            choiceTableLable.Text = "Выбор таблицы: ";
            // 
            // sqlButton
            // 
            sqlButton.Location = new Point(6, 22);
            sqlButton.Name = "sqlButton";
            sqlButton.Size = new Size(213, 23);
            sqlButton.TabIndex = 0;
            sqlButton.Text = "Ввести SQL комманду";
            sqlButton.UseVisualStyleBackColor = true;
            sqlButton.Click += sqlButton_Click;
            // 
            // accountNameLabel
            // 
            accountNameLabel.AutoSize = true;
            accountNameLabel.Location = new Point(692, 16);
            accountNameLabel.Name = "accountNameLabel";
            accountNameLabel.Size = new Size(65, 15);
            accountNameLabel.TabIndex = 3;
            accountNameLabel.Text = "Работник: ";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // shopLabel
            // 
            shopLabel.AutoSize = true;
            shopLabel.Location = new Point(692, 38);
            shopLabel.Name = "shopLabel";
            shopLabel.Size = new Size(60, 15);
            shopLabel.TabIndex = 4;
            shopLabel.Text = "Магазин: ";
            // 
            // rightsLabel
            // 
            rightsLabel.AutoSize = true;
            rightsLabel.Location = new Point(692, 60);
            rightsLabel.Name = "rightsLabel";
            rightsLabel.Size = new Size(47, 15);
            rightsLabel.TabIndex = 8;
            rightsLabel.Text = "Права: ";
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 570);
            Controls.Add(rightsLabel);
            Controls.Add(shopLabel);
            Controls.Add(accountNameLabel);
            Controls.Add(controlsGroupBox);
            Controls.Add(loginButton);
            Controls.Add(tableNameGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Window";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Toys";
            tableNameGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            controlsGroupBox.ResumeLayout(false);
            controlsGroupBox.PerformLayout();
            queryGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox tableNameGroupBox;
        private Button loginButton;
        private GroupBox controlsGroupBox;
        private Label accountNameLabel;
        private DataGridView dataGridView1;
        private Button sqlButton;
        private ComboBox tablesComboBox;
        private Label choiceTableLable;
        private Button saleButton;
        private System.Windows.Forms.Timer timer1;
        private Button updateButton;
        private Label shopLabel;
        private Button button1;
        private Button button2;
        private Label rightsLabel;
        private GroupBox queryGroupBox;
        private Button additionalButton;
        private Button button4;
        private Button button3;
        private Button changeDataButton;
        private Button button8;
        private Button button7;
        private Button signUpButton;
        private Button button5;
    }
}
