#include <iostream>
#include "Header.h"

using namespace std;

many::many()
{
	array = new int[1];
	array[0] = 0;
	size = 1;
}

many::many(int size)
{
	array = new int [size] {};
	this->size = size;
}

int& many::operator [] (int i)
{
	return array[i];
}

int many::operator () ()
{
	return size;
}
void many::operator ++ (int i)
{
	size++;
	int* new_array = new int[size];

	for (int a = 0; a < size - 1; a++)
		new_array[a] = array[a];

	new_array[size - 1] = 0;
	delete[] array;

	array = new_array;
}
many many::operator + (many& other)
{
	many newmany(this->size + other.size);

	for (int i = 0; i < this->size; i++)
		newmany.array[i] = this->array[i];

	for (int i = 0; i < other.size; i++)
		newmany.array[size + i] = other.array[i];

	return newmany;

}

many::~many()
{
	if (!array)
		delete[] array;
}