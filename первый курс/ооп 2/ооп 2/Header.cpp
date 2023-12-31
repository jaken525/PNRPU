#include <iostream>
#include "Header.h"

using namespace std;

cunt::cunt()
{
	first = 0;
	second = 0;
}

cunt::cunt(double a, double b)
{
	this->first = a;
	this->second = b;
}

cunt::~cunt()
{
	this->first = 0;
	this->first = 0;
}

void cunt::setfirst(double x)
{
	this->first = x;
}

void cunt::setsecond(double x)
{
	this->second = x;
}

double cunt::root(double x)
{
	return first * x + second;
}