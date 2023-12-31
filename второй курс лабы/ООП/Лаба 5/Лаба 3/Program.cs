// Вариант 23
//
// Данные:
// Удалить все элементы с четными индексами
// Добавить К столбцов, начиная со столбца с номером N
// Добавить строку с заданным номером


using VitalikTeamLibrary;

namespace Laba5
{
    public class FirstExercise
    {
        public int[] oneDimArray = null;

        public int[] DeleteEvenIndexes(int[] array)
        {
            int size = array.Length;

            if (size % 2 != 0)
                size = (size + 1) / 2;
            else
                size /= 2;

            int[] newArray = new int[size];
            for (int i = 0, j = 0; j < size; i += 2, j++)
                newArray[j] = array[i];

            return newArray;
        }

        public void PrintMenu()
        {
            Console.WriteLine("[Работа с одномерными массивами]");
            Console.WriteLine("1. Создать массив.");
            Console.WriteLine("2. Отобразить массив.");
            Console.WriteLine("3. Удалить все элементы с четными индексами.");
            Console.WriteLine("4. Вернуться.");
        }

        public void CompleteTask(bool randomWrite, ref int choice)
        {
            PrintMenu();
            int choiceInMode = VitalikTeam.ReadValue("");

            switch (choiceInMode)
            {
                case 1:
                    {
                        int arraySize = VitalikTeam.ReadValue("размер одномерного массива");

                        while (arraySize <= 0)
                        {
                            Console.WriteLine("Неверно введён размер массива.\n");
                            arraySize = VitalikTeam.ReadValue("размер массива");
                        }

                        oneDimArray = new int[arraySize];

                        if (randomWrite)
                            oneDimArray = VitalikTeam.WriteRandomArray(oneDimArray);
                        else
                            oneDimArray = VitalikTeam.WriteOneDimArray(arraySize);
                    }
                    break;

                case 2:
                    {
                        if (oneDimArray != null)
                            VitalikTeam.PrintArray(oneDimArray);
                        else
                            Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    }
                    break;

                case 3:
                    {
                        if (oneDimArray != null)
                        {
                            VitalikTeam.PrintArray(oneDimArray);
                            oneDimArray = DeleteEvenIndexes(oneDimArray);
                            VitalikTeam.PrintArray(oneDimArray);
                        }
                        else
                            Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    }
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

    public class SecondExercise
    {
        public int[,] twoDimArray = null;

        public int[,] AddColumns(int[,] array, int countOfAddColumns, int columnNumber)
        {
            while (countOfAddColumns <= 0)
            {
                Console.WriteLine("Неверное значение.");
                countOfAddColumns = VitalikTeam.ReadValue("кол-во столбцов массива");
            }

            while (columnNumber <= 0 || columnNumber > array.GetLength(1))
            {
                Console.WriteLine("Неверное значение.");
                columnNumber = VitalikTeam.ReadValue("номер столбца");
            }

            int[,] newArray = new int[array.GetLength(0), array.GetLength(1) + countOfAddColumns];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < columnNumber - 1; j++)
                    newArray[i, j] = array[i, j];

                for (int j = columnNumber - 1; j < columnNumber + countOfAddColumns - 1; j++)
                    newArray[i, j] = VitalikTeam.Random(-100, 100);

                for (int j = columnNumber + countOfAddColumns - 1, k = columnNumber - 1; j < newArray.GetLength(1); j++, k++)
                    newArray[i, j] = array[i, k];
            }

            return newArray;
        }

        public void PrintMenu()
        {
            Console.WriteLine("[Работа с двумерными массивами]");
            Console.WriteLine("1. Создать массив.");
            Console.WriteLine("2. Отобразить массив.");
            Console.WriteLine("3. Добавить К столбцов, начиная со столбца с номером N.");
            Console.WriteLine("4. Вернуться.");
        }

        public void CompleteTask(bool randomWrite, ref int choice)
        {
            PrintMenu();
            int choiceInMode = VitalikTeam.ReadValue("");

            switch (choiceInMode)
            {
                case 1:
                    {
                        int row = VitalikTeam.ReadValue("кол-во строк двумерного массива");
                        int columns = VitalikTeam.ReadValue("кол-во столбцов двумерного массива");

                        while (row <= 0 || columns <= 0)
                        {
                            Console.WriteLine("Неверно введены размеры массива.\n");

                            row = VitalikTeam.ReadValue("кол-во строк двумерного массива");
                            columns = VitalikTeam.ReadValue("кол-во столбцов двумерного массива");
                        }

                        twoDimArray = new int[row, columns];

                        if (randomWrite)
                            twoDimArray = VitalikTeam.WriteRandomArray(twoDimArray);
                        else
                            twoDimArray = VitalikTeam.WriteTwoDimArray(row, columns);
                    }
                    break;

                case 2:
                    {
                        if (twoDimArray != null)
                            VitalikTeam.PrintArray(twoDimArray);
                        else
                            Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    }
                    break;

                case 3:
                    {
                        if (twoDimArray != null)
                        {
                            VitalikTeam.PrintArray(twoDimArray);
                            twoDimArray = AddColumns(twoDimArray, VitalikTeam.ReadValue("кол-во добавляемых столбцов"), VitalikTeam.ReadValue("номер столбца"));
                            VitalikTeam.PrintArray(twoDimArray);
                        }
                        else
                            Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    }
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

    public class ThirdExercise
    {
        public int[][] jagArray = null;

        public int[][] AddRowToJag(int[][] array, int rowNumber)
        {
            while (rowNumber <= 0 || array.GetLength(0) < rowNumber)
            {
                Console.WriteLine("Неверное значение.");
                rowNumber = VitalikTeam.ReadValue("номер строки");
            }

            rowNumber--;

            int[][] newArray = new int[array.GetLength(0) + 1][];

            for (int i = 0; i < rowNumber; i++)
            {
                newArray[i] = new int[array[i].Length];
                for (int j = 0; j < array[i].Length; j++)
                    newArray[i][j] = array[i][j];
            }

            int newLength = VitalikTeam.ReadValue("кол-во элементов");
            newArray[rowNumber] = new int[newLength];
            for (int j = 0; j < newLength; j++)
                newArray[rowNumber][j] = VitalikTeam.Random(-100, 100);

            for (int i = rowNumber + 1, k = rowNumber; i < newArray.GetLength(0); i++, k++)
            {
                newArray[i] = new int[array[k].Length];
                for (int j = 0; j < array[k].Length; j++)
                    newArray[i][j] = array[k][j];
            }

            return newArray;
        }

        public void PrintMenu()
        {
            Console.WriteLine("[Работа с рванными массивами]");
            Console.WriteLine("1. Создать массив.");
            Console.WriteLine("2. Отобразить массив.");
            Console.WriteLine("3. Добавить строку с заданным номером.");
            Console.WriteLine("4. Вернуться.");
        }

        public void CompleteTask(bool randomWrite, ref int choice)
        {
            PrintMenu();
            int choiceInMode = VitalikTeam.ReadValue("");

            switch (choiceInMode)
            {
                case 1:
                    {
                        int row = VitalikTeam.ReadValue("кол-во строк массива");

                        while (row <= 0)
                        {
                            Console.WriteLine("Неверно введены размеры массива.\n");
                            row = VitalikTeam.ReadValue("кол-во строк массива");
                        }

                        jagArray = VitalikTeam.WriteJagArray(row, randomWrite);
                    }
                    break;

                case 2:
                    {
                        if (jagArray != null)
                            VitalikTeam.PrintArray(jagArray);
                        else
                            Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    }
                    break;

                case 3:
                    {
                        if (jagArray != null)
                        {
                            VitalikTeam.PrintArray(jagArray);
                            jagArray = AddRowToJag(jagArray, VitalikTeam.ReadValue("номер строки"));
                            VitalikTeam.PrintArray(jagArray);
                        }
                        else
                            Console.WriteLine("Массив пуст. Сначала заполните его.\n");
                    }
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

    public static class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("[Меню]");
            Console.WriteLine("1. Работа с одномерными массивами.");
            Console.WriteLine("2. Работа с двумерными массивами.");
            Console.WriteLine("3. Работа с рваными массивами.");
            Console.WriteLine("4. Случайное заполнение.");
            Console.WriteLine("5. Выход.");
        }

        public static void Main(string[] args)
        {
            FirstExercise task_1 = new FirstExercise();
            SecondExercise task_2 = new SecondExercise();
            ThirdExercise task_3 = new ThirdExercise();

            bool randomWrite = true;

            int choice = 0;         

            while (true)
            {
                switch (choice)
                {
                    case 0:
                        PrintMenu();
                        choice = VitalikTeam.ReadValue("");

                        Console.Clear();
                        break;

                    case 1:
                        task_1.CompleteTask(randomWrite, ref choice);
                        break;

                    case 2:
                        task_2.CompleteTask(randomWrite, ref choice);
                        break;

                    case 3:
                        task_3.CompleteTask(randomWrite, ref choice);
                        break;

                    case 4:
                        {
                            randomWrite = !randomWrite;

                            Console.WriteLine($"Случайное заполнение: {randomWrite}\n");
                            choice = 0;
                        }
                        break;

                    case 5:
                        {
                            Environment.Exit(0);
                        }
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