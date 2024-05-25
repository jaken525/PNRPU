using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinForm;
using WinForm.Saver;

namespace Laba16
{
    public class GetSaver : AbstractGetSaver<MainForm>
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        static public string path = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(path);
        public List<string> saveFileNames = new List<string>();
        private int counter = 0;

        MainForm mainForm;

        public GetSaver(MainForm main) : base(main)
        {
            mainForm = main;
        }


        private void ruleTextChange(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 95 && number != 32 && (number >= 91 || number <= 64) && (number >= 123 || number <= 96))
                e.Handled = true;
        }
        private EventHandler TextChanged(ToolStripButton toolStripButton)
        {
            return (x, y) =>
            {
                toolStripButton.Enabled = true;
            };
        }

        private void CreateToolStripTextBox(ToolStripTextBox toolStripTextBox, ToolStripButton toolStripButton)
        {
            toolStripTextBox.Name = "FileNameText" + counter;
            toolStripTextBox.Size = new System.Drawing.Size(100, 27);
            toolStripTextBox.Text = "Имя файла";

            toolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(ruleTextChange);
            toolStripTextBox.TextChanged += new System.EventHandler(TextChanged(toolStripButton));
        }

        private void Save(ToolStripTextBoxTextHolder NameFile, ISaver saver)
        {
            if (saveFileNames.Contains(NameFile.Value.ToString()) || File.Exists(Path.Combine(path, NameFile.Value.ToString() + ".bin")))
                MessageBox.Show("Файл с таким именем уже существует", "Error!");
            else
            {
                string fileName = NameFile.Value.ToString();
                saver.Save(fileName, mainForm.listPersons, path);

                MessageBox.Show($"BIN Файл успешно сохранен\nFile: {fileName}", "Save");

            }
        }
        private EventHandler SaveButton_Click(ToolStripButton toolStripButton, ToolStripTextBoxTextHolder toolStripTextBox, ISaver saver)
        {
            return (x, y) =>
            {
                Save(toolStripTextBox, saver);
                toolStripButton.Enabled = false;
            };
        }

        private void CreateToolStripButton(ToolStripButton toolStripButton, ToolStripTextBox toolStripTextBox, ISaver saver)
        {
            toolStripButton.Enabled = false;
            toolStripButton.Name = "SaveBinButton"+counter;
            toolStripButton.Size = new System.Drawing.Size(174, 26);
            toolStripButton.Text = "Сохранить";

            toolStripButton.Click += new System.EventHandler(SaveButton_Click(toolStripButton, new ToolStripTextBoxTextHolder(toolStripTextBox), saver));
        }

        private void CreateToolStripMenuItem(ToolStripMenuItem toolStripMenuItem, ToolStripButton toolStripButton, ToolStripTextBox toolStripTextBox, ISaver saver)
        {
            toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripTextBox,
            toolStripButton});
            toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bINToolStripMenuItem.Image")));
            toolStripMenuItem.Name = "SaveToolStripMenuItem" + counter;
            toolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            toolStripMenuItem.Text = saver.GetType().Name;
        }

        public override IEnumerable<ToolStripMenuItem> GetSavers()
        {
            List<ToolStripMenuItem> toolStripMenuItems = new List<ToolStripMenuItem>();
            Assembly assembly = Assembly.GetAssembly(typeof(ISaver));

            IEnumerable<ISaver> savers = from type in assembly.GetTypes()
                                         where type.GetInterfaces().Any(x => x.Equals(typeof(ISaver)))
                                         select (ISaver)assembly.CreateInstance(type.FullName);

            foreach(ISaver saver in savers)
            {
                counter++;

                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                ToolStripTextBox toolStripTextBox = new ToolStripTextBox();
                ToolStripButton toolStripButton = new ToolStripButton();

                CreateToolStripTextBox(toolStripTextBox, toolStripButton);
                CreateToolStripButton(toolStripButton, toolStripTextBox, saver);
                CreateToolStripMenuItem(toolStripMenuItem, toolStripButton, toolStripTextBox, saver);

                toolStripMenuItems.Add(toolStripMenuItem);
            }
            return toolStripMenuItems;
        }
    }
}
