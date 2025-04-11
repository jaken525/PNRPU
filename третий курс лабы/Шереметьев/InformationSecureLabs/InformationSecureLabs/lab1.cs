using System.Threading;

namespace InformationSecureLabs
{
    public partial class lab1 : Form
    {
        private char[,] array;
        private const int arraySize = 6;

        public lab1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                StartProcess();
            else
                MessageBox.Show("Строка не должна быть пустой!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void StartProcess()
        {
            foreach (char c in textBox1.Text)
                if (c < 1040 || c > 1071 || c == 95)
                {
                    MessageBox.Show("Строка должна иметь только заглавные буквы русского алфавита!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            GenerateGrids();
            textBox2.Text = EncryptString(textBox1.Text);
        }

        private void GenerateGrids()
        {
            Random rand = new Random();

            tableLayoutPanel1.Controls.Clear();
            List<char> ruChars = new List<char>();

            for (int i = 1040; i <= 1071; i++)
                ruChars.Add((char)i);

            array = new char[arraySize, arraySize];

            for (int i = 0; i < arraySize; i++)
                for (int j = 0; j < arraySize; j++)
                    if (ruChars.Count > 0)
                    {
                        int random = rand.Next(0, ruChars.Count);
                        array[i, j] = ruChars[random];
                        ruChars.RemoveAt(random);
                    }
                    else if (ruChars.Count == 0)
                        array[i, j] = '_';

            for (int i = 0; i < arraySize; i++)
                for (int j = 0; j < arraySize; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Multiline = true;
                    textBox.Dock = DockStyle.Fill;

                    textBox.Text = array[i, j].ToString();
                    tableLayoutPanel1.Controls.Add(textBox, j, i);
                }

        }

        private string EncryptString(string text)
        {
            string newText = "";

            foreach (char c in text)
                for (int i = 0; i < arraySize; i++)
                    for (int j = 0; j < arraySize; j++)
                        if (array[i, j] == c)
                            if (i == arraySize - 1)
                                newText += array[0, j];
                            else
                                newText += array[i + 1, j];

            return newText;
        }
    }
}
