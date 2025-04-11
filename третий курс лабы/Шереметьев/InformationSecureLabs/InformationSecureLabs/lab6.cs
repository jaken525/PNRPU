using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace InformationSecureLabs
{
    public partial class lab6 : Form
    {
        public lab6()
        {
            InitializeComponent();
        }

        private string path = "";

        public byte[] CompressRLE(byte[] input)
        {
            using (MemoryStream compressedStream = new MemoryStream())
            {
                for (int i = 0; i < input.Length; i++)
                {
                    byte currentByte = input[i];
                    int runLength = 1;

                    while (i + 1 < input.Length && input[i + 1] == currentByte && runLength < 255)
                    {
                        runLength++;
                        i++;
                    }

                    // Записываем количество повторов и сам символ
                    compressedStream.WriteByte((byte)runLength);
                    compressedStream.WriteByte(currentByte);
                }
                return compressedStream.ToArray();
            }
        }

        public List<int> CompressLZW(byte[] input)
        {
            // Инициализация словаря для ASCII символов
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < 256; i++)
            {
                dictionary.Add(((char)i).ToString(), i);
            }

            string currentStr = "";
            List<int> compressed = new List<int>();
            int dictSize = 256;

            foreach (byte b in input)
            {
                char currentChar = (char)b;
                string newStr = currentStr + currentChar;

                // Если комбинация уже в словаре, продолжаем
                if (dictionary.ContainsKey(newStr))
                {
                    currentStr = newStr;
                }
                else
                {
                    // Сохраняем индекс из словаря и добавляем новую комбинацию
                    compressed.Add(dictionary[currentStr]);
                    dictionary[newStr] = dictSize++;
                    currentStr = currentChar.ToString();
                }
            }

            // Записываем оставшийся символ
            if (!string.IsNullOrEmpty(currentStr))
            {
                compressed.Add(dictionary[currentStr]);
            }

            return compressed;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (path == "")
                return;

            byte[] inputText = File.ReadAllBytes(path);
            richTextBox1.Text = Encoding.UTF8.GetString(inputText);

            var rleCompressed = CompressRLE(inputText);
            var lzwCompressed = CompressLZW(rleCompressed);

            
            using (BinaryWriter writer = new BinaryWriter(File.Open(path + "compressed", FileMode.Create)))
                foreach (int c in lzwCompressed)
                    writer.Write((ushort)c);

            byte[] comressedFile = File.ReadAllBytes(path + "compressed");
            string compressed = "";
            foreach (int c in comressedFile)
                compressed += $"\\{c}";
            richTextBox2.Text = compressed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                textBox1.Text = path;
            }
            else
                MessageBox.Show("Файл не был выбран.");

        }
    }
}
