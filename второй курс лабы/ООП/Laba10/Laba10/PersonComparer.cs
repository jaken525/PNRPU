using System.Collections;

namespace VitalikTeamLibraries
{
    public class PersonComparer : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            int b = 0;

            if (obj1 is RandomForTests c)
                b = c.CompareTo(obj2);
            else if (obj1 as Person is not null)
            {
                Person f = obj1 as Person;

                b = f.CompareTo(obj2);
            }

            return b;
        }

    }

}
