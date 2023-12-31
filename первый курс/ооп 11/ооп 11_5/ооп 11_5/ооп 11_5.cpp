#include "Money.h" 
#include <iostream>
#include <stack>
#include <vector>
#include "Vector.h"

using namespace std;

int main()
{
	Vector<Money> v(3);
	v.Print();

	cout << "Min: " << v.Min() << endl;

	v.Add();
	v.Print();

	cout << "Remove pos:";
	int pos;
	cin >> pos;

	v.Del(pos);
	v.Print();

	cout << "Summ of min, max and element: " << endl;
	v.Summa();
	v.Print();
}