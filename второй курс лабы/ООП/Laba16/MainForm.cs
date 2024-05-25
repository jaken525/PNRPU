using System;
using System.Linq;
using System.Windows.Forms;
using WinForm.Persons;
using System.IO;
using WinForm.Saver;
using WinForm.Loader;
using Laba16;
using System.Collections.Generic;

namespace WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckAllFiles();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            SolidGo(this);
        }
        private void SolidGo(MainForm form)
        {
            GetLoader getLoader = new GetLoader(form);
            GetSaver getSaver = new GetSaver(form);

            LoadToolStripMenuItem.DropDownItems.Clear();
            LoadToolStripMenuItem.DropDownItems.Add(AllFileNameButton);
            SaveToolStripMenuItem.DropDownItems.Clear();

            foreach (ToolStripMenuItem item in getLoader.GetLoaders())
                LoadToolStripMenuItem.DropDownItems.Add(item);

            foreach (ToolStripMenuItem item in getSaver.GetSavers())
                SaveToolStripMenuItem.DropDownItems.Add(item);
        }

        #region ruleTextChanged
        private void ruleNumberChanged(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
                e.Handled = true;
        }

        private void ruleTextChanged(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 95 && number != 32 && (number >= 91 || number <= 64) && (number >= 123 || number <= 96))
                e.Handled = true;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ruleNumberChanged(sender, e);
        }

        private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            ruleTextChanged(sender, e);
            SaveBinButton.Enabled = true;
        }
        #endregion

        #region Tools
        private void AddManual_Click(object sender, EventArgs e)
        {
            AddGroupBox.Enabled = true;
        }

        private void CountAddedRand_TextChange(object sender, EventArgs e)
        {
            if (CountAddedRand.Text == "" || CountAddedRand.Text == "0" || CountAddedRand.Text == "00" || CountAddedRand.Text == "000")
            {
                AddRandButton.Enabled = false;
                MessageBox.Show("The value cannot be zero or empty", "Error!");
            }
            else
            {
                AddRandButton.Enabled = true;
            }
        }
        private void ClearTextAddedPerson()
        {
            NameTextBox.Clear();
            DescriptionRichTextBox.Clear();
            AgeNumericUpDown.Value = 1;
            AddGroupBox.Visible = false;
        }
        private void AddButton_Click(object sender, EventArgs e) // Add
        {
            Person person = new Person(NameTextBox.Text, (int)AgeNumericUpDown.Value, DescriptionRichTextBox.Text);
            listPersons.Add(person);
            ClearTextAddedPerson();
            MessageBox.Show("Элемент успешно добавлен", "Успех");
        }

        private void PrintButton_Click(object sender, EventArgs e) //Print
        {
            ResultListBox.Items.Clear();

            if (listPersons.Count == 0)
                MessageBox.Show("Коллекция пуста", "Error!");
            else
            {
                foreach (Person person in listPersons)
                    ResultListBox.Items.Add(person);

                countLabel.Text = listPersons.Count.ToString();
            }
        }

        private void AddRandom_Click(object sender, EventArgs e) //Add Random
        {
            for (int i = 0; i < Convert.ToInt32(CountAddedRand.TextBox.Text); ++i)
            {
                listPersons.Add(new Person(Randomizer.random));
            }
            MessageBox.Show($"{Convert.ToInt32(CountAddedRand.TextBox.Text)} элементов было добавлено", "Успех!");
            CountAddedRand.TextBox.Text = "1";
        }

        private void ClearButton_Click(object sender, EventArgs e) // Clear listbox1
        {
            ResultListBox.Items.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteElemtoolStripComboBox.Items.Clear();
            foreach (Person person in listPersons)
                DeleteElemtoolStripComboBox.Items.Add(person);
        }

        private void DeleteComboBox_TextChange(object sender, EventArgs e)
        {
            if (DeleteElemtoolStripComboBox.Text == "")
                DeleteButton.Enabled = false;
            else
                DeleteButton.Enabled = true;
        }

        private void SortButton_Click(object sender, EventArgs e) // Sort
        {
            ResultListBox.Items.Clear();
            listPersons.Sort();
            foreach (Person person in listPersons)
            {
                ResultListBox.Items.Add(person);

                countLabel.Text = listPersons.Count.ToString();
            }
        }

        private void ClearCollectButton_Click(object sender, EventArgs e) //Clear Collect
        {
            MessageBox.Show("Коллекция очищена", "INFO");
            listPersons.Clear();
            ResultListBox.Items.Clear();
            DeleteElemtoolStripComboBox.Items.Clear();
        }
        #endregion

        #region Search

        private void Search(ToolStripTextBox toolStripTextBox, ListBox ResultListBox)
        {
            ResultListBox.Items.Clear();

            bool isAdded = false;
            string result = string.Empty;

            if (toolStripTextBox.Text == string.Empty)
                MessageBox.Show("Введите значение", "Error!");
            else
            {
                if (toolStripTextBox.Name == "NameTextBoxTool")
                {
                    foreach (Person p in listPersons)
                        if (p.fullName == toolStripTextBox.Text)
                        {
                            isAdded = true;
                            result += $"{p}\n";
                        }
                }
                else if (toolStripTextBox.Name == "AgeTextBoxTool")
                {
                    foreach (Person p in listPersons)
                        if (p.Age == Convert.ToInt32(toolStripTextBox.Text))
                        {
                            isAdded = true;
                            result += $"{p}\n";
                        }
                }

                if (isAdded)
                {
                    ResultListBox.Items.Add(result);
                    MessageBox.Show("Элемент найден", "Успех!");
                }      
                else
                    MessageBox.Show("Элемент не найден", "INFO");
            }
            
        }

        private void SearchNameButton_Click(object sender, EventArgs e) //Search Name
        {
            Search(NameTextBoxTool,ResultListBox);
        }

        private void SearchAgeButton_Click(object sender, EventArgs e) //Search Age
        {
            Search(AgeTextBoxTool, ResultListBox);
        }
        #endregion

        #region SaveFiles
        private void BINSave(ToolStripTextBox NameFile)
        {
            if(saveFileNames.Contains(NameFile.Text) || File.Exists(Path.Combine(path,NameFile.Text + ".bin")))
                MessageBox.Show("Файл с таким именем уже существует", "Error!");
            else
            {
                BinarySaver binarySaver = new BinarySaver();
                string fileName = NameFile.Text;
                binarySaver.Save(fileName, listPersons, path);

                MessageBox.Show($"BIN Файл успешно сохранен\nFile: {fileName}", "Save");
                
            }
        }

        private void XMLSave(ToolStripTextBox NameFile)
        {
            if (saveFileNames.Contains(NameFile.Text) || File.Exists(Path.Combine(path, NameFile.Text + ".xml")))
                MessageBox.Show("Файл с таким именем уже существует", "Error!");
            else
            {
                XMLSaver binarySaver = new XMLSaver();
                string fileName = NameFile.Text;
                binarySaver.Save(fileName, listPersons, path);
                MessageBox.Show($"XML Файл успешно сохранен\nFile: {fileName}", "Save");
            }
            
        }

        private void JSONSave(ToolStripTextBox NameFile)
        {
            if (saveFileNames.Contains(NameFile.Text) || File.Exists(Path.Combine(path, NameFile.Text + ".json")))
                MessageBox.Show("Файл с таким именем уже существует", "Error!");
            else
            {
                JSONSaver binarySaver = new JSONSaver();
                string fileName = NameFile.Text;
                binarySaver.Save(fileName, listPersons, path);
                MessageBox.Show($"JSON Файл успешно сохранен\nFile: {fileName}", "Save");
            }
        }

        private void SaveBinButton_Click(object sender, EventArgs e) //Save BIN
        {
            BINSave(BinFileNameText);
            SaveBinButton.Enabled = false;
        }

        private void SaveXmlButton_Click(object sender, EventArgs e) //Save XML
        {
            XMLSave(XmlFileNameText);
            SaveXmlButton.Enabled = false;
        }

        private void SaveJsonButton_Click(object sender, EventArgs e) //Save JSON
        {
            JSONSave(JsonFileNameText);
            SaveJsonButton.Enabled = false;
        }

        private void CheckSaveFilesButton_Click(object sender, EventArgs e)
        {
            ResultListBox.Items.Clear();
            ShowFilesSave();
        }

        #endregion

        #region Loader
        private void BinListLoad(object sender, EventArgs e) //BIN LIST LOAD
        {
            BinComboBox.Items.Clear();
            foreach (string fileName in saveFileNames)
                if(fileName.Contains(".bin"))
                    BinComboBox.Items.Add(fileName);
        }

        private void XmlListLoad(object sender, EventArgs e) //XML LIST LOAD
        {
            XmlComboBox.Items.Clear();
            foreach (string fileName in saveFileNames)
                if (fileName.Contains(".xml"))
                    XmlComboBox.Items.Add(fileName);
        }

        private void JsonListLoad(object sender, EventArgs e) //JSON LIST LOAD
        {
            JsonComboBox.Items.Clear();
            foreach (string fileName in saveFileNames)
                if (fileName.Contains(".json"))
                    JsonComboBox.Items.Add(fileName);
        }

        private void BinComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBinButton.Enabled = true;
        }

        private void XmlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadXmlButton.Enabled = true;
        }

        private void JsonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJsonButton.Enabled = true;
        }

        private void LoadBinFile(object sender, EventArgs e) // Load BIN file
        {
            if (saveFileNames.Contains(BinComboBox.Text))
            {
                BinaryLoader binaryLoader = new BinaryLoader();
                listPersons = binaryLoader.Load(BinComboBox.Text, path);
                MessageBox.Show($"Коллекция: {BinComboBox.Text} загружена", "INFO");
            }
        }

        private void LoadXmlFile(object sender, EventArgs e) // Load XML file
        {
            if (saveFileNames.Contains(XmlComboBox.Text))
            {
                XMLLoader xmlLoader = new XMLLoader();
                listPersons = xmlLoader.Load(XmlComboBox.Text, path);
                MessageBox.Show($"Коллекция: {XmlComboBox.Text} загружена", "INFO");
            }
        }

        private void LoadJsonFile(object sender, EventArgs e) // Load JSON file
        {
            if (saveFileNames.Contains(JsonComboBox.Text))
            {
                JSONLoader jsonLoader = new JSONLoader();
                listPersons = jsonLoader.Load(JsonComboBox.Text, path);
                MessageBox.Show($"Коллекция: {JsonComboBox.Text} загружена", "INFO");
            }
        }
        #endregion

        private void ShowFilesSave()
        {
            bool isFileFind = false;
            if (files.Count() != 0)
                isFileFind = true;
            else
                isFileFind = false;


            if (isFileFind)
                foreach (string name in saveFileNames)
                    ResultListBox.Items.Add(name);
            else
                MessageBox.Show("Файлы не найдены", "INFO");
        }
        private void CheckAllFiles()
        {
            saveFileNames.Clear();
            files = Directory.GetFiles(path);

            foreach (string file in files)
                saveFileNames.Add(Path.GetFileName(file));
        }
        private void CheckAllFilesButton_Click(object sender, EventArgs e)
        {
            CheckAllFiles();
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            foreach (Person person in listPersons)
            {
                if (person == DeleteElemtoolStripComboBox.SelectedItem)
                {
                    listPersons.Remove(person);
                    MessageBox.Show($"Элемент с именем: {DeleteElemtoolStripComboBox.Text} удалён", "Успех!");
                    DeleteElemtoolStripComboBox.Items.Remove(person);
                    break;
                }
            }
            DeleteButton.Enabled = false;
            DeleteElemtoolStripComboBox.Items.Clear();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            List<Person> filteredPersons = new List<Person>();
            try
            {
                if (ageTextBox1.Text != "")
                {
                    int age = Convert.ToInt32(ageTextBox1.Text);

                    filteredPersons = listPersons.Where(p => p.Age >= age).ToList();
                    ResultListBox.Items.Clear();

                    foreach(Person person in filteredPersons) 
                        ResultListBox.Items.Add(person);

                    countLabel.Text = filteredPersons.Count.ToString();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            };

        }

    }

}
