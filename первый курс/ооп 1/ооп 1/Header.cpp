#include <iostream>
#include "Header.h"

using namespace std;

Country::Country()
{
	capital = "";
	population = 0;
	S = 0;
}

Country::Country(string c, int p, double s)
{
	capital = c;
	population = p;
	S = s;
}

Country::Country(Country& t)
{
	capital = t.capital;
	population = t.population;
	S = t.S;
}

Country::~Country()
{

}

string Country::getCapital()
{
	return capital;
}

int Country::getPopulation()
{
	return population;
}

double Country::getS()
{
	return S;
}

void Country::setCap(string c) 
{
	this->capital = c;
}

void Country::setPop(int c)
{
	this->population = c;
}

void Country::setS(double c)
{
	this->S = c;
}

void Country::show()
{
	cout << capital << endl;
	cout << population << endl;
	cout << S << endl << endl;
}