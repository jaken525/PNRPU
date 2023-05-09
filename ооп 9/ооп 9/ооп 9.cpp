#include "Many.h"
#include "Error.h"
#include <iostream>

using namespace std;

int main()
{
	try
	{
		Many x(2);
		Many y;
		cout << x;
		cout << "Nomer" << endl;
		int i;
		cin >> i;
		cout << x[i] << endl;
		y = x + 3;
		cout << y;
		--x;
		cout << x;
		--x;
		cout << x;
		--x;
	}
	catch (Error& e)
	{
		e.what();
	}

	return 0;
}