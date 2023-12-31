using System.Diagnostics;
using VitalikTeamLibraries;

namespace Laba_11
{
    class Program
    {
        protected static string TimeOfWorkList<T>(List<T> list, T obj)
        {
            bool flag;
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            flag = list.Contains(obj);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = $"{ts.TotalMilliseconds} Найден: {flag}";

            return elapsedTime;
        }

        protected static string TimeOfWorkDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key)
        {
            bool flag;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            flag = dictionary.ContainsKey(key);
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }

        protected static string TimeOfWorkDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue value)
        {
            bool flag;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            flag = dictionary.ContainsValue(value);
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }

        public static void TestTime(ref TestCollections test)
        {
            Console.WriteLine("Поиск первого элемента в коллекции List<Person>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listPerson, (Person)test.listPerson[0].Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции List<Person>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listPerson, (Person)test.listPerson[test.listPerson.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции List<Person>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listPerson, (Person)test.listPerson[test.listPerson.Count - 1].Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию List<Person>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listPerson, new Person())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции List<string>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listString, (string)test.listString[0].Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции List<string>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listString, (string)test.listString[test.listString.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции List<string>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listString, (string)test.listString[test.listString.Count - 1].Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию List<string>...");
            Console.WriteLine($"Время = {TimeOfWorkList(test.listString, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции Dictionary<Person,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryPersonEmpolyee, (Person)test.dictionaryPersonEmpolyee.Keys.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального ключа в коллекции Dictionary<Person,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryPersonEmpolyee, (Person)test.dictionaryPersonEmpolyee.Keys.ToArray()[test.dictionaryPersonEmpolyee.Keys.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего ключа в коллекции Dictionary<Person,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryPersonEmpolyee, (Person)test.dictionaryPersonEmpolyee.Keys.ToArray()[test.dictionaryPersonEmpolyee.Keys.Count - 1].Clone())}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию Dictionary<Person,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryPersonEmpolyee, new Person())}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого ключа в коллекции Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, (string)test.dictionaryStringEmployee.Keys.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального ключа в коллекции Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, (string)test.dictionaryStringEmployee.Keys.ToArray()[test.dictionaryStringEmployee.Keys.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего ключа в коллекции Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, (string)test.dictionaryStringEmployee.Keys.ToArray()[test.dictionaryStringEmployee.Keys.Count - 1].Clone())}");
            Console.WriteLine("Поиск ключа не входящего в коллекцию Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, "")}");
            Console.WriteLine();

            Console.WriteLine("Поиск первого элемента в коллекции Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, (Employee)test.dictionaryStringEmployee.Values.ToArray()[0].Clone())}");
            Console.WriteLine("Поиск центрального элемента в коллекции Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, (Employee)test.dictionaryStringEmployee.Values.ToArray()[test.listPerson.Count / 2].Clone())}");
            Console.WriteLine("Поиск последнего элемента в коллекции Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, (Employee)test.dictionaryStringEmployee.Values.ToArray()[test.listPerson.Count - 1].Clone())}");
            Console.WriteLine("Поиск элемента не входящего в коллекцию Dictionary<string,Employee>...");
            Console.WriteLine($"Время = {TimeOfWorkDictionary(test.dictionaryStringEmployee, new Employee())}");
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1 - Добавить элементы\n2 - Время поиска в различных коллекциях\n3 - Выход");
        }

        static void Main(string[] args)
        {
            TestCollections test = new TestCollections();
            while (true)
            {
                PrintMenu();
                int ui = VitalikTeamLibrary.VitalikTeam.ReadValue();

                Console.Clear();
                switch (ui)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите кол-во элементов для добавления: ");

                        int a = VitalikTeamLibrary.VitalikTeam.ReadValue();
                        test.RandomInit(a);

                        break;

                    case 2:
                        Console.Clear();

                        try
                        {
                            TestTime(ref test);
                        }
                        catch 
                        {
                            Console.WriteLine("В коллекции отсутствуют элементы\n");
                        }

                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Выбрана несуществующая команда.\n");
                        break;
                }

            }

        }

    }

}
