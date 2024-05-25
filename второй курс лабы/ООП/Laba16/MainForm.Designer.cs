
using System.Collections.Generic;
using System.IO;
using WinForm.Persons;

namespace WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.AddElemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddRandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CountAddedRand = new System.Windows.Forms.ToolStripTextBox();
            this.AddRandButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteElemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteElemtoolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.DeleteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NameTextBoxTool = new System.Windows.Forms.ToolStripTextBox();
            this.NameSearchButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AgeSearchButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AgeTextBoxTool = new System.Windows.Forms.ToolStripTextBox();
            this.SearchAgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BinFileNameText = new System.Windows.Forms.ToolStripTextBox();
            this.SaveBinButton = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonFileNameText = new System.Windows.Forms.ToolStripTextBox();
            this.SaveJsonButton = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XmlFileNameText = new System.Windows.Forms.ToolStripTextBox();
            this.SaveXmlButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllFileNameButton = new System.Windows.Forms.ToolStripMenuItem();
            this.BinToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BinComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.LoadBinButton = new System.Windows.Forms.ToolStripMenuItem();
            this.XmlToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.XmlComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.LoadXmlButton = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.LoadJsonButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGroupBox = new System.Windows.Forms.GroupBox();
            this.AgeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.ResultGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ageTextBox1 = new System.Windows.Forms.TextBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.ResultListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.AddGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AgeNumericUpDown)).BeginInit();
            this.ResultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddElemToolStripMenuItem,
            this.DeleteElemToolStripMenuItem,
            this.SearchToolStripMenuItem,
            this.PrintToolStripMenuItem,
            this.ClearToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.LoadToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(663, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // AddElemToolStripMenuItem
            // 
            this.AddElemToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.AddElemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddManualToolStripMenuItem,
            this.AddRandToolStripMenuItem});
            this.AddElemToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AddElemToolStripMenuItem.Name = "AddElemToolStripMenuItem";
            this.AddElemToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.AddElemToolStripMenuItem.Text = "Добавить элемент";
            // 
            // AddManualToolStripMenuItem
            // 
            this.AddManualToolStripMenuItem.Name = "AddManualToolStripMenuItem";
            this.AddManualToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.AddManualToolStripMenuItem.Text = "Добавить вручную";
            this.AddManualToolStripMenuItem.Click += new System.EventHandler(this.AddManual_Click);
            // 
            // AddRandToolStripMenuItem
            // 
            this.AddRandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CountAddedRand,
            this.AddRandButton});
            this.AddRandToolStripMenuItem.Name = "AddRandToolStripMenuItem";
            this.AddRandToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.AddRandToolStripMenuItem.Text = "Добавить через ДСЧ";
            // 
            // CountAddedRand
            // 
            this.CountAddedRand.BackColor = System.Drawing.SystemColors.Window;
            this.CountAddedRand.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CountAddedRand.MaxLength = 3;
            this.CountAddedRand.Name = "CountAddedRand";
            this.CountAddedRand.Size = new System.Drawing.Size(100, 23);
            this.CountAddedRand.Text = "1";
            this.CountAddedRand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.CountAddedRand.TextChanged += new System.EventHandler(this.CountAddedRand_TextChange);
            // 
            // AddRandButton
            // 
            this.AddRandButton.BackColor = System.Drawing.Color.White;
            this.AddRandButton.Name = "AddRandButton";
            this.AddRandButton.Size = new System.Drawing.Size(160, 22);
            this.AddRandButton.Text = "Добавить";
            this.AddRandButton.Click += new System.EventHandler(this.AddRandom_Click);
            // 
            // DeleteElemToolStripMenuItem
            // 
            this.DeleteElemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteElemtoolStripComboBox,
            this.DeleteButton});
            this.DeleteElemToolStripMenuItem.Name = "DeleteElemToolStripMenuItem";
            this.DeleteElemToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.DeleteElemToolStripMenuItem.Text = "Удалить элемент";
            this.DeleteElemToolStripMenuItem.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DeleteElemtoolStripComboBox
            // 
            this.DeleteElemtoolStripComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.DeleteElemtoolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeleteElemtoolStripComboBox.Name = "DeleteElemtoolStripComboBox";
            this.DeleteElemtoolStripComboBox.Size = new System.Drawing.Size(121, 23);
            this.DeleteElemtoolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.DeleteComboBox_TextChange);
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.White;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(181, 22);
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click_1);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.AgeSearchButton});
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.SearchToolStripMenuItem.Text = "Поиск";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameTextBoxTool,
            this.NameSearchButton});
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nameToolStripMenuItem.Text = "Имя";
            // 
            // NameTextBoxTool
            // 
            this.NameTextBoxTool.BackColor = System.Drawing.SystemColors.Window;
            this.NameTextBoxTool.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NameTextBoxTool.MaxLength = 25;
            this.NameTextBoxTool.Name = "NameTextBoxTool";
            this.NameTextBoxTool.Size = new System.Drawing.Size(130, 23);
            this.NameTextBoxTool.Text = "Имя";
            // 
            // NameSearchButton
            // 
            this.NameSearchButton.BackColor = System.Drawing.Color.White;
            this.NameSearchButton.Name = "NameSearchButton";
            this.NameSearchButton.Size = new System.Drawing.Size(190, 22);
            this.NameSearchButton.Text = "Искать";
            this.NameSearchButton.Click += new System.EventHandler(this.SearchNameButton_Click);
            // 
            // AgeSearchButton
            // 
            this.AgeSearchButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgeTextBoxTool,
            this.SearchAgeToolStripMenuItem});
            this.AgeSearchButton.Name = "AgeSearchButton";
            this.AgeSearchButton.Size = new System.Drawing.Size(117, 22);
            this.AgeSearchButton.Text = "Возраст";
            // 
            // AgeTextBoxTool
            // 
            this.AgeTextBoxTool.BackColor = System.Drawing.SystemColors.Window;
            this.AgeTextBoxTool.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AgeTextBoxTool.MaxLength = 3;
            this.AgeTextBoxTool.Name = "AgeTextBoxTool";
            this.AgeTextBoxTool.Size = new System.Drawing.Size(130, 23);
            this.AgeTextBoxTool.Text = "18";
            this.AgeTextBoxTool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // SearchAgeToolStripMenuItem
            // 
            this.SearchAgeToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.SearchAgeToolStripMenuItem.Name = "SearchAgeToolStripMenuItem";
            this.SearchAgeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.SearchAgeToolStripMenuItem.Text = "Искать";
            this.SearchAgeToolStripMenuItem.Click += new System.EventHandler(this.SearchAgeButton_Click);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.PrintToolStripMenuItem.Text = "Печать";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.ClearToolStripMenuItem.Text = "Очистить коллекцию";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearCollectButton_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bINToolStripMenuItem,
            this.jSONToolStripMenuItem,
            this.xMLToolStripMenuItem});
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            // 
            // bINToolStripMenuItem
            // 
            this.bINToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BinFileNameText,
            this.SaveBinButton});
            this.bINToolStripMenuItem.Name = "bINToolStripMenuItem";
            this.bINToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.bINToolStripMenuItem.Text = "BIN";
            // 
            // BinFileNameText
            // 
            this.BinFileNameText.BackColor = System.Drawing.SystemColors.Window;
            this.BinFileNameText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BinFileNameText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.BinFileNameText.Name = "BinFileNameText";
            this.BinFileNameText.Size = new System.Drawing.Size(100, 23);
            this.BinFileNameText.Text = "Имя";
            this.BinFileNameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // SaveBinButton
            // 
            this.SaveBinButton.BackColor = System.Drawing.Color.White;
            this.SaveBinButton.Enabled = false;
            this.SaveBinButton.Name = "SaveBinButton";
            this.SaveBinButton.Size = new System.Drawing.Size(160, 22);
            this.SaveBinButton.Text = "Сохранить";
            this.SaveBinButton.Click += new System.EventHandler(this.SaveBinButton_Click);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JsonFileNameText,
            this.SaveJsonButton});
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.jSONToolStripMenuItem.Text = "JSON";
            // 
            // JsonFileNameText
            // 
            this.JsonFileNameText.BackColor = System.Drawing.SystemColors.Window;
            this.JsonFileNameText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.JsonFileNameText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.JsonFileNameText.Name = "JsonFileNameText";
            this.JsonFileNameText.Size = new System.Drawing.Size(100, 23);
            this.JsonFileNameText.Text = "Имя";
            this.JsonFileNameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // SaveJsonButton
            // 
            this.SaveJsonButton.BackColor = System.Drawing.Color.White;
            this.SaveJsonButton.Enabled = false;
            this.SaveJsonButton.Name = "SaveJsonButton";
            this.SaveJsonButton.Size = new System.Drawing.Size(160, 22);
            this.SaveJsonButton.Text = "Сохранить";
            this.SaveJsonButton.Click += new System.EventHandler(this.SaveJsonButton_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XmlFileNameText,
            this.SaveXmlButton});
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.xMLToolStripMenuItem.Text = "XML";
            // 
            // XmlFileNameText
            // 
            this.XmlFileNameText.BackColor = System.Drawing.SystemColors.Window;
            this.XmlFileNameText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.XmlFileNameText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.XmlFileNameText.Name = "XmlFileNameText";
            this.XmlFileNameText.Size = new System.Drawing.Size(100, 23);
            this.XmlFileNameText.Text = "Имя";
            this.XmlFileNameText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // SaveXmlButton
            // 
            this.SaveXmlButton.BackColor = System.Drawing.Color.White;
            this.SaveXmlButton.Enabled = false;
            this.SaveXmlButton.Name = "SaveXmlButton";
            this.SaveXmlButton.Size = new System.Drawing.Size(160, 22);
            this.SaveXmlButton.Text = "Сохранить";
            this.SaveXmlButton.Click += new System.EventHandler(this.SaveXmlButton_Click);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AllFileNameButton,
            this.BinToolStripMenu,
            this.XmlToolStripMenu,
            this.JsonToolStripMenu});
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.LoadToolStripMenuItem.Text = "Загрузить";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.CheckAllFilesButton_Click);
            // 
            // AllFileNameButton
            // 
            this.AllFileNameButton.BackColor = System.Drawing.Color.White;
            this.AllFileNameButton.Name = "AllFileNameButton";
            this.AllFileNameButton.Size = new System.Drawing.Size(203, 22);
            this.AllFileNameButton.Text = "Просмотр всех файлов";
            this.AllFileNameButton.Click += new System.EventHandler(this.CheckSaveFilesButton_Click);
            // 
            // BinToolStripMenu
            // 
            this.BinToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BinComboBox,
            this.LoadBinButton});
            this.BinToolStripMenu.Name = "BinToolStripMenu";
            this.BinToolStripMenu.Size = new System.Drawing.Size(203, 22);
            this.BinToolStripMenu.Text = "BIN";
            this.BinToolStripMenu.Click += new System.EventHandler(this.BinListLoad);
            // 
            // BinComboBox
            // 
            this.BinComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.BinComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BinComboBox.Name = "BinComboBox";
            this.BinComboBox.Size = new System.Drawing.Size(121, 23);
            this.BinComboBox.SelectedIndexChanged += new System.EventHandler(this.BinComboBox_SelectedIndexChanged);
            // 
            // LoadBinButton
            // 
            this.LoadBinButton.BackColor = System.Drawing.Color.White;
            this.LoadBinButton.Enabled = false;
            this.LoadBinButton.Name = "LoadBinButton";
            this.LoadBinButton.Size = new System.Drawing.Size(181, 22);
            this.LoadBinButton.Text = "Загрузить";
            this.LoadBinButton.Click += new System.EventHandler(this.LoadBinFile);
            // 
            // XmlToolStripMenu
            // 
            this.XmlToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XmlComboBox,
            this.LoadXmlButton});
            this.XmlToolStripMenu.Name = "XmlToolStripMenu";
            this.XmlToolStripMenu.Size = new System.Drawing.Size(203, 22);
            this.XmlToolStripMenu.Text = "XML";
            this.XmlToolStripMenu.Click += new System.EventHandler(this.XmlListLoad);
            // 
            // XmlComboBox
            // 
            this.XmlComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.XmlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XmlComboBox.Name = "XmlComboBox";
            this.XmlComboBox.Size = new System.Drawing.Size(121, 23);
            this.XmlComboBox.SelectedIndexChanged += new System.EventHandler(this.XmlComboBox_SelectedIndexChanged);
            // 
            // LoadXmlButton
            // 
            this.LoadXmlButton.BackColor = System.Drawing.Color.White;
            this.LoadXmlButton.Enabled = false;
            this.LoadXmlButton.Name = "LoadXmlButton";
            this.LoadXmlButton.Size = new System.Drawing.Size(181, 22);
            this.LoadXmlButton.Text = "Загрузить";
            this.LoadXmlButton.Click += new System.EventHandler(this.LoadXmlFile);
            // 
            // JsonToolStripMenu
            // 
            this.JsonToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.JsonComboBox,
            this.LoadJsonButton});
            this.JsonToolStripMenu.Name = "JsonToolStripMenu";
            this.JsonToolStripMenu.Size = new System.Drawing.Size(203, 22);
            this.JsonToolStripMenu.Text = "JSON";
            this.JsonToolStripMenu.Click += new System.EventHandler(this.JsonListLoad);
            // 
            // JsonComboBox
            // 
            this.JsonComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.JsonComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JsonComboBox.Name = "JsonComboBox";
            this.JsonComboBox.Size = new System.Drawing.Size(121, 23);
            this.JsonComboBox.SelectedIndexChanged += new System.EventHandler(this.JsonComboBox_SelectedIndexChanged);
            // 
            // LoadJsonButton
            // 
            this.LoadJsonButton.BackColor = System.Drawing.Color.White;
            this.LoadJsonButton.Enabled = false;
            this.LoadJsonButton.Name = "LoadJsonButton";
            this.LoadJsonButton.Size = new System.Drawing.Size(181, 22);
            this.LoadJsonButton.Text = "Загрузить";
            this.LoadJsonButton.Click += new System.EventHandler(this.LoadJsonFile);
            // 
            // AddGroupBox
            // 
            this.AddGroupBox.BackColor = System.Drawing.SystemColors.Menu;
            this.AddGroupBox.Controls.Add(this.AgeNumericUpDown);
            this.AddGroupBox.Controls.Add(this.DescriptionRichTextBox);
            this.AddGroupBox.Controls.Add(this.label5);
            this.AddGroupBox.Controls.Add(this.label4);
            this.AddGroupBox.Controls.Add(this.NameTextBox);
            this.AddGroupBox.Controls.Add(this.label3);
            this.AddGroupBox.Controls.Add(this.AddButton);
            this.AddGroupBox.Enabled = false;
            this.AddGroupBox.Location = new System.Drawing.Point(71, 25);
            this.AddGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddGroupBox.Name = "AddGroupBox";
            this.AddGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.AddGroupBox.Size = new System.Drawing.Size(500, 129);
            this.AddGroupBox.TabIndex = 1;
            this.AddGroupBox.TabStop = false;
            // 
            // AgeNumericUpDown
            // 
            this.AgeNumericUpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AgeNumericUpDown.Location = new System.Drawing.Point(117, 48);
            this.AgeNumericUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.AgeNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.AgeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AgeNumericUpDown.Name = "AgeNumericUpDown";
            this.AgeNumericUpDown.Size = new System.Drawing.Size(112, 20);
            this.AgeNumericUpDown.TabIndex = 11;
            this.AgeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DescriptionRichTextBox
            // 
            this.DescriptionRichTextBox.Location = new System.Drawing.Point(233, 30);
            this.DescriptionRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionRichTextBox.MaxLength = 1000;
            this.DescriptionRichTextBox.Name = "DescriptionRichTextBox";
            this.DescriptionRichTextBox.Size = new System.Drawing.Size(263, 95);
            this.DescriptionRichTextBox.TabIndex = 9;
            this.DescriptionRichTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(233, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Описание:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Имя:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(117, 12);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.NameTextBox.MaxLength = 25;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(112, 20);
            this.NameTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Возвраст:";
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.White;
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.Location = new System.Drawing.Point(141, 88);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(88, 37);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ResultGroupBox
            // 
            this.ResultGroupBox.Controls.Add(this.countLabel);
            this.ResultGroupBox.Controls.Add(this.label6);
            this.ResultGroupBox.Controls.Add(this.label2);
            this.ResultGroupBox.Controls.Add(this.ageTextBox1);
            this.ResultGroupBox.Controls.Add(this.FilterButton);
            this.ResultGroupBox.Controls.Add(this.ClearButton);
            this.ResultGroupBox.Controls.Add(this.SortButton);
            this.ResultGroupBox.Controls.Add(this.ResultListBox);
            this.ResultGroupBox.Location = new System.Drawing.Point(11, 158);
            this.ResultGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.ResultGroupBox.Name = "ResultGroupBox";
            this.ResultGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.ResultGroupBox.Size = new System.Drawing.Size(641, 287);
            this.ResultGroupBox.TabIndex = 2;
            this.ResultGroupBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(505, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Возраст: ";
            // 
            // ageTextBox1
            // 
            this.ageTextBox1.Location = new System.Drawing.Point(566, 30);
            this.ageTextBox1.Name = "ageTextBox1";
            this.ageTextBox1.Size = new System.Drawing.Size(71, 20);
            this.ageTextBox1.TabIndex = 4;
            // 
            // FilterButton
            // 
            this.FilterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FilterButton.Location = new System.Drawing.Point(505, 55);
            this.FilterButton.Margin = new System.Windows.Forms.Padding(2);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(132, 22);
            this.FilterButton.TabIndex = 3;
            this.FilterButton.Text = "Фильтрация";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.Location = new System.Drawing.Point(505, 81);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(132, 21);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SortButton
            // 
            this.SortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SortButton.Location = new System.Drawing.Point(505, 106);
            this.SortButton.Margin = new System.Windows.Forms.Padding(2);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(132, 22);
            this.SortButton.TabIndex = 1;
            this.SortButton.Text = "Сортировать";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // ResultListBox
            // 
            this.ResultListBox.FormattingEnabled = true;
            this.ResultListBox.HorizontalScrollbar = true;
            this.ResultListBox.Location = new System.Drawing.Point(4, 30);
            this.ResultListBox.Margin = new System.Windows.Forms.Padding(2);
            this.ResultListBox.Name = "ResultListBox";
            this.ResultListBox.Size = new System.Drawing.Size(496, 251);
            this.ResultListBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Количество: ";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(83, 15);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 13);
            this.countLabel.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 456);
            this.Controls.Add(this.ResultGroupBox);
            this.Controls.Add(this.AddGroupBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(679, 495);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(679, 495);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Laba 16";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.AddGroupBox.ResumeLayout(false);
            this.AddGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AgeNumericUpDown)).EndInit();
            this.ResultGroupBox.ResumeLayout(false);
            this.ResultGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        static public string path = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(path);
        public List<string> saveFileNames = new List<string>();
        public List<Person> listPersons = new List<Person>();
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddElemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteElemToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox DeleteElemtoolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem DeleteButton;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bINToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox BinFileNameText;
        private System.Windows.Forms.ToolStripMenuItem SaveBinButton;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox JsonFileNameText;
        private System.Windows.Forms.ToolStripMenuItem SaveJsonButton;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox XmlFileNameText;
        private System.Windows.Forms.ToolStripMenuItem SaveXmlButton;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BinToolStripMenu;
        private System.Windows.Forms.ToolStripComboBox BinComboBox;
        private System.Windows.Forms.ToolStripMenuItem LoadBinButton;
        private System.Windows.Forms.ToolStripMenuItem XmlToolStripMenu;
        private System.Windows.Forms.ToolStripComboBox XmlComboBox;
        private System.Windows.Forms.ToolStripMenuItem LoadXmlButton;
        private System.Windows.Forms.ToolStripMenuItem JsonToolStripMenu;
        private System.Windows.Forms.ToolStripComboBox JsonComboBox;
        private System.Windows.Forms.ToolStripMenuItem LoadJsonButton;
        private System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox NameTextBoxTool;
        private System.Windows.Forms.ToolStripMenuItem NameSearchButton;
        private System.Windows.Forms.ToolStripMenuItem AgeSearchButton;
        private System.Windows.Forms.ToolStripTextBox AgeTextBoxTool;
        private System.Windows.Forms.ToolStripMenuItem SearchAgeToolStripMenuItem;
        private System.Windows.Forms.GroupBox AddGroupBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox ResultGroupBox;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.ListBox ResultListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.RichTextBox DescriptionRichTextBox;
        private System.Windows.Forms.NumericUpDown AgeNumericUpDown;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AllFileNameButton;
        private System.Windows.Forms.ToolStripMenuItem AddManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddRandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddRandButton;
        private System.Windows.Forms.ToolStripTextBox CountAddedRand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ageTextBox1;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label label6;
    }
}

