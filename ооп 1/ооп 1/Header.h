#include <iostream>
using namespace std;

class Country
{
	string capital;
	int population;
	double S;

public:
	Country();
	Country(string c, int p, double s);
	Country(Country& t);
	~Country();

	string getCapital();
	int getPopulation();
	double getS();
	void show();
	void setCap(string c);
	void setPop(int c);
	void setS(double c);
};
