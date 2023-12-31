#include "Header.h"
#include <iostream>

Sperbank::Sperbank(long r, int k)
{
	ruble = r;
	kop = k;
}

Sperbank::~Sperbank()
{
	ruble = 0;
	kop = 0;
}

void Sperbank::addMoney(long r, int k)
{
	ruble += r;
	kop += k;

	cout << "TTOTTOJIHEHO" << endl;
}

void Sperbank::remMoney(long r, int k)
{
	if (ruble - r > 0)
	{
		kop -= k;
		if (kop < 0)
		{
			ruble--;
			kop += 100;
		}

		cout << "I3bII39EHO!" << endl;
	}
	else
		cout << "TToLLIeJI Haxyu" << endl;
}

void Sperbank::balance()
{
	cout << ruble << "," << kop << endl;
}