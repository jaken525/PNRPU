using System;
using System.Text;

namespace WinForm.Persons
{
    enum PersonRule
    {
        minAge = 1,
        maxAge = 200,
        minIdSymbolInAscii = 48,
        maxIdSymbolInAscii = 58,
        minDescSymbolInAscii = 65,
        maxDescSymbolInAscii = 90,
        lengthOfID = 10,
        lengthOfDescription = 100,
    }


    [Serializable]
    public class Person: IComparable
    {
        public string fullName { get; set; } = "";
        public string Description { get; set; } = "";

        private int age;

        public int Age
        {
            get => age;
            set
            {
                if (value >= 0)
                    age = value;
                else
                    throw new Exception("Error! Age cannot be negative");
            }
        }

        public Person() 
        {

        }

        public Person(string fullName, int age, string Description)
        {
            this.Age = age;

            if (fullName == "")
                this.fullName = "Anonymous";
            else
                this.fullName = fullName;
            

            if (Description == "")
                this.Description = "Not description";
            else
                this.Description = Description;   
        }

        public Person(Random random)
        {
            this.fullName = Randomizer.RandomNames[Randomizer.random.Next(0, Randomizer.RandomNames.Count)];
            Age = random.Next(1, 200);

            StringBuilder desc = new StringBuilder();
            for (int i = 0; i < (int)PersonRule.lengthOfDescription; ++i)
                desc.Append((char)(random.Next((int)PersonRule.minDescSymbolInAscii, (int)PersonRule.maxDescSymbolInAscii)));

            this.Description = desc.ToString();
        }

        public int CompareTo(object obj)
        {
            int a = 0;
            if (obj is Person b)
                if (Age != b.Age || fullName != b.fullName || Description != b.Description)
                    a = Convert.ToInt64(Age) >= Convert.ToInt64(b.Age) ? 1 : -1;

            return a;
        }

        public override bool Equals(object? obj)
        {
            bool isEquals = false;
            if(obj is Person person)
                isEquals = person.Age == Age && person.Description == Description && person.fullName == fullName;

            return isEquals;
        }

        public override string ToString()
        {
            return $"| Name = {fullName} | Age = {Age} | Description = {Description} |";
        }
    }
}
