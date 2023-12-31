using System.Diagnostics.Metrics;
using System.Reflection;
using System.Windows.Markup;
using VitalikTeamLibraries;

namespace Laba10
{ 
    public class Program
    {
        static void PrintList(List<Person> PersonList)
        {
            Console.WriteLine($"[СПИСОК ВСЕХ ПЕРСОН]\n");
            for (int i = 0; i < PersonList.Count; i++)
            {
                    Console.WriteLine($"[{i + 1}]");
                    PersonList[i].Show();
            }
        }

        static void Query1(List<Person> PersonList)
        {
            Console.WriteLine("\n[ПОИСК ПО ИМЕНИ]");
            string personName = VitalikTeamLibrary.VitalikTeam.ReadString("имя");
            Console.WriteLine($"\nПоиск по имени: {personName}\nРезультат:\n");
            
            int count = 0;
            for (int i = 0; i < PersonList.Count; ++i)
                if (PersonList[i].name == personName)
                {
                    count += 1;
                    Console.WriteLine($"[{count}]");
                    PersonList[i].Show();
                    Console.WriteLine();
                }
                else if (i == PersonList.Count - 1 && PersonList[i].name != personName && count == 0)
                    Console.WriteLine(" Пользователь не был найден");
        }

        static void Query2(List<Person> PersonList)
        {
            Console.WriteLine("\n[ПОИСК БОЛЬШЕ ЗАДАННОГО ВОЗРАСТА]");
            int personAge = VitalikTeamLibrary.VitalikTeam.ReadValue("возраст");

            Console.WriteLine($"\nПоиск поиск персон с возрастом {personAge}\nРезультат:\n");

            int count = 0;
            for (int i = 0; i < PersonList.Count; ++i)
                if (PersonList[i].Age > personAge)
                {
                    count += 1;
                    Console.WriteLine($"[{count}]");
                    PersonList[i].Show();
                    Console.WriteLine();
                }
                else if (i == PersonList.Count - 1 && PersonList[i].Age < personAge && count == 0)
                    Console.WriteLine(" Пользователь не был найден");
        }
        static void Query3(List<Person> PersonList)
        {
            Console.WriteLine("\n[ПОИСК ПО ТИПУ]");
            Console.WriteLine(
                "\nТипы:\n" +
                " Персона - 1\n" +
                " Рабочий - 2\n" +
                " Инженер - 3\n" +
                " Администрация - 4"
                );

            int type = VitalikTeamLibrary.VitalikTeam.ReadValue("тип");
            int count = 0;

            Console.WriteLine();
            switch (type)
            {
                case 1:
                    for (int i = 0; i < PersonList.Count; ++i)
                        if (PersonList[i] is not Adminstartor && PersonList[i] is not Engineer && PersonList[i] is not Employee)
                        {
                            count += 1;
                            Console.WriteLine($"[{count}]");
                            PersonList[i].Show();
                            Console.WriteLine();
                        }
                    break;

                case 2:
                    for (int i = 0; i < PersonList.Count; ++i)
                        if (PersonList[i] is Employee)
                        {
                            count += 1;
                            Console.WriteLine($"[{count}]");
                            PersonList[i].Show();
                            Console.WriteLine();
                        }
                    break;

                case 3:
                    for (int i = 0; i < PersonList.Count; ++i)
                        if (PersonList[i] is Engineer)
                        {
                            count += 1;
                            Console.WriteLine($"[{count}]");
                            PersonList[i].Show();
                            Console.WriteLine();
                        }
                    break;

                case 4:
                    for (int i = 0; i < PersonList.Count; ++i)
                        if (PersonList[i] is Adminstartor)
                        {
                            count += 1;
                            Console.WriteLine($"[{count}]");
                            PersonList[i].Show();
                            Console.WriteLine();
                        }
                    break;

                default:
                    Console.WriteLine("Неверно выбран тип.");
                    break;
            }
        }

        static void InitPersons(List<Person> list, int start = 0)
        {
            for (int i = start; i < list.Count; i++)
                list[i].RandomInit();
        }

        static void GetRandomNumber(List<Person> list)
        {
            IRandomInit[] arrayIRandomInit = new IRandomInit[] { new RandomForTests(), new RandomForTests(), new RandomForTests(), list[10], list[1], list[4], list[8], list[6], list[3] };

            Console.WriteLine("Случайная инициализация всех объектов в массиве типа IRandomInit\n");
            for (int i = 0; i < arrayIRandomInit.Length; ++i)
                arrayIRandomInit[i].RandomInit();

            IRandomInit[] arrayIRandomInitCopy = new IRandomInit[arrayIRandomInit.Length];

            Console.WriteLine("Поверхостное копирование массива типа IRandomInit\n");
            arrayIRandomInit.CopyTo(arrayIRandomInitCopy, 0);
            foreach (IRandomInit i in arrayIRandomInitCopy)
                Console.WriteLine(i.ToString());

            Console.WriteLine("Сортировка массива\n");
            Console.WriteLine("Отсортированный оригинал:");
            Array.Sort(arrayIRandomInit, new PersonComparer());
            foreach (IRandomInit i in arrayIRandomInit)
                Console.WriteLine(i.ToString());

            Console.WriteLine("Заранее сделанная копия:");
            foreach (IRandomInit i in arrayIRandomInitCopy)
                Console.WriteLine(i.ToString());

            int binarySearchAnswer = Array.BinarySearch(arrayIRandomInit, arrayIRandomInit[0], new PersonComparer());

            Console.WriteLine($"Поиск первого элемента в массиве: {binarySearchAnswer}");

            list[0].RandomInit();
            list[0].random = new RandomForTests();
            list[0].random.number = 1;
            list[1] = (Person)list[0].ShallowCopy();
            list[2] = (Person)list[0].Clone();

            Console.WriteLine($"Person1.random.randomNumber: {list[0].random.number}");
            Console.WriteLine($"Оригинальный объект: {list[0]}");

            Console.WriteLine($"Person2.random.randomNumber: {list[1].random.number}");
            Console.WriteLine($"Копия:\n {list[1]}");

            Console.WriteLine($"Person3.random.randomNumber: {list[2].random.number}");
            Console.WriteLine($"Клон\n {list[2]}");

            list[0].random.number = 5;

            Console.WriteLine($"Оригинал Person1.random.randomNumber: {list[0].random.number}");
            Console.WriteLine($"Копия:\n {list[1]}");
            Console.WriteLine($"Копия Person2.random.randomNumber: {list[1].random.number}");
            Console.WriteLine($"Клон:\n {list[2]}");
            Console.WriteLine($"Клон Person3.random.randomNumber: {list[2].random.number}");
        }

        static void PrintMenu()
        {
            Console.WriteLine(
                "[МЕНЮ]\n" +
                "1. Поиск по имени\n" +
                "2. Поиск больше заданного возраста\n" +
                "3. Поиск по типу\n" +
                "4. Бинарный поиск. Разница копирования и клонирования\n" +
                "5. Сгенерировать персон заново\n" +
                "6. Выйти"
                );
        }

        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>
                (new Person[] {
                    new Person("Алексей", "Антипьев", "Андреевич", 28),
                    new Employee(629, "Виталий", "Степанов", "Сергеевич", 32),
                    new Engineer(3, "Программист", "Виталий", "Поважный", "Евгеньевич", 18),
                    new Adminstartor(9, 134, "Ростислав", "Лавров", "Александрович", 45),
                    new Person(),
                    new Employee(),
                    new Engineer(),
                    new Adminstartor(),
                    new Person(),
                    new Employee(),
                    new Engineer(),
                    new Adminstartor()
                });
            InitPersons(personList, 4);

            while (true)
            {
                Console.Clear();

                PrintList(personList);
                PrintMenu();

                int choice = VitalikTeamLibrary.VitalikTeam.ReadValue();

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        PrintList(personList);
                        Query1(personList);
                        break;

                    case 2:
                        PrintList(personList);
                        Query2(personList);
                        break;

                    case 3:
                        PrintList(personList);
                        Query3(personList);
                        break;

                    case 4:
                        GetRandomNumber(personList);
                        break;

                    case 5:
                        InitPersons(personList, 0);
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Выбрана несуществующая команда.\n");
                        break;
                }

                Console.WriteLine("\nПауза. Для продолжения нажмите любую клавишу на клавиатуре...");
                Console.ReadKey();
            }
            
        }

    }

}