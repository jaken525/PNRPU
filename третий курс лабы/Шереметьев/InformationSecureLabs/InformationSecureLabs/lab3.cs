using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace InformationSecureLabs
{
    public partial class lab3 : Form
    {
        private int cap = 64;

        private BigInteger p;
        private BigInteger g;
        private BigInteger x;
        private BigInteger y;
        private BigInteger A;
        private BigInteger B;
        private BigInteger Kx;
        private BigInteger Ky;

        public lab3()
        {
            InitializeComponent();
        }

        private BigInteger GenerateRandomPrime(int bits)
        {
            // Используем криптографически стойкий генератор случайных чисел
            using (var rng = new RNGCryptoServiceProvider())
                while (true)
                {
                    byte[] bytes = new byte[bits / 8];
                    rng.GetBytes(bytes);
                    BigInteger candidate = new BigInteger(bytes);

                    // Преобразование числа в положительное
                    candidate = BigInteger.Abs(candidate);

                    if (IsProbablePrime(candidate))
                        return candidate;
                }
        }

        // Проверка числа на простоту
        private bool IsProbablePrime(BigInteger number, int certainty = 10)
        {
            if (number < 2)
                return false;

            if (number == 2 || number == 3)
                return true;

            if (number % 2 == 0)
                return false;

            BigInteger d = number - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            Random rng = new Random();
            for (int i = 0; i < certainty; i++)
            {
                BigInteger a = RandomBigInteger(2, number - 2, rng);
                BigInteger x = BigInteger.ModPow(a, d, number);
                if (x == 1 || x == number - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, number);
                    if (x == 1)
                        return false;
                    if (x == number - 1)
                        break;
                }

                if (x != number - 1)
                    return false;
            }
            return true;
        }

        private BigInteger RandomBigInteger(BigInteger minValue, BigInteger maxValue, Random rng)
        {
            byte[] bytes = new byte[maxValue.ToByteArray().Length];
            rng.NextBytes(bytes);
            return new BigInteger(bytes) % (maxValue - minValue) + minValue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p = GenerateRandomPrime(cap);
            g = GenerateRandomPrime(cap);

            x = GenerateRandomPrime(cap);
            y = GenerateRandomPrime(cap);

            A = BigInteger.ModPow(g, x, p);
            B = BigInteger.ModPow(g, y, p);

            Kx = BigInteger.ModPow(B, x, p);
            Ky = BigInteger.ModPow(A, y, p);

            textBox1.Text = p.ToString();
            textBox2.Text = g.ToString();
            textBox3.Text = x.ToString();
            textBox4.Text = y.ToString();
            textBox5.Text = A.ToString();
            textBox6.Text = B.ToString();
            textBox7.Text = Kx.ToString();
            textBox8.Text = Ky.ToString();
        }

        private void GenerateKeys()
        {
            p = Convert.ToInt32(textBox1.Text);
            g = Convert.ToInt32(textBox2.Text);

            x = Convert.ToInt32(textBox3.Text);
            y = Convert.ToInt32(textBox4.Text);

            A = BigInteger.ModPow(g, x, p);
            B = BigInteger.ModPow(g, y, p);

            Kx = BigInteger.ModPow(B, x, p);
            Ky = BigInteger.ModPow(A, y, p);

            textBox5.Text = A.ToString();
            textBox6.Text = B.ToString();
            textBox7.Text = Kx.ToString();
            textBox8.Text = Ky.ToString();
        }

        private void Encrypt(double key)
        {
            byte[] fileBytes = Encoding.UTF8.GetBytes(richTextBox1.Text);
            byte[] encryptedBytes = new byte[fileBytes.Length];

            for (int i = 0; i < fileBytes.Length; i++)
                encryptedBytes[i] = (byte)(fileBytes[i] ^ (byte)(key * 1000) % 256);

            richTextBox2.Text = Encoding.UTF8.GetString(encryptedBytes);
            File.WriteAllBytes("crypted.txt", encryptedBytes);
        }

        private void Decrypt(double key)
        {
            byte[] fileBytes = File.ReadAllBytes("crypted.txt");
            byte[] decryptedBytes = new byte[fileBytes.Length];

            for (int i = 0; i < fileBytes.Length; i++)
                decryptedBytes[i] = (byte)(fileBytes[i] ^ (byte)(key * 1000) % 256);

            richTextBox3.Text = Encoding.UTF8.GetString(decryptedBytes);
            File.WriteAllBytes("decrypted.txt", decryptedBytes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Сообщение не может быть пустым");
                return;
            }

            if (textBox5.Text == "")
                GenerateKeys();

            double encryptionKey = Math.Tan((double)(Ky % int.MaxValue));
            double dencryptionKey = Math.Tan((double)(Kx % int.MaxValue));

            Encrypt(encryptionKey);
            Decrypt(dencryptionKey);
        }
    }
}
