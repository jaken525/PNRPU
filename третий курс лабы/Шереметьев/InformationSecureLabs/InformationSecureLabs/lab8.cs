using System.Text;

namespace InformationSecureLabs
{
    public partial class lab8 : Form
    {
        public lab8()
        {
            InitializeComponent();
        }

        private byte[] GenerateGamma(int length)
        {
            byte[] gamma = new byte[length];
            Random random = new Random();
            random.NextBytes(gamma);
            return gamma;
        }

        private byte[] Encrypt(byte[] data, byte[] gamma)
        {
            byte[] result = new byte[data.Length];
            int blockSize = 4;

            for (int i = 0; i < data.Length; i += blockSize)
                for (int j = 0; j < blockSize && (i + j) < data.Length; j++)
                    result[i + j] = (byte)(data[i + j] ^ gamma[i + j]);


            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plaintext = textBox1.Text;

            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            byte[] gamma = GenerateGamma(plaintextBytes.Length);
            byte[] encryptedMessage = Encrypt(plaintextBytes, gamma);

            richTextBox1.Text = Convert.ToBase64String(encryptedMessage);
        }
    }
}
