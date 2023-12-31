using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VitalikTeamLibraries
{
    public class Person : IRandomInit, IComparable, ICloneable
    {
        public RandomForTests random;

        public string name;
        public string surname;
        public string patronymic;

        private int age;

        /// <summary>
        /// Свойство для установки возраста персоны
        /// </summary>
        public int Age
        {
            get => age;
            set
            {
                if (value >= 0)
                    age = value;
                else
                    throw new Exception("Ошибка! Значение не может быть отрицательным");
            }

        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Person()
        {
            Age = 0;

            name = "";
            surname = "";
            patronymic = "";

            random = new RandomForTests();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="patronymic"></param>
        /// <param name="age"></param>
        public Person(string name, string surname, string patronymic, int age, RandomForTests random = null)
        {
            this.Age = age;

            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;

            this.random = random;
        }

        /// <summary>
        /// Виртуальный метод вывода персоны.
        /// </summary>
        public virtual void Show()
        {
            Console.WriteLine($"(Тип: Персона)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {age}\n\n");
        }

        /// <summary>
        /// Обобщённый метод сравнения. Сравнивает положение данного экземпляра и объекта в порядке сортировки.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object? obj)
        {
            int a = 0;
            if (obj is Person b)
            {
                if (Age != b.Age || name != b.name || surname != b.surname || patronymic != b.patronymic)
                    a = GetHashCode() >= b.GetHashCode() ? 1 : -1;
            }
            else if (obj is RandomForTests Class)
                a = 1;

            return a;
        }

        /// <summary>
        /// Виртуальный метод клонирования
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            Person person = new Person();

            if (random is null)
                person = new Person(name, surname, patronymic, age);
            else
                person = new Person(name, surname, patronymic, age, new RandomForTests(random.number));

            return person;
        }

        /// <summary>
        /// Виртуальный метод инициализации полей класса случайным образом
        /// </summary>
        public virtual void RandomInit()
        {
            this.age = Randomizer.random.Next(18, 85);

            this.name = Randomizer.names[Randomizer.random.Next(0, Randomizer.names.Count)];
            this.surname = Randomizer.surnames[Randomizer.random.Next(0, Randomizer.surnames.Count)];
            this.patronymic = Randomizer.patronymics[Randomizer.random.Next(0, Randomizer.patronymics.Count)];

            this.random = new RandomForTests();
            this.random.number = Randomizer.random.Next(100);
        }

        /// <summary>
        /// Виртуальный метод инициализации полей класса
        /// </summary>
        public virtual void Init()
        {
            this.Age = VitalikTeamLibrary.VitalikTeam.ReadValue();

            this.name = VitalikTeamLibrary.VitalikTeam.ReadString();
            this.surname = VitalikTeamLibrary.VitalikTeam.ReadString();
            this.patronymic = VitalikTeamLibrary.VitalikTeam.ReadString();

            this.random = new RandomForTests(VitalikTeamLibrary.VitalikTeam.ReadValue());
        }

        /// <summary>
        /// Виртуальный метод для создания ссылочной копии.
        /// </summary>
        /// <returns></returns>
        public virtual object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Переопределение метода ToString для класса Person
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string ToString()
        {
            return $"(Тип: Персона)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {age}\n\n";
        }

        /// <summary>
        /// Переопределение метода Equals для класса Person
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            bool flag = false;

            if (obj is Person c)
                flag = c.CompareTo(this) == 0;

            return flag;
        }
        
        /// <summary>
        /// Переопределение метода GetHashCode для получения хэша
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < surname.Length; ++i)
                hash += (int)surname[i];

            for (int i = 0; i < name.Length; ++i)
                hash += (int)name[i];

            for (int i = 0; i < patronymic.Length; ++i)
                hash += (int)patronymic[i];

            return hash;
        }
    
    }

    public class Employee : Person
    {
        public int hours;

        /// <summary>
        /// Свойство для установки персоны
        /// </summary>
        public Person person
        {
            get => new Person(name, surname, patronymic, Age);
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Employee() : base()
        {
            hours = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="patronymic"></param>
        /// <param name="age"></param>
        public Employee(int hours, string name, string surname, string patronymic, int age) : base(name, surname, patronymic, age)
        {
            this.hours = hours;
        }

        /// <summary>
        /// Переопределение метод вывода рабочего.
        /// </summary>
        public override void Show()
        {
            Console.WriteLine($"(Тип: Рабочий)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Часы работы: {hours}\n\n");
        }

        /// <summary>
        /// Переопределение метода RandomInit для инициализации полей класса случайным образом
        /// </summary>
        public override void RandomInit()
        {
            base.RandomInit();
            hours = Randomizer.random.Next(-100, 700);
        }

        public override void Init()
        {
            base.Init();
            hours = VitalikTeamLibrary.VitalikTeam.ReadValue();
        }

        /// <summary>
        /// Переопределение метода Clone для клонирования объекта
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new Employee(hours, name, surname, patronymic, Age);
        }

        /// <summary>
        /// Виртуальный метод для создания ссылочной копии.
        /// </summary>
        /// <returns></returns>
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string ToString()
        {
            return $"(Тип: Рабочий)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Часы работы: {hours}\n\n";
        }

        /// <summary>
        /// Переопределение метода Equals для класса Person
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool flag = false;

            if (obj is Person c)
                flag = c.CompareTo(this) == 0;

            return flag;
        }

        /// <summary>
        /// Переопределение метода GetHashCode для получения хэша
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < surname.Length; ++i)
                hash += (int)surname[i];

            for (int i = 0; i < name.Length; ++i)
                hash += (int)name[i];

            for (int i = 0; i < patronymic.Length; ++i)
                hash += (int)patronymic[i];

            return hash;
        }

    }

    public class Engineer : Person
    {
        public string qualification;
        private int countOfInventions;

        /// <summary>
        /// Свойство для установки количества изобретений
        /// </summary>
        public int CountOfInventions
        {
            get => countOfInventions;
            set
            {
                if (value >= 0)
                    countOfInventions = value;
                else
                    throw new Exception("Ошибка! Значение не может быть отрицательным");
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Engineer() : base()
        {
            qualification = "";
            CountOfInventions = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="countOfInventions"></param>
        /// <param name="qualification"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="patronymic"></param>
        /// <param name="age"></param>
        public Engineer(int countOfInventions, string qualification, string name, string surname, string patronymic, int age) : base(name, surname, patronymic, age)
        {
            this.qualification = qualification;
            this.CountOfInventions = countOfInventions;
        }

        /// <summary>
        /// Переопределение метод вывода инженера.
        /// </summary>
        public override void Show()
        {
            Console.WriteLine($"(Тип: Инженер)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Квалификация: {qualification} \n Количество изобретиний: {countOfInventions}\n\n");
        }

        /// <summary>
        /// Переопределение метода RandomInit для инициализации полей класса случайным образом
        /// </summary>
        public override void RandomInit()
        {
            base.RandomInit();

            qualification = Randomizer.professions[Randomizer.random.Next(0, Randomizer.professions.Count)];
            CountOfInventions = Randomizer.random.Next(0, 99999);
        }

        public override void Init()
        {
            base.Init();

            qualification = VitalikTeamLibrary.VitalikTeam.ReadString();
            CountOfInventions = VitalikTeamLibrary.VitalikTeam.ReadValue();
        }

        /// <summary>
        /// Переопределение метода Clone для клонирования объекта
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new Engineer(CountOfInventions, qualification, name, surname, patronymic, Age);
        }

        /// <summary>
        /// Виртуальный метод для создания ссылочной копии.
        /// </summary>
        /// <returns></returns>
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string ToString()
        {
            return $"(Тип: Инженер)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Квалификация: {qualification} \n Количество изобретиний: {countOfInventions}\n\n";
        }

        /// <summary>
        /// Переопределение метода Equals для класса Person
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool flag = false;

            if (obj is Person c)
                flag = c.CompareTo(this) == 0;

            return flag;
        }

        /// <summary>
        /// Переопределение метода GetHashCode для получения хэша
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < surname.Length; ++i)
                hash += (int)surname[i];

            for (int i = 0; i < name.Length; ++i)
                hash += (int)name[i];

            for (int i = 0; i < patronymic.Length; ++i)
                hash += (int)patronymic[i];

            return hash;
        }

    }

    public class Adminstartor : Person
    {
        private int countOfSubordinates;
        /// <summary>
        /// Свойство для установки количества подчинённых
        /// </summary>
        public int CountOfSubordinates
        {
            get => countOfSubordinates;
            set
            {
                if (value >= 0)
                    countOfSubordinates = value;
                else
                    throw new Exception("Ошибка! Значение не может быть отрицательным");
            }
        }

        private int efficiency;
        /// <summary>
        /// Свойство для установки эффективности
        /// </summary>
        public int Efficiency
        {
            get => efficiency;
            set
            {
                if (value >= 0 && value <= 10)
                    efficiency = value;
                else
                    throw new Exception("Ошибка! Эффективность должна быть от 0 до 10");
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Adminstartor() : base()
        {
            countOfSubordinates = 0;
            countOfSubordinates = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="efficiency"></param>
        /// <param name="countOfSubordinates"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="patronymic"></param>
        /// <param name="age"></param>
        public Adminstartor(int efficiency, int countOfSubordinates, string name, string surname, string patronymic, int age) : base(name, surname, patronymic, age)
        {
            this.Efficiency = efficiency;
            this.CountOfSubordinates = countOfSubordinates;
        }

        /// <summary>
        /// Переопределение метод вывода администрации.
        /// </summary>
        public override void Show()
        {
            Console.WriteLine($"(Тип: Администрация)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Эффективность: {efficiency} \n Количество подчинённых: {countOfSubordinates} \n\n");
        }

        /// <summary>
        /// Переопределение метода RandomInit для инициализации полей класса случайным образом
        /// </summary>
        public override void RandomInit()
        {
            base.RandomInit();

            CountOfSubordinates = Randomizer.random.Next(0, 5000);
            Efficiency = Randomizer.random.Next(0, 11);
        }

        public override void Init()
        {
            base.Init();

            CountOfSubordinates = VitalikTeamLibrary.VitalikTeam.ReadValue();
            Efficiency = VitalikTeamLibrary.VitalikTeam.ReadValue();
        }

        /// <summary>
        /// Переопределение метода Clone для клонирования объекта
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new Adminstartor(Efficiency, CountOfSubordinates, name, surname, patronymic, Age);
        }

        /// <summary>
        /// Виртуальный метод для создания ссылочной копии.
        /// </summary>
        /// <returns></returns>
        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Переопределение метода ToString
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override string ToString()
        {
            return $"(Тип: Администрация)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Эффективность: {efficiency} \n Количество подчинённых: {countOfSubordinates} \n\n";
        }

        /// <summary>
        /// Переопределение метода Equals для класса Person
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool flag = false;

            if (obj is Person c)
                flag = c.CompareTo(this) == 0;

            return flag;
        }

        /// <summary>
        /// Переопределение метода GetHashCode для получения хэша
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < surname.Length; ++i)
                hash += (int)surname[i];

            for (int i = 0; i < name.Length; ++i)
                hash += (int)name[i];

            for (int i = 0; i < patronymic.Length; ++i)
                hash += (int)patronymic[i];

            return hash;
        }

    }

}
