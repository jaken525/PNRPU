#include "Many.h"
#include "Error.h"
#include <iostream>
#include <fstream>

using namespace std;

Many::Many(int s)
{
	if (s > MAX_SIZE) 
		throw MaxSizeError();

	size = s;
	beg = new int[s];

	for (int i = 0; i < size; i++)
		beg[i] = 0;
}

Many::Many(const Many& v)
{
	size = v.size;
	beg = new int[size];

	for (int i = 0; i < size; i++)
		beg[i] = v.beg[i];
}

Many::~Many()
{
	if (beg != 0) 
		delete[] beg;
}

Many::Many(int s, int* mas)
{
	size = s;
	beg = new int[size];

	for (int i = 0; i < size; i++)
		beg[i] = mas[i];
}

const Many& Many::operator =(const Many& v)
{
	if (this == &v)
		return *this;
	if (beg != 0) 
		delete[] beg;

	size = v.size;
	beg = new int[size];

	for (int i = 0; i < size; i++)
		beg[i] = v.beg[i];

	return *this;
}

ostream& operator<<(ostream& out, const Many& v)
{
	if (v.size == 0) 
		out << "Empty\n";
	else
	{
		for (int i = 0; i < v.size; i++)
			out << v.beg[i] << " ";
		out << endl;
	}
	return out;
}

istream& operator >>(istream& in, Many& v)
{
	for (int i = 0; i < v.size; i++)
	{
		cout << ">";
		in >> v.beg[i];
	}
	return in;
}

int Many::operator [](int i)
{
	if (i < 0)
		throw IndexError1();
	if (i >= size)
		throw IndexError2();

	return beg[i];
}

Many Many::operator +(int a)
{
	if (size + 1 == MAX_SIZE) 
		throw MaxSizeError();

	Many temp(size + 1, beg);
	temp.beg[size] = a;

	return temp;
}

Many Many::operator --()
{
	if (size == 0) 
		throw EmptySizeError();

	if (size == 1)
	{
		size = 0;
		delete[]beg;
		beg = 0;
		return *this;
	};

	Many temp(size, beg);
	delete[]beg;
	size--;
	beg = new int[size];

	for (int i = 0; i < size; i++)
		beg[i] = temp.beg[i];

	return*this;
}