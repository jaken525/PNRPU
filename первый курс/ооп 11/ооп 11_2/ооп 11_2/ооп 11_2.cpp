#include <vector>
#include "Header.h"
#include <iostream>

using namespace std;

typedef vector<Money> Vec;

Vec make_vector(int n)
{
	Vec v;

	for (int i = 0; i < n; i++)
	{
		Money t;
		cin >> t;
		v.push_back(t);
	}

	return v;
}

void print_vector(Vec v)
{
	for (int i = 0; i < v.size(); i++)
		cout << v[i] << " ";
	cout << endl;
}
Money srednee(Vec v)
{
	int m = 0;
	int s = 0;

	for (int i = 0; i < v.size(); i++)
	{
		m += v[i].get_rub();
		s += v[i].get_kop();
	}
	int n = v.size();
	Money p;
	p.set_rub(m / n);
	p.set_kop(s / n);
	return p;
}
void add_vector(Vec& v, Money el, int pos)
{
	v.insert(v.begin() + pos, el);
}

int max(Vec v)
{
	Money m = v[0];
	int n = 0;
	for (int i = 0; i < v.size(); i++)
		if (m < v[i])
		{
			m = v[i];
			n = i;
		}

	return n;
}

void del_vector(Vec& v, int pos)
{
	v.erase(v.begin() + pos);
}

int min(Vec v)
{
	Money m = v[0];
	int	n = 0;
	for (int i = 0; i < v.size(); i++)
		if (m > v[i])
		{
			m = v[i];
			n = i;
		}

	return n;
}
void delenie(Vec& v)
{
	int m = min(v);
	for (int i = 0; i < v.size(); i++)
		v[i] = v[i] / v[m];
}

void main()
{
	try
	{
		vector<Money> v;
		vector<Money>::iterator vi = v.begin();

		int n;
		cout << "Kolvo elementov: ";
		cin >> n;

		v = make_vector(n);
		print_vector(v);

		Money el = srednee(v);

		cout << "middle number pos: ";
		int pos;
		cin >> pos;

		if (pos > v.size())
			throw 1;

		add_vector(v, el, pos);
		print_vector(v);

		cout << "Max Element: " << v[max(v)] << "\n";
		del_vector(v, max(v));

		delenie(v);
		print_vector(v);
	}
	catch (int)
	{
		cout << "error!";
	}
}