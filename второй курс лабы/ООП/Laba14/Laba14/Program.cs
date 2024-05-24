using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using VitalikTeamLibraries;

namespace Laba14
{
    class Program
    {
        enum rule
        {
            CountOfStacks = 3,
            CountOfElemsInStacks = 6,
            CountOfElemsInRDLL = 10,

            MinRandomNum = 0,
            MaxRandomNum = 3,

            PartOne = 1,
            PartTwo = 2
        }

        public static void RandomInit(Stack<Person> dictionary, int countOfElems)
        {
            for (int i = 0; i < countOfElems; ++i)
            {
                int rnd = Randomizer.random.Next((int)rule.MinRandomNum, (int)rule.MaxRandomNum);
                Person people = rnd == 0 ? new Employee() : rnd == 1 ? new Engineer() : new Adminstartor();
                people.RandomInit();
                dictionary.Push(people);
            }
        }

        public static IEnumerable<Person> RequestOfSelection(Dictionary<int, Stack<Person>> stacks, int age, bool isLINQ) // персоны возрастом
        {
            if (isLINQ)
            {
                var result = from stack in stacks
                             from person in stack.Value
                             where (person.Age > age)
                             select person;
                return result;
            }
            else
                return stacks.SelectMany(stack => stack.Value.Where(person => person.Age < age).Select(person => person));
            
        }

        public static int RequestOfCounter(Dictionary<int, Stack<Person>> stacks, bool isLINQ) // количество определённых персон
        {
            if (isLINQ)
            {
                var result = from stack in stacks
                             from person in stack.Value
                             where (person is Engineer)
                             select person;
                return result.Count();
            }
            else
                return stacks.SelectMany(stack => stack.Value.Where(person => person is Engineer)).Count();
            
        }

        public static IEnumerable<Person> Unionw(Dictionary<int,Stack<Person>> stacks, Dictionary<int, Stack<Person>> stacksNew, bool isLINQ) // Объединение
        {
            if (isLINQ)
            {
                var v1 = from stack in stacks
                             from person in stack.Value
                             select person;

                var v2 = from stack in stacksNew
                         from person in stack.Value
                         select person;

                return v1.Union(v2);
            }
            else
            {
                var v1 = stacks.SelectMany(stack => stack.Value);
                var v2 = stacksNew.SelectMany(stack => stack.Value);
                return v1.Union(v2);
            }
            
        }

        public static IEnumerable<Person> Intersectw(Dictionary<int, Stack<Person>> stacks, Dictionary<int, Stack<Person>> stacksNew, bool isLINQ) // Пересечение
        {
            if (isLINQ)
            {
                var v1 = from stack in stacks
                         from person in stack.Value
                         select person;

                var v2 = from stack in stacksNew
                         from person in stack.Value
                         select person;

                return v1.Intersect(v2);
            }
            else
            {
                var v1 = stacks.SelectMany(stack => stack.Value);
                var v2 = stacksNew.SelectMany(stack => stack.Value);
                return v1.Intersect(v2);
            }

        }

        public static IEnumerable<Person> Exceptw(Dictionary<int, Stack<Person>> stacks, Dictionary<int, Stack<Person>> stacksNew, bool isLINQ) // Разность
        {
            if (isLINQ)
            {
                var v1 = from stack in stacks
                         from person in stack.Value
                         select person;

                var v2 = from stack in stacksNew
                         from person in stack.Value
                         select person;

                return v1.Except(v2);
            }
            else
            {
                var v1 = stacks.SelectMany(stack => stack.Value);
                var v2 = stacksNew.SelectMany(stack => stack.Value);
                return v1.Except(v2);
            }

        }

        public static int RequestOfAggregation(Dictionary<int, Stack<Person>> stacks, bool isLINQ) // сумма возрастов
        {
            if(isLINQ)
            {
                int sum = 0;
                var result = from stack in stacks
                             from person in stack.Value
                             select person.Age;
                sum = result.Sum();
                return sum;
            }
            else
            {
                int sum = 0;
                return stacks.SelectMany(stack => stack.Value).Aggregate(sum, (s, person) => s + person.Age);
            } 
        }

        public static IEnumerable<IGrouping<Type,Person>> RequestOfGroupLINQ(Dictionary<int, Stack<Person>> stacks) // группировка по квалификации
        {
            var result = from stack in stacks
                         from person in stack.Value
                         group person by person.GetType();
            return result;
        }

        static void Main(string[] args)
        {
            int isop = 0;
            int UI = 0;
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("\n1 - Часть первая\n2 - Часть вторая\n3 - Выход\n");

                UI = VitalikTeamLibrary.VitalikTeam.ReadValue("часть");

                Console.Clear();

                switch (UI)
                {
                    case (int)rule.PartOne:
                        {
                            Dictionary<int, Stack<Person>> stacks = new();
                            for (int i = 0; i < (int)rule.CountOfStacks; ++i)
                            {
                                stacks.Add(i, new Stack<Person>((int)rule.CountOfElemsInStacks));
                                RandomInit(stacks[i], (int)rule.CountOfElemsInStacks);
                            }

                            Dictionary<int, Stack<Person>> stacksNew = new();
                            for (int i = 0; i < (int)rule.CountOfStacks; ++i)
                            {
                                stacksNew.Add(i, new Stack<Person>((int)rule.CountOfElemsInStacks));
                                RandomInit(stacksNew[i], (int)rule.CountOfElemsInStacks);
                            }

                            Console.WriteLine("\n\t\tЧАСТЬ ПЕРВАЯ:\n\n");
                            Console.WriteLine("\t\t    Исходные данные 1:\n");

                            foreach (KeyValuePair<int, Stack<Person>> stack in stacks)
                                foreach (Person person in stack.Value)
                                {
                                    ++isop;
                                    Console.WriteLine($"\t\t|{isop}|\n{person}");
                                }

                            Console.WriteLine("\n\n\n");
                            Console.WriteLine("\t\t    Исходные данные 2:\n");

                            isop = 0;
                            foreach (KeyValuePair<int, Stack<Person>> stack in stacksNew)
                                foreach (Person person in stack.Value)
                                {
                                    ++isop;
                                    Console.WriteLine($"\t\t|{isop}|\n{person}");
                                }

                            Console.WriteLine("\n\n\n");
                            Console.WriteLine("\tРезультат выборки с возрастом больше 50:\n");

                            isop = 0;
                            foreach (var person in RequestOfSelection(stacks, 50, true))
                            {
                                string person1 = person.ToString();
                                ++isop;
                                if (person1 is null)
                                {
                                    Console.WriteLine("\t\tНе найдено\n");
                                    break;
                                }
                                else
                                    Console.WriteLine($"\t\t|{isop}|\n{person1}");
                            }

                            Console.WriteLine("\n");
                            Console.WriteLine($"\tКоличество человек с квалификацией инженер: {RequestOfCounter(stacks, false)}\n");
                            Console.WriteLine("\n");
                            Console.WriteLine("\t\t Объединение двух коллекций");

                            isop = 0;
                            foreach (var person in Unionw(stacks, stacksNew, true))
                            {
                                ++isop;
                                Console.WriteLine($"\t\t|{isop}|\n{person}");
                            }

                            Console.WriteLine("\n");
                            Console.WriteLine("\t\t Пересечение двух коллекций");

                            isop = 0;
                            foreach (var person in Intersectw(stacks, stacksNew, true))
                            {
                                ++isop;
                                Console.WriteLine($"\t\t|{isop}|\n{person}");
                            }

                            Console.WriteLine("\n");
                            Console.WriteLine("\t\t Разность двух коллекций");

                            isop = 0;
                            foreach (var person in Exceptw(stacks, stacksNew, true))
                            {
                                ++isop;
                                Console.WriteLine($"\t\t|{isop}|\n{person}");
                            }

                            Console.WriteLine($"\tСуммарный возраст всех людей: {RequestOfAggregation(stacks, true)}\n");
                            Console.WriteLine("\n");
                            Console.WriteLine("\t Группировка людей по квалификации:");

                            foreach (IGrouping<Type, Person> group in RequestOfGroupLINQ(stacks))
                            {
                                isop = 0;
                                Console.WriteLine($"\n\n\t|{group.Key.Name}| - {group.Count()}\n\n");
                                foreach (var person in group)
                                {
                                    ++isop;
                                    Console.WriteLine($"\t\t|{isop}|\n{person}");
                                }
                            }

                            Console.ReadLine();
                        }
                        break;

                    case (int)rule.PartTwo:
                        {
                            Console.WriteLine("\n\t\tЧАСТЬ ВТОРАЯ:\n\n");
                            DoublyLinkedList<Person> peoples = new DoublyLinkedList<Person>();
                            for (int i = 0; i < (int)rule.CountOfElemsInRDLL; ++i)
                            {
                                int randNum = Randomizer.random.Next((int)rule.MinRandomNum, (int)rule.MaxRandomNum);
                                Person people = randNum == 0 ? new Employee() : randNum == 1 ? new Engineer() : new Adminstartor();
                                people.RandomInit();
                                peoples.Add(people);
                            }

                            Console.WriteLine("\n");
                            Console.WriteLine("\t   Исходные данные двунаправленного списка:\n");

                            isop = 0;
                            foreach (Person person in peoples)
                            {
                                ++isop;
                                Console.WriteLine($"\t\t|{isop}|\n{person}");
                            }

                            Console.WriteLine("\n\n\n");
                            Console.WriteLine(" Результат выборки людей квалификации администратор с возрастом больше 50:\n");

                            isop = 0;
                            foreach (var person in peoples.Select(person => person is Adminstartor && person.Age > 50, person => person))
                            {
                                string person1 = person.ToString();
                                ++isop;
                                if (person1 is null)
                                {
                                    Console.WriteLine("\t\t\tНе найдено\n");
                                    break;
                                }
                                else
                                    Console.WriteLine($"\t\t|{isop}|\n{person1}");
                            }

                            Console.WriteLine("\n");

                            isop = 0;
                            int seed = 0;

                            Console.WriteLine($"\t\tСуммарный возраст всех людей: {peoples.Aggregate(seed, (person, people) => person + people.Age)}\n");
                            Console.WriteLine($"\t\tМаксимальный возраст всех людей: {peoples.Max(person => person.Age)}\n");
                            Console.WriteLine($"\t\tМинимальный возраст всех людей: {peoples.Min(person => person.Age)}\n");
                            Console.WriteLine($"\t\tСредний возраст всех людей: {peoples.Average(person => person.Age)}\n");
                            Console.WriteLine("\n\n\n");
                            Console.WriteLine("\t    Люди отсортированные по возрасту по возрастанию:\n");

                            foreach (var person in peoples.OrderBy(person => person.Age, (person1, person2) => person1 > person2 ? 1 : person1 == person2 ? 0 : -1))
                            {
                                string person1 = person.ToString();
                                ++isop;
                                if (person1 is null)
                                {
                                    Console.WriteLine("\t\tНе найдено\n");
                                    break;
                                }
                                else
                                    Console.WriteLine($"\t\t|{isop}|\n{person1}");
                            }

                            Console.WriteLine("\n");
                            Console.WriteLine("\t    Люди отсортированные по возрасту по убываниюю:\n");

                            foreach (var person in peoples.OrderByDescending(person => person.Age, (person1, person2) => person1 > person2 ? 1 : person1 == person2 ? 0 : -1))
                            {
                                string person1 = person.ToString();
                                ++isop;
                                if (person1 is null)
                                {
                                    Console.WriteLine("\t\tНе найдено\n");
                                    break;
                                }
                                else
                                    Console.WriteLine($"\t\t|{isop}|\n{person1}");
                            }
                            Console.WriteLine("\n");

                            Console.ReadLine();
                        }
                        break;

                    case 3:
                        {
                            flag = false;
                            Console.Clear();
                            Console.WriteLine("Exit");
                        }
                        break;

                    default:
                        flag = true;
                        break;
                }

            }

        }

    }

}
