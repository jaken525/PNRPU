namespace VitalikTeamLibrary
{
    public class VitalikTeam
    {
        public static int ReadValue(string type = "")
        {
            bool isRead = false;
            int value = 0;

            do
            {
                Console.WriteLine($"Введите {type}: ");
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                    isRead = true;
                }
                catch
                {
                    Console.WriteLine("Неверное значение.\n");
                    isRead = false;
                }
            } while (!isRead);
            Console.WriteLine("");

            return value;
        }

        public static char ReadChar(string type = "")
        {
            bool isRead = false;
            char value = (char)0;

            do
            {
                Console.WriteLine($"Введите {type}: ");
                try
                {
                    value = Convert.ToChar(Console.ReadLine());
                    isRead = true;
                }
                catch
                {
                    Console.WriteLine("Неверное значение.\n");
                    isRead = false;
                }
            } while (!isRead);

            return value;
        }

        public static double ReadDouble(string type = "")
        {
            bool isRead = false;
            double value = 0;

            do
            {
                Console.WriteLine($"Введите {type}: ");
                try
                {
                    value = Convert.ToDouble(Console.ReadLine());
                    isRead = true;
                }
                catch
                {
                    Console.WriteLine("Неверное значение.\n");
                    isRead = false;
                }
            } while (!isRead);

            return value;
        }

        public static string ReadString(string type = "")
        {
            bool isRead = false;
            string value = "";

            do
            {
                Console.WriteLine($"Введите {type}: ");

                string temp = Console.ReadLine().ToString();

                if (temp != null)
                    value = temp;

                if (value != "")
                {
                    int k = 0;
                    for (int i = 0; i < value.Length; i++)
                        if (value[i] == ' ')
                            k++;

                    if (k == value.Length)
                    {
                        Console.WriteLine("Неверное значение.\n");
                        isRead = false;
                    }
                    else
                        isRead = true;
                }
                else
                {
                    Console.WriteLine("Неверное значение.\n");
                    isRead = false;
                }
            } while (!isRead);

            return value;
        }

        public static void PrintArray(int[] array)
        {
            Console.Write("Одномерный массив: ");
            for (int i = 0; i < array.Length; ++i)
                Console.Write(array[i] + " ");
            Console.WriteLine("\n");
        }

        public static void PrintArray(string[] array)
        {
            Console.Write("Одномерный массив: ");
            for (int i = 0; i < array.Length; ++i)
                Console.Write(array[i] + " ");
            Console.WriteLine("\n");
        }

        public static void PrintArray(int[,] array)
        {
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void PrintArray(char[,] array)
        {
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void PrintArray(int[][] array)
        {
            Console.WriteLine("Рваный массив:");
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                    Console.Write(array[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int[] WriteOneDimArray(int size)
        {
            int[] array = new int[size];

            for (int i = 0; i < array.Length; ++i)
                array[i] = VitalikTeam.ReadValue($"элемент {i + 1}");

            Console.WriteLine();
            return array;
        }

        public static int[,] WriteTwoDimArray(int row, int columns)
        {
            int[,] array = new int[row, columns];

            for (int i = 0; i < row; ++i)
                for (int j = 0; j < columns; ++j)
                    array[i, j] = VitalikTeam.ReadValue($"элемент {i + 1}, {j + 1}");

            Console.WriteLine();
            return array;
        }

        public static int[][] WriteJagArray(int row, bool isRandomWrite = true)
        {
            int[][] jagArray = new int[row][];

            for (int i = 0; i < row; i++)
            {
                int columns = VitalikTeam.ReadValue($"кол-во столбцов массива в строке {i + 1}");

                while (columns <= 0)
                {
                    Console.WriteLine("Неверно введены размеры массива.\n");
                    columns = VitalikTeam.ReadValue($"кол-во столбцов массива в строке {i + 1}");
                }

                jagArray[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                    if (isRandomWrite)
                        jagArray[i][j] = VitalikTeam.Random(-100, 100);
                    else
                        jagArray[i][j] = VitalikTeam.ReadValue($"элемент {i + 1}, {j + 1}");
            }

            Console.WriteLine();
            return jagArray;
        }

        public static double Factorial(double cof, ref double factorial)
        {
            if (cof < 1)
                return 1;
            else
                for (int i = 0; i < 2; i++)
                {
                    factorial *= cof;
                    --cof;
                }

            return factorial;
        }

        public static double Pow(int cof, double pow, ref double result)
        {
            if (cof < 1)
                return 1;
            else
                for (int i = 0; i < 2; i++)
                    result *= pow;

            return result;
        }

        public static double Sign(int cof)
        {
            if (cof % 2 == 0)
                return 1;
            else
                return -1;
        }

        private static Random random = new Random();

        public static int[] WriteRandomArray(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
                array[i] = random.Next(-100, 100);

            return array;
        }

        public static int[,] WriteRandomArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
                for (int j = 0; j < array.GetLength(1); ++j)
                    array[i, j] = random.Next(-100, 100);

            Console.WriteLine();
            return array;
        }

        public static int Random(int from, int to)
        {
            return random.Next(from, to);
        }

        public static char[,] WriteRandomArray(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
                for (int j = 0; j < array.GetLength(1); ++j)
                    array[i, j] = (char)random.Next(48, 122);

            Console.WriteLine();
            return array;
        }
    }
}