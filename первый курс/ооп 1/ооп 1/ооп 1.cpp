//ооп 2
#include <iostream>
#include "Header.h"

using namespace std;

Country CreateCountry() 
{
	string cap;
	int pop;
	double s;

	cin >> cap >> pop >> s;

	Country x(cap, pop, s);

	return x;
}

void printCountry(Country x) 
{
	x.show();
}

int main()
{
	
	Country c;
	c.show();

	Country c1("London", 95746435, 71254.092746);
	c1.show();

	Country c2 = c1;

	c2.setCap("Moskow");
	c2.setPop(32481535);
	c2.setS(11612.5165);

	printCountry(c2);

	c = CreateCountry();
	cout << endl;
	c.show();

	return 0;
}
