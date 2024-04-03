using System;
using System.Text;
using VitalikTeamLibraries;

class Program
{
    static DoublyLinkedList<Person> people = new DoublyLinkedList<Person>();

    static void PrintCollection()
    {
        if (people.Count > 0)
            foreach (Person person1 in people)
            {
                Console.WriteLine($" Индекс: {people.IndexOf(person1) + 1}");
                Console.WriteLine(person1);
            }
        else
            Console.WriteLine("\nКоллекция пуста\n");
    }

    static void Main(string[] args)
    {
        int choice = 0;
        bool flag = true;

        string menu = "1. Добавить элемент(ы) в коллекцию.\n" +
                         "2. Печать коллекции.\n" +
                         "3. Добавить в список элемент после элемента с заданным информационным полем.\n" +
                         "4. Удаление элемента коллекции по индексу.\n" +
                         "5. Вставка в коллекцию по индексу.\n" +
                         "6. Очистить текущую коллекцию.\n" +
                         "7. Выход.\n\n";

        while (flag)
        {
            Console.WriteLine(menu);
            choice = VitalikTeamLibrary.VitalikTeam.ReadValue("");
            Console.Clear();

            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("1 - Добавить элемент вручную.\n2 - Добавить элементы случайным образом");

                        int count = VitalikTeamLibrary.VitalikTeam.ReadValue("режим");
                        if (count == 1)
                        {
                            do
                            {
                                Console.WriteLine("1 - Добавить работника.\n2 - Добавить инженера\n3 - Добавить админа");
                                count = VitalikTeamLibrary.VitalikTeam.ReadValue("персону");
                            }
                            while (count > 3 || count < 1);

                            Person person1 = count == 1 ? new Employee() : count == 2 ? new Engineer() : new Adminstartor();
                            person1.Init();

                            people.Add(person1);
                        }
                        else if (count == 2)
                        {
                            int count1 = VitalikTeamLibrary.VitalikTeam.ReadValue("кол-во элементов");

                            for (int i = 0; i < count1; ++i)
                            {
                                int type = VitalikTeamLibrary.VitalikTeam.Random(1, 4);

                                Person person1 = type == 1 ? new Employee() : type == 2 ? new Engineer() : new Adminstartor();
                                person1.RandomInit();

                                people.Add(person1);
                            }
                        }
                        else
                            Console.WriteLine("Введено неверное значение!");
                    }
                    break;

                case 2:

                    Console.WriteLine("Все элементы коллекции: ");
                    PrintCollection();

                    break;

                case 3:

                    if (people.Count > 0)
                    {
                        PrintCollection();

                        int age = VitalikTeamLibrary.VitalikTeam.ReadValue("возраст");
                        int index = people.IndexOf(x => x.Age == age);
                        int count1 = 0;

                        if (index != -1)
                        {
                            do
                            {
                                Console.WriteLine("1 - Добавить работника.\n2 - Добавить инженера\n3 - Добавить админа");
                                count1 = VitalikTeamLibrary.VitalikTeam.ReadValue("персону");
                            }
                            while (count1 > 3 || count1 < 1);

                            Person person1 = count1 == 1 ? new Employee() : count1 == 2 ? new Engineer() : new Adminstartor();
                            person1.Init();

                            people.Insert(index, person1);
                        }
                        else
                            Console.WriteLine($"\nЭлемент с возрастом: {age} не наден\n");
                    }
                    else Console.WriteLine("Коллекция пуста! Сначала заполните её\n");

                    break;

                case 4:

                    if (people.Count > 0)
                    {
                        PrintCollection();

                        int index2 = VitalikTeamLibrary.VitalikTeam.ReadValue("индекс удаляемого элемента");
                        people.RemoveAt(index2 - 1);
                    }
                    else Console.WriteLine("Коллекция пуста! Сначала заполните её\n");

                    break;

                case 5:

                    if (people.Count > 0)
                    {
                        PrintCollection();

                        int index3 = VitalikTeamLibrary.VitalikTeam.ReadValue("индекс для добавления элемента");
                        int count2 = 0;

                        do
                        {
                            Console.WriteLine("1 - Добавить работника.\n2 - Добавить инженера\n3 - Добавить админа");
                            count2 = VitalikTeamLibrary.VitalikTeam.ReadValue("персону");
                        }
                        while (count2 > 3 || count2 < 1);

                        Person person = count2 == 1 ? new Employee() : count2 == 2 ? new Engineer() : new Adminstartor();
                        person.Init();

                        people.Insert(index3, person);
                    }
                    else Console.WriteLine("Коллекция пуста! Сначала заполните её\n");

                    break;

                case 6:

                    Console.WriteLine("Коллекция очищена.\n");
                    people.Clear();

                    break;

                case 7:

                    people.Clear();
                    flag = false;

                    break;

                default:

                    Console.WriteLine("Неверно введено значение.\n");

                    break;
            }

        }

        people = new DoublyLinkedList<Person>();

        Person personOriginal = new Person();
        personOriginal.RandomInit();

        people.Add(personOriginal);

        Console.WriteLine("Исходная коллекция перед изменением:");
        foreach (Person person1 in people)
        {
            Console.WriteLine($" Индекс: {people.IndexOf(person1) + 1}");
            Console.WriteLine(person1);
        }

        DoublyLinkedList<Person> clone = (DoublyLinkedList<Person>)people.Clone();
        people[0].Show();
        people[0].Age = 80;
        people[0].Show();

        Console.WriteLine("\nИсходная коллекция:");
        foreach (Person person1 in people)
        {
            Console.WriteLine($" Индекс: {people.IndexOf(person1) + 1}");
            Console.WriteLine(person1);
        }

        Console.WriteLine("\nклон коллекция:");
        foreach (Person person1 in clone)
        {
            Console.WriteLine($" Индекс: {clone.IndexOf(person1) + 1}");
            Console.WriteLine(person1);
        }
    }

}