using System.Windows.Forms;

namespace Laba16
{
    public interface IObjectHolder<out T>
    {
        T Value { get; }
    }

    public class ToolStripComboBoxTextHolder: IObjectHolder<string> //Держатель текста в ComboBox
    {
        private ToolStripComboBox _comboBox;
        public ToolStripComboBoxTextHolder(ToolStripComboBox toolStripComboBox) 
        {
            _comboBox = toolStripComboBox;
        }

        public string Value { get => _comboBox.Text; }
            
    }

    public class ToolStripTextBoxTextHolder : IObjectHolder<string>
    {
        private ToolStripTextBox _textbox;
        public ToolStripTextBoxTextHolder(ToolStripTextBox toolStripTextBox)
        {
            _textbox = toolStripTextBox;
        }

        public string Value { get => _textbox.Text; }

    }
}
