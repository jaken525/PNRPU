#include "Vector.h"
#include <iostream>
#include "Money.h"

using namespace std;

void main()
{
    Vector<Money>vec(2);

    vec.Print();

    Money s = vec.Srednee();

    cout << "Middle = " << s << endl;
    cout << "Pos: ";

    int p;
    cin >> p;

    p = vec.Min();

    vec.Add(s, p);
    vec.Print();

    p = vec.Max();

    vec.Del(p);
    vec.Print();
    vec.Delenie();
    vec.Print();
}
