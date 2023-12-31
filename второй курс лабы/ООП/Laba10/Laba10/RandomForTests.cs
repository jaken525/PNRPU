namespace VitalikTeamLibraries
{
    public class RandomForTests : IRandomInit, IComparable
    {
        public int number;

        public RandomForTests()
        {
            number = Randomizer.random.Next(100000);
        }

        public RandomForTests(int a)
        {
            number = a;
        }

        public int CompareTo(object obj)
        {
            int a = 0;

            if (obj as Person is not null)
                a = -1;
            else if (obj is RandomForTests random)
            {
                a = number > random.number ? 1 : -1;
                a = number == random.number ? 0 : a;
            }

            return a;
        }

        public void RandomInit()
        {
            number = Randomizer.random.Next();
        }

        public override string ToString()
        {
            return $"\nRandomForTests number = {number}\n\n";
        }
    }

    public static class Randomizer
    {
        public static List<string> names = new List<string>(new string[] { "Амбатукам", "Алексей", "Андрей", "Али", "Виктор", "Виталий", "Василий", "Алиса", "Вероника", "Вера", "Алина", "Алёна", "Борис", "Лена", "Полина", "Сергей", "Пётр", "Савелий", "Ринат", "Райан", "Фёдр", "Вадим", "Мария", "Марина", "Назар", "Павел", "Вареник", "Дмитрий", "Глеб", "Ярослав", "Шкаф", "Тимофей", "Михаил", "Ростислав", "Даниил", "Кирилл" });
        public static List<string> surnames = new List<string>(new string[] { "Головач", "Петров", "Шевцов", "Гриффин", "Лихачёв", "Малых", "Левый", "Пономарёв", "Слабый", "Позеров", "Пориджев", "Гигачадов", "Оплетин", "Воважный", "Весельчак", "Полено", "Госляков", "Валеров", "Гослинг", "Сигма", "Серый", "Сойжаков", "Гигов", "Петухов", "Кукожев", "Кринжин", "Шишкин", "Баженов", "Караваев", "Ившин", "Москов", "Петров", "Орлов", "Зеленин", "Трефилов", "Токарев" });
        public static List<string> patronymics = new List<string>(new string[] { "Амбатукамович", "Алексеевич", "Андреевич", "Алиевич", "Викторович", "Витальевич", "Васильевич", "Имбович", "Гигович", "Гигачадович", "Калинович", "Филиппович", "Борисович", "Центрович", "Авратакович", "Сергеевич", "Пётрович", "Савельевич", "Ринатович", "Райанович", "Фёдорович", "Вадимович", "Евгеньевич", "Михаилович", "Назарович", "Павлович", "Вареникович", "Дмитриевич", "Глебович", "Ярославович", "Шкафович", "Тимофеевич", "Олегович", "Ростиславович", "Даниилович", "Кириллович" });
        public static List<string> professions = new List<string>(new string[] { "Электрик", "Тестировщик", "Электроник", "Механик", "Связь", "Конструктор", "Радиоэлектронщик", "Технолог", "Строитель", "Проектировщик", "Программист", "Лаборант" });

        public static Random random = new Random();
    }

    public interface IRandomInit
    {
        public void RandomInit();
    }
}
