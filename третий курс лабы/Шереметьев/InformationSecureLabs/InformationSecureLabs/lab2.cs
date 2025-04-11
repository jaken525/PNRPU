using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace InformationSecureLabs
{
    public partial class lab2 : Form
    {
        private int cap = 24;

        private BigInteger p;
        private BigInteger q;
        private BigInteger n;
        private BigInteger valueE;
        private BigInteger d;
        private BigInteger phi;

        public lab2()
        {
            InitializeComponent();
        }

        private void buttonKeys_Click(object sender, EventArgs e)
        {
            // Генерация p и q
            p = GenerateRandomPrime(cap);
            q = GenerateRandomPrime(cap);
            n = p * q;

            // Вычисление функции Эйлера φ(n) = (p-1)*(q-1)
            phi = (p - 1) * (q - 1);

            // Выбор числа e: 1 < e < φ(n), НОД(e, φ(n)) = 1
            valueE = GeneratePublicExponent(phi);

            // Вычисление закрытого ключа d
            d = ModInverse(valueE, phi);

            // Вывод значений
            textBoxP.Text = p.ToString();
            textBoxQ.Text = q.ToString();
            textBoxN.Text = n.ToString();
            textBoxE.Text = valueE.ToString();
            textBoxD.Text = d.ToString();
        }

        // Генерация случайного простого числа с определенной разрядностью
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

        // Генерация открытого экспонента e
        private BigInteger GeneratePublicExponent(BigInteger phi)
        {
            Random rnd = new Random();
            while (true)
            {
                BigInteger e = RandomBigInteger(2, phi - 1, rnd);
                if (BigInteger.GreatestCommonDivisor(e, phi) == 1 && e > 0)
                    return e;
            }
        }

        // Вычисление обратного элемента (e * d) % φ(n) = 1
        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, t, q;
            BigInteger x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                q = a / m;
                t = m;
                m = a % m;
                a = t;
                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }

            if (x1 < 0)
                x1 += m0;

            return x1;
        }

        // Шифрование сообщения по блокам
        private List<BigInteger> EncryptMessage(string message, BigInteger e, BigInteger n)
        {
            List<BigInteger> encryptedBlocks = new List<BigInteger>();

            // Получаем байты сообщения в кодировке UTF-8
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            // Рассчитываем максимальный размер блока на основе модуля n
            int blockSize = (int)Math.Floor(Math.Log((double)n, 2) / 8);

            for (int i = 0; i < messageBytes.Length; i += blockSize)
            {
                // Определяем размер текущего блока — это либо полный blockSize, либо оставшаяся часть сообщения
                byte[] blockBytes = new byte[Math.Min(blockSize, messageBytes.Length - i)];
                Array.Copy(messageBytes, i, blockBytes, 0, blockBytes.Length);

                // Преобразуем блок байтов в число
                BigInteger blockInt = new BigInteger(blockBytes);

                // Шифруем блок, используя формулу RSA: C = M^e mod n
                BigInteger encryptedBlock = BigInteger.ModPow(blockInt, e, n);
                encryptedBlocks.Add(encryptedBlock);
            }

            return encryptedBlocks;
        }

        // Дешифрование сообщения по блокам
        private string DecryptMessage(List<BigInteger> encryptedBlocks, BigInteger d, BigInteger n)
        {
            List<byte> decryptedBytes = new List<byte>();

            foreach (BigInteger encryptedBlock in encryptedBlocks)
            {
                // Дешифруем блок, используя закрытый ключ (d, n) с формулой: M = C^d mod n
                BigInteger decryptedBlock = BigInteger.ModPow(encryptedBlock, d, n);

                // Преобразуем число обратно в байты
                byte[] blockBytes = decryptedBlock.ToByteArray();

                // Добавляем в список байт (TrimEnd для удаления лишних нулей)
                decryptedBytes.AddRange(blockBytes);
            }

            // Преобразуем байты обратно в строку (UTF-8)
            return Encoding.UTF8.GetString(decryptedBytes.ToArray()).TrimEnd('\0');
        }

        // Шифрование сообщения
        private void button1_Click(object sender, EventArgs e)
        {
            string plaintext = richTextBoxMsg.Text;
            List<BigInteger> encryptedMessage = EncryptMessage(plaintext, valueE, n);
            richTextBoxEncrypt.Text = string.Join(" ", encryptedMessage);

            FastDecrypt();
        }

        // Дешифрование сообщения
        private void FastDecrypt()
        {
            string[] encryptedBlocks = richTextBoxEncrypt.Text.Split(" ");
            List<BigInteger> encryptedMessage = new List<BigInteger>();

            foreach (var block in encryptedBlocks)
                encryptedMessage.Add(BigInteger.Parse(block));

            string decryptedMessage = DecryptMessage(encryptedMessage, d, n);
            richTextBoxDecrypt.Text = decryptedMessage;
        }
    }
}
