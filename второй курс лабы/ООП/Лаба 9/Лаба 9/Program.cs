// Вариант 8

using VitalikTeamLibrary;
using VitalikTeamMoney;

namespace Laba9
{
    static class Program
    {
        public static readonly string[] mode = { "Режим РУЧНОГО заполнения", "Режим СЛУЧАЙНОГО заполнения" };

        public static void WriteArray(ref MoneyArray array, bool isRandomWrite)
        {
            Console.WriteLine(mode[Convert.ToInt32(isRandomWrite)]);
            int size = VitalikTeam.ReadValue("размер массива");
            while (size <= 0)
            {
                Console.WriteLine("Неверно введены размер массива.\n");
                size = VitalikTeam.ReadValue("размер массива");
            }

            array = new MoneyArray(size);
            array.WriteArray(isRandomWrite);
        }

        public static void PrintMenu()
        {
            Console.WriteLine("[Работа с массивами Money]");
            Console.WriteLine("1. Создать массив.");
            Console.WriteLine("2. Отобразить массив.");
            Console.WriteLine("3. Случайное заполнение.");
            Console.WriteLine("4. Вывести первый элемент массива и закончить.");
        }

        static void Main(string[] args)
        {

            //////////////////////////////////////////////////////////
            /// CLASS PRESENTATION
            //////////////////////////////////////////////////////////

            Money money = new Money();
            money.PrintBalance("");
            Console.WriteLine();



            Console.WriteLine("[Создание]");

            money = new Money(VitalikTeam.ReadValue("количество рублей"), VitalikTeam.ReadValue("количество копеек"));
            money.PrintBalance("Введёный");
            Console.WriteLine();



            Console.WriteLine("[Унарные операции]");

            money--;
            money.PrintBalance("Вычитание копейки.");

            money++;
            money++;
            money.PrintBalance("Добавление двух копеек.");
            Console.WriteLine();



            Console.WriteLine("[Приведение типа]");

            int rubles = money;
            double kopeks = (double)money;

            Console.WriteLine();
            Console.WriteLine($"Неявное преобразование типа в int: {rubles}\n");
            Console.WriteLine($"Явное преобразование типа в double: {(double)kopeks}\n\n\n");



            Console.WriteLine("[Сравнение]");

            Console.WriteLine($"\n\nСоздание копию Money (money1)");

            Money money1 = new Money();
            money1 = new Money(money);

            money.PrintBalance("Оригинал");
            money1.PrintBalance("Копия");

            Console.WriteLine($"\nСовпадают ли? {money.Equals(money1)}\n\nИзменим money1...");

            money1 = new Money(1, 2);
            money1.PrintBalance("Новый money1");

            Console.WriteLine($"\nСовпадают ли? {money.Equals(money1)}\n");
            Console.WriteLine("\n");



            Console.WriteLine("[Бинарные операции]");

            money1 = 10000 - money;
            money1.PrintBalance("(money1)  Вычитание суммы из 10000 копеек (100 рублей).\n\n");

            Console.WriteLine($"(money) Вычитание 10000 копеек (100 рублей) из суммы.");
            money = money - 10000;
            money.PrintBalance("");

            Console.WriteLine($"\n(money) Вычитание 2000 копеек (20 рублей) из суммы.");
            money = money - 2000;
            money.PrintBalance("");

            Console.WriteLine($"\n(money) Вычитание 50 копеек из суммы.");
            money = money - 50;
            money.PrintBalance("");



            //////////////////////////////////////////////////////////
            /// ARRAY PRESENTATION
            //////////////////////////////////////////////////////////

            Console.WriteLine("\nПауза. Для продолжения нажмите любую клавишу на клавиатуре...");
            Console.ReadKey();
            Console.Clear();

            bool isRandomWrite = true;
            bool isExit = false;

            MoneyArray moneyArray = new MoneyArray();

            while (!isExit)
            {
                PrintMenu();
                int choice = VitalikTeam.ReadValue();

                Console.Clear();

                switch(choice)
                {
                    case 1:
                        WriteArray(ref moneyArray, isRandomWrite);
                        break;

                    case 2:
                        moneyArray.PrintArray();

                        if (moneyArray.Count > 0)
                            Console.WriteLine($"Номер минимального элемента: {moneyArray.GetMinimalNumber()}");
                        break;

                    case 3:
                        isRandomWrite = !isRandomWrite;
                        Console.WriteLine($"Случайное заполнение: {isRandomWrite}\n");
                        break;

                    case 4:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Выбрана несуществующая команда.\n");
                        break;
                }

            }

            Console.Clear();

            int index = VitalikTeam.ReadValue("индекс элемента");

            if (moneyArray.Count > 0)
            {
                while (index >= moneyArray.Count)
                {
                    Console.WriteLine("выход за пределы массива");
                    index = VitalikTeam.ReadValue("индекс элемента");

                }

                moneyArray[index].PrintBalance();
                    
            }
            else
                Console.WriteLine("Массив пуст. Первый элемент выведен не будет.\n");


            Console.WriteLine(MoneyArray.GetObjectCount());
        }

    }

}