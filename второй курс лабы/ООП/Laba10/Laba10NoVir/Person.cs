using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VitalikTeamLibraries
{
    internal class Person
    {
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
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="patronymic"></param>
        /// <param name="age"></param>
        public Person(string name, string surname, string patronymic, int age)
        {
            this.Age = age;

            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
        }

        /// <summary>
        /// Виртуальный метод вывода персоны.
        /// </summary>
        public void Show()
        {
            Console.WriteLine($"(Тип: Персона)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {age}\n\n");
        }
    }

    internal class Employee : Person
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
        public void Show()
        {
            Console.WriteLine($"(Тип: Рабочий)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Часы работы: {hours}\n\n");
        }

    }

    internal class Engineer : Person
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
        public void Show()
        {
            Console.WriteLine($"(Тип: Инженер)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Квалификация: {qualification} \n Количество изобретиний: {countOfInventions}\n\n");
        }

    }

    internal class Adminstartor : Person
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
        public void Show()
        {
            Console.WriteLine($"(Тип: Администрация)\n Имя: {name} \n Фамилия: {surname} \n Отчество: {patronymic} \n Возраст: {Age} \n Эффективность: {efficiency} \n Количество подчинённых: {countOfSubordinates} \n\n");
        }
    
    }

}
