﻿// ооп 1
#include <iostream>
#include "Header.h"

using namespace std;

int main()
{
	double a, b, x;
	cin >> a >> b >> x;

	cunt func(a, b);

	if (x != 0)
		cout << func.root(x) << endl;
	else 
		cout << "Err. X cannot be 0" << endl;

	cin >> a >> b >> x;

	cunt func1;

	func1.setfirst(a);
	func1.setsecond(b);

	if (x != 0)
		cout << func.root(x) << endl;
	else
		cout << "Err. X cannot be 0" << endl;

	return 0;
}
