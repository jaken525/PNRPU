#include <iostream>
#include "Many.h"
#include "Money.h"

using namespace std;

void main()
{
	int n;
	cout << "Number: ";
	cin >> n;
	Many <Money> v(n);

	v.Print();
	Money t = v.Srednee();
	cout << "Middle: " << t << endl;
	cout << "Adding Middle" << endl;
	cout << "Pos: ";

	int pos;
	cin >> pos;
	v.Add(pos, t);
	v.Print();

	cout << "Delete max: " << endl;
	v.Del();
	v.Print();

	cout << "Division on min: " << endl;
	v.Delenie();
	v.Print();

}