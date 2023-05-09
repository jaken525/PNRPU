#include <iostream>
#include <vector>
#include <cstdlib>

using namespace std;

typedef vector<float> Vec;

Vec make_vector(int n)
{
	Vec v;
	for (int i = 0; i < n; i++)
		v.push_back(rand() % 100 - 50);

	return v;
}

void print_vector(Vec v)
{
	for (int i = 0; i < v.size(); i++)
		cout << v[i] << " ";
	cout << endl;
}
int srednee(Vec v)
{
	int s = 0;
	for (int i = 0; i < v.size(); i++)
		s += v[i];

	return s / v.size();
}
void add_vector(Vec& v, int el, int pos)
{
	v.insert(v.begin() + pos, el);
}

int max(Vec v)
{
	int m = v[0];
	int	n = 0;
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
	int m = v[0];
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
		vector<float> v;
		vector<float>::iterator vi = v.begin();

		int n;
		cout << "Size: ";
		cin >> n;
		v = make_vector(n);
		print_vector(v);

		int el = srednee(v);

		cout << "Pos: ";
		int pos;
		cin >> pos;

		if (pos > v.size())
			throw 1;

		add_vector(v, el, pos);

		int n_del;
		cout << "Delete: " << endl;
		cin >> n_del;

		del_vector(v, n_del);
		print_vector(v);
	}
	catch (int)
	{
		cout << "error!";
	}
}