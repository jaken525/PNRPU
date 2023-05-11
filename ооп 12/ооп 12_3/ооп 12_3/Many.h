#pragma once
#include <iostream>
#include <map>

using namespace std;

template <class T>
class Many
{
public:
	Many(void);
	Many(int n);

	void Print();
	void Add(int n, T el);
	void Del();
	void Delenie();
	int Max();
	int Min();

	T Srednee();

private:
	int size;
	map<int, T> v;
};

template <class T>
Many<T>::Many()
{
	size = 0;
}

template <class T>
Many<T>::Many(int n)
{
	T a;
	for (int i = 0; i < n; i++)
	{
		cin >> a;
		v[i] = a;
	}
	size = v.size();
}

template <class T>
void Many<T>::Print()
{
	for (int i = 0; i < v.size(); i++)

		cout << i << "-" << v[i] << " " << endl;
}

template <class T>
T Many<T>::Srednee()
{
	T s = v[0];
	for (int i = 0; i < v.size(); i++)
	{
		s = s + v[i];
	}

	int n = v.size();
	return s / n;
}

template <class T>
void Many<T>::Add(int n, T el)
{
	v.insert(make_pair(n, el));
}

template <class T>
int Many<T>::Max()
{
	typename map<int, T>::iterator i = v.begin();
	int nom = 0;
	int k = 0;
	T m = (*i).second;
	while (i != v.end())
	{
		if (m < (*i).second)
		{
			m = (*i).second;
			nom = k;
		}
		i++;
		k++;
	}
	return nom;
}

template <class T>
void Many<T>::Del()
{
	int max = Max();
	cout << "max=" << v[max] << " nom=" << max << endl;
	v.erase(max);
}

template <class T>
int Many<T>::Min()
{
	typename map<int, T>::iterator i = v.begin();
	int nom = 0;
	int k = 0;
	T m = (*i).second;
	while (i != v.end())
	{
		if ((*i).second.get_rub() != 0 && (*i).second.get_kop() != 0)
		{
			if (m > (*i).second)
				m = (*i).second;
			nom = k;
		}

		i++;
		k++;
	}
	return nom;
}


template <class T>
void Many<T>::Delenie()
{
	T m = v[Min()];
	cout << "Min = " << m << endl;
	for (int i = 0; i < v.size(); i++)
		v[i] = v[i] / m;
}