using VitalikTeamLibrary;

namespace Laba6
{
    public class FirstTask
    {
        public char[,] array = null;

        private int[] GetCountOfNumbersArray(char[,] array)
        {
            int[] count = new int[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] >= 48 && array[i, j] <= 57)
                        count[i]++;

            return count;
        }

        private int GetCountOfNumbers(char[,] array)
        {
            int count = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] >= 48 && array[i, j] <= 57)
                    {
                        count++;
                        break;
                    }

            return count;
        }

        private char[,] DeleteAllStringsWithoutNumbers(char[,] array)
        {

            char[,] newArray = new char[GetCountOfNumbers(array), array.GetLength(1)];
            int[] count = GetCountOfNumbersArray(array);

            for (int i = 0, k = 0; i < array.GetLength(0); i++)
                if (count[i] != 0)
                {
                    for (int j = 0; j < newArray.GetLength(1); j++)
                        newArray[k, j] = array[i, j];
                    k++;
                }

            return newArray;
        }

        private char[,] DeletedStrings(char[,] array)
        {

            char[,] newArray = new char[array.GetLength(0) - GetCountOfNumbers(array), array.GetLength(1)];
            int[] count = GetCountOfNumbersArray(array);

            for (int i = 0, k = 0; i < array.GetLength(0); i++)
                if (count[i] == 0)
                {
                    for (int j = 0; j < newArray.GetLength(1); j++)
                        newArray[k, j] = array[i, j];
                    k++;
                }

            return newArray;
        }

        private void DeleteStringsWithoutNumbers(ref char[,] array)
        {
            if (array != null)
            {
                Console.Write("Изначальный ");
                VitalikTeam.PrintArray(array);

                char[,] deletedStringsArray = array;
                array = DeleteAllStringsWithoutNumbers(array);
                deletedStringsArray = DeletedStrings(deletedStringsArray);

                if (array.GetLength(0) != 0)
                {
                    Console.Write("Изменённый ");
                    VitalikTeam.PrintArray(array);

                    Console.Write("Удалённые строки ");

                    if (deletedStringsArray.GetLength(0) != 0)
                        VitalikTeam.PrintArray(deletedStringsArray);
                    else
                        Console.WriteLine("отсутствуют. Ни одна строка не была удалена.\n");
                }
                else
                    Console.WriteLine("Массив пуст. Все строки удалены.");
            }
            else
                Console.WriteLine("Массив пуст. Сначала заполните его.\n");
        }

        private void WriteArray(bool randomWrite)
        {
            int row = VitalikTeam.ReadValue("кол-во строк массива");
            int columns = VitalikTeam.ReadValue("кол-во столбцов массива");

            while (row <= 0 || columns <= 0)
            {
                Console.WriteLine("Неверно введены размеры массива.\n");

                row = VitalikTeam.ReadValue("кол-во строк массива");
                columns = VitalikTeam.ReadValue("кол-во столбцов массива");
            }

            array = new char[row, columns];

            if (randomWrite)
                array = VitalikTeam.WriteRandomArray(array);
            else
                for (int i = 0; i < row; i++)
                    for (int j = 0; j < columns; j++)
                        array[i, j] = VitalikTeam.ReadChar("символ");
        }

        public void CompleteTask(bool isRandomWrite, ref int choice)
        {
            Console.WriteLine(Program.mode[Convert.ToInt32(isRandomWrite)]);
            Program.PrintMenu(choice);
            int choiceInMode = VitalikTeam.ReadValue("");

            switch (choiceInMode)
            {
                case 1:
                    WriteArray(isRandomWrite);

                    Console.WriteLine("Массив заполнен!\n");
                    break;

                case 2:
                    {
                        if (array != null)
                            VitalikTeam.PrintArray(array);
                        else
                            Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    }
                    break;

                case 3:
                    DeleteStringsWithoutNumbers(ref array);
                    break;

                case 4:
                    choice = 0;
                    break;

                default:
                    Console.WriteLine("Выбрана несуществующая команда.\n");
                    break;
            }

        }

    }

    public class SecondTask
    {
        public string[] words = null;
        const string path = "C:\\Users\\Admin\\source\\repos\\Лаба 6\\Лаба 6\\words.txt";

        private void WriteWords(bool isRandomWrite)
        {
            if (!isRandomWrite)
                words = VitalikTeam.ReadString("строку").Split(" ");
            else
            {
                int arraySize = VitalikTeam.ReadValue("количество слов");

                while (arraySize <= 0)
                {
                    Console.WriteLine("Неверно введён размер массива.\n");
                    arraySize = VitalikTeam.ReadValue("количество слов");
                }

                words = new string[arraySize];

                int wordsCount = 0;
                StreamReader wordsFile = new StreamReader(path);
                while (wordsFile.ReadLine() != null)
                    wordsCount++;

                wordsFile.Dispose();
                wordsFile.Close();

                for (int i = 0; i < arraySize; i++)
                    words[i] = File.ReadLines(path).Skip(VitalikTeam.Random(0, wordsCount - 1)).First();
            }
        }

        public void CompleteTask(bool isRandomWrite, ref int choice)
        {
            Console.WriteLine(Program.mode[Convert.ToInt32(isRandomWrite)]);
            Program.PrintMenu(choice);
            int choiceInMode = VitalikTeam.ReadValue("");

            switch (choiceInMode)
            {
                case 1:
                    WriteWords(isRandomWrite);

                    Console.WriteLine("Массив заполнен!\n");
                    break;

                case 2:
                    if (words != null)
                        VitalikTeam.PrintArray(words);
                    else
                        Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    break;

                case 3:
                    if (words != null)
                    {
                        Array.Reverse(words);

                        Console.Write("Перевёрнутый ");
                        VitalikTeam.PrintArray(words);
                    }
                    else
                        Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    break;

                case 4:
                    if (words != null)
                    {
                        Array.Sort(words);
                        Array.Reverse(words);

                        Console.Write("Отсортированный по убыванию ");
                        VitalikTeam.PrintArray(words);
                    }
                    else
                        Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    break;

                case 5:
                    choice = 0;
                    break;

                default:
                    Console.WriteLine("Выбрана несуществующая команда.\n");
                    break;
            }

        }

    }

    public static class Program
    {
        public static readonly string[] mode = { "Режим РУЧНОГО заполнения", "Режим СЛУЧАЙНОГО заполнения" };
        static readonly string[] menus =
        {
            "[Меню]\n1. Работа с двумерным массивом \"char\".\n2. Работа со строкой и словами.\n3. Случайное заполнение.\n4. Выход.\n",
            "\n[Работа с двумерным массивом \"char\"]\n1. Создать массив.\n2. Отобразить массив.\n3. Удалить строки без цифр.\n4. Вернуться.",
            "\n[Работа со строкой и словами]\n1. Ввести строку со словами.\n2. Отобразить массив слов.\n3. Перевернуть массив слов.\n4. Отсортировать слова по убыванию.\n5. Вернуться."
        };

        public static void PrintMenu(int choice)
        {
            Console.WriteLine(menus[choice]);
        }

        static void Main(string[] args)
        {
            FirstTask firstTask = new FirstTask();
            SecondTask secondTask = new SecondTask();

            int choice = 0;

            bool isRandomWrite = true;

            while (true)
            {
                switch (choice)
                {
                    case 0:
                        PrintMenu(0);
                        choice = VitalikTeam.ReadValue("");

                        Console.Clear();
                        break;

                    case 1:
                        firstTask.CompleteTask(isRandomWrite, ref choice);
                        break;

                    case 2:
                        secondTask.CompleteTask(isRandomWrite, ref choice);
                        break;

                    case 3:
                        isRandomWrite = !isRandomWrite;

                        Console.WriteLine($"Случайное заполнение: {isRandomWrite}\n");
                        choice = 0;
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Выбрана несуществующая команда.\n");
                        choice = 0;
                        break;
                }

            }

        }

    }

}