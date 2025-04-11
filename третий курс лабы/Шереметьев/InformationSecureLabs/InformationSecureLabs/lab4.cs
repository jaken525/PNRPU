using System.Text;

namespace InformationSecureLabs
{
    public partial class lab4 : Form
    {
        uint encryptionKey = 0xD0F5B1A7;

        public lab4()
        {
            InitializeComponent();
        }

        void Encrypt(string outputFile)
        {
            byte[] fileBytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
            byte[] encryptedBytes = new byte[fileBytes.Length];

            for (int i = 0; i < fileBytes.Length; i += 2)
            {
                ushort block = 0;
                if (i + 1 < fileBytes.Length)
                    block = BitConverter.ToUInt16(fileBytes, i);
                else
                    block = fileBytes[i];

                ushort encryptedBlock = (ushort)(block ^ (encryptionKey & 0xFFFF));

                byte[] encryptedBytesBlock = BitConverter.GetBytes(encryptedBlock);
                encryptedBytes[i] = encryptedBytesBlock[0];
                if (i + 1 < fileBytes.Length)
                    encryptedBytes[i + 1] = encryptedBytesBlock[1];
            }

            richTextBox2.Text = Encoding.UTF8.GetString(encryptedBytes);
            File.WriteAllBytes(outputFile, encryptedBytes);
        }

        void Decrypt(string inputFile, string outputFile)
        {
            byte[] fileBytes = File.ReadAllBytes(inputFile);
            byte[] decryptedBytes = new byte[fileBytes.Length];

            for (int i = 0; i < fileBytes.Length; i += 2)
            {
                ushort block = 0;
                if (i + 1 < fileBytes.Length)
                    block = BitConverter.ToUInt16(fileBytes, i);
                else
                    block = fileBytes[i];

                ushort decryptedBlock = (ushort)(block ^ (encryptionKey & 0xFFFF));

                byte[] decryptedBytesBlock = BitConverter.GetBytes(decryptedBlock);
                decryptedBytes[i] = decryptedBytesBlock[0];
                if (i + 1 < fileBytes.Length)
                    decryptedBytes[i + 1] = decryptedBytesBlock[1];
            }

            richTextBox3.Text = Encoding.UTF8.GetString(decryptedBytes);
            File.WriteAllBytes(outputFile, decryptedBytes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string encryptedFile = "replay.dat";
            string decryptedFile = "decrypted.txt";

            Decrypt(encryptedFile, decryptedFile);
        }
    }
}
