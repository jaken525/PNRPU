#pragma once
#include <iostream>
#include <fstream>

using namespace std;

const int MAX_SIZE = 20;

class Many
{
public:
	int size;
	int* beg;

	Many() 
	{ 
		size = 0;
		beg = 0;
	}
	Many(int s);
	Many(int s, int* mas);
	Many(const Many& v);
	~Many();

	const Many& operator=(const Many& v);
	int operator[](int i);

	Many operator+(int a);
	Many operator--();

	friend ostream& operator<<(ostream& out, const Many& v);
	friend istream& operator>>(istream& in, const Many& v);
};