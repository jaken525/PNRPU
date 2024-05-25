using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Persons
{
    public class PersonComparer : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            int b = 0;
            if (obj1 as Person is not null)
            {
                Person f = obj1 as Person;
                b = f.CompareTo(obj2);
            }
            return b;
        }
    }
}
