using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinForm;
using WinForm.Loader;
using WinForm.Persons;

namespace Laba16
{
    public class GetLoader: AbstractGetLoader<MainForm>
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        static public string path = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(path);
        public List<string> saveFileNames = new List<string>();
        private int counter = 0;

        MainForm mainForm;

        public GetLoader(MainForm main) : base(main)
        {
            mainForm = main;
        }

        private EventHandler ComboBox_SelectedIdexChaged(ToolStripButton toolStripButton)
        {
            return (x, y) => 
            { 
                toolStripButton.Enabled = true;
            };
        }
        private EventHandler LoadFile(ILoader<List<Person>> loader, ToolStripComboBoxTextHolder filename, string path)
        {
            return (x, y) =>
            {
                mainForm.listPersons = loader.Load(filename.Value, path);

                MessageBox.Show($"Коллекция: {filename.Value} загружена", "INFO");
            };
        }
        private EventHandler CheckAllFiles(ToolStripComboBox toolStripComboBox, ILoader<List<Person>> loader)
        {
            return (x, y) =>
            {
                string extension = loader.Extension;
                
                saveFileNames.Clear();
                files = Directory.GetFiles(path);

                foreach (string file in files)
                    saveFileNames.Add(Path.GetFileName(file));

                toolStripComboBox.Items.Clear();

                foreach (string fileName in saveFileNames)
                    if (fileName.Contains("." + extension))
                        toolStripComboBox.Items.Add(fileName);

            };
        }

        private void CreateToolStripComboBox(ToolStripComboBox toolStripComboBox, ToolStripButton toolStripButton)
        {
            toolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripComboBox.Name = "ComboBox" + counter;
            toolStripComboBox.Size = new System.Drawing.Size(121, 28);

            toolStripComboBox.SelectedIndexChanged += new System.EventHandler(ComboBox_SelectedIdexChaged(toolStripButton));
        }
        private void CreateToolStripButton(ToolStripButton toolStripButton, ILoader<List<Person>> loader, ToolStripComboBox toolStripComboBox)
        {
            toolStripButton.Enabled = false;
            toolStripButton.Name = "LoadButton" + counter;
            toolStripButton.Size = new System.Drawing.Size(195, 26);
            toolStripButton.Text = "Загрузить";

            toolStripButton.Click += new System.EventHandler(LoadFile(loader,new ToolStripComboBoxTextHolder(toolStripComboBox), path));
        }
        private void CreateToolStripMenuItem(ToolStripMenuItem toolStripMenuItem, ToolStripComboBox toolStripComboBox, ToolStripButton toolStripButton, ILoader<List<Person>> loader)
        {
            toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                toolStripComboBox,
                toolStripButton});

            toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bINToolStripMenuItem.Image")));
            toolStripMenuItem.Name = "LoadToolStripMenuItem" + counter;
            toolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            toolStripMenuItem.Text = loader.GetType().Name;

            toolStripMenuItem.Click += new System.EventHandler(CheckAllFiles(toolStripComboBox, loader));
        }

        public override IEnumerable<ToolStripMenuItem> GetLoaders()
        {
            List<ToolStripMenuItem> toolStripMenuItems = new List<ToolStripMenuItem>();
            
            Assembly assembly = Assembly.GetAssembly(typeof(ILoader<List<Person>>));
            IEnumerable<ILoader<List<Person>>> loaders = from type in assembly.GetTypes()
                                                         where type.GetInterfaces().Any(x => x.Equals(typeof(ILoader<List<Person>>)))
                                                         select (ILoader<List<Person>>)assembly.CreateInstance(type.FullName);
            
            foreach (var loader in loaders)
            {
                counter++;
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                ToolStripComboBox toolStripComboBox = new ToolStripComboBox();
                ToolStripButton toolStripButton = new ToolStripButton();
                
                CreateToolStripComboBox(toolStripComboBox, toolStripButton);
                CreateToolStripButton(toolStripButton, loader, toolStripComboBox);
                CreateToolStripMenuItem(toolStripMenuItem, toolStripComboBox, toolStripButton, loader);
                toolStripMenuItems.Add(toolStripMenuItem);
            }
            return toolStripMenuItems;
        }
    }
}
