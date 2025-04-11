using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecureLabs
{
    public partial class lab5 : Form
    {
        public lab5()
        {
            InitializeComponent();
        }

        private const ushort polynom = 0x8005;
        private const ushort initCRC = 0x0;
        private ushort calculatedCRC;
        private byte[] messageWithCRC;

        private ushort ComputeCRC16(byte[] data)
        {
            ushort crc = initCRC;

            foreach (byte b in data)
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                    if ((crc & 0x8000) != 0)
                        crc = (ushort)((crc << 1) ^ polynom);
                    else
                        crc <<= 1;
            }

            return crc;
        }

        private byte[] AppendCRC(byte[] data)
        {
            ushort crc = ComputeCRC16(data);
            byte[] result = new byte[data.Length + 2];

            Array.Copy(data, result, data.Length);

            result[result.Length - 2] = (byte)(crc >> 8);
            result[result.Length - 1] = (byte)(crc & 0xFF);

            return result;
        }

        private bool CheckCRC(byte[] dataWithCRC)
        {
            if (dataWithCRC.Length < 2)
                return false;

            byte[] data = new byte[dataWithCRC.Length - 2];
            Array.Copy(dataWithCRC, data, data.Length);
            ushort receivedCRC = (ushort)((dataWithCRC[dataWithCRC.Length - 2] << 8) |
                                          dataWithCRC[dataWithCRC.Length - 1]);

            calculatedCRC = ComputeCRC16(data);

            return receivedCRC == calculatedCRC;
        }

        private bool CheckButtonCRC(byte[] dataWithCRC)
        {
            if (textBox1.Text == "" && richTextBox2.Text == "")
            {
                MessageBox.Show("Сообщение не может быть пустым");
                return false;
            }

            if (dataWithCRC.Length < 2)
                return false;

            byte[] data = new byte[dataWithCRC.Length - 2];
            Array.Copy(dataWithCRC, data, data.Length);
            ushort receivedCRC = (ushort)((dataWithCRC[dataWithCRC.Length - 2] << 8) |
                                          dataWithCRC[dataWithCRC.Length - 1]);

            return receivedCRC == ushort.Parse(BinaryStringToHexString(textBox1.Text));
        }

        private string HexToBinary(string hex)
        {
            int decimalValue = Convert.ToInt32(hex, 16);
            string binaryValue = Convert.ToString(decimalValue, 2);

            return binaryValue;
        }

        public static string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Сообщение не может быть пустым");
                return;
            }

            richTextBox2.Text = "";
            byte[] message = Encoding.ASCII.GetBytes(richTextBox1.Text);

            messageWithCRC = AppendCRC(message);
            foreach (byte b in messageWithCRC)
                richTextBox2.Text += $"{HexToBinary(b.ToString())}";

            label4.Text = CheckCRC(messageWithCRC).ToString();
            textBox1.Text = $"{HexToBinary(calculatedCRC.ToString())}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (messageWithCRC == null)
                return;

            label4.Text = CheckButtonCRC(messageWithCRC).ToString();
        }
    }
}
