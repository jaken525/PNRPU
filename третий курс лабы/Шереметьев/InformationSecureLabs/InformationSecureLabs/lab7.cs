using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecureLabs
{
    public partial class lab7 : Form
    {
        private const uint encryptionKey = 0xA1B2C3D4;

        public lab7()
        {
            InitializeComponent();
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // 128-битная соль
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(salt);

            return salt;
        }

        private byte[] MakeHash(string password, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combined = new byte[salt.Length + passwordBytes.Length];

       //     Buffer.BlockCopy(salt, 0, combined, 0, salt.Length);
           // Buffer.BlockCopy(passwordBytes, 0, combined, salt.Length, passwordBytes.Length);

            byte[] hash = Encrypt(passwordBytes);

            return hash;
        }

        private byte[] Encrypt(byte[] data)
        {
            byte[] encryptedBytes = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                ushort block = 0;
                if (i + 1 < data.Length)
                    block = BitConverter.ToUInt16(data, i);
                else
                    block = data[i];

                ushort encryptedBlock = (ushort)(block ^ (encryptionKey & 0xFFFF));

                byte[] encryptedBytesBlock = BitConverter.GetBytes(encryptedBlock);
                encryptedBytes[i] = encryptedBytesBlock[0];
                if (i + 1 < data.Length)
                    encryptedBytes[i + 1] = encryptedBytesBlock[1];
            }

            return encryptedBytes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;

            byte[] salt = GenerateSalt();
            byte[] hash = MakeHash(password, salt);

            richTextBox1.Text = Convert.ToBase64String(hash);
        }
    }
}
