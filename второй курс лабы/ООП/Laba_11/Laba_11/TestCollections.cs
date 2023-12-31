using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalikTeamLibraries;

namespace Laba_11
{
    public class TestCollections
    {
        public List<string> listString = new List<string>();
        public List<Person> listPerson = new List<Person>();

        public Dictionary<string, Employee> dictionaryStringEmployee = new Dictionary<string, Employee>();
        public Dictionary<Person, Employee> dictionaryPersonEmpolyee = new Dictionary<Person, Employee>();

        public void RandomInit(int count)
        {
            for(int i = 0; i < count; ++i)
            {
                Employee employee = new Employee();
                employee.RandomInit();

                while(listPerson.Contains(employee.person))
                    employee.RandomInit();

                listString.Add(employee.ToString());
                listPerson.Add(employee.person);

                dictionaryStringEmployee.Add(employee.ToString(), employee);
                dictionaryPersonEmpolyee.Add(employee.person, employee);
            }

        }

    }

}
