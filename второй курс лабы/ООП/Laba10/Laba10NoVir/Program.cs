using System.Diagnostics.Metrics;
using System.Reflection;
using System.Windows.Markup;
using VitalikTeamLibraries;

namespace Laba10
{ 
    public class Program
    {
        static void Main(string[] args)
        { 
            Person person1, person2, person3, person4;

            person1 = new Person("Алексей", "Антипьев", "Андреевич", 28);
            person2 = new Employee(629, "Виталий", "Степанов", "Сергеевич", 32);
            person3 = new Engineer(3, "Программист", "Виталий", "Поважный", "Евгеньевич", 18);
            person4 = new Adminstartor(9, 134, "Ростислав", "Лавров", "Александрович", 45);

            person1.Show();
            person2.Show();
            person3.Show();
            person4.Show();

        }

    }

}