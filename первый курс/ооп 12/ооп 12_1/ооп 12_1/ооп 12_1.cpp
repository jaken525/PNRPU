#include <iostream>
#include <set>

using namespace std;

typedef set<double> TSet;
set<double>::iterator it;

TSet make_set(int n)
{
	TSet m;
	double a;

	for (int i = 0; i < n; i++)
	{
		cout << "Number: ";
		cin >> a;
		m.insert(a);
	}

	return m;
}

void print_set(TSet m)
{
	for (it = m.begin(); it != m.end(); it++)
		cout << *it << "  ";
}

TSet erase_set(TSet m, double el)
{
	for (it = m.begin(); it != m.end();)
	{
		double n = *it;
		if (el == n)
		{
			cout << *it << endl;
			m.erase(it++);
		}
		else
			++it;
	}

	return m;
}

double Min_set(TSet m)
{
	double min, temp;
	it = m.begin();
	min = *it;

	for (it = m.begin(); it != m.end(); ++it)
	{
		temp = *it;
		if (min > temp)
			min = temp;
	}

	return min;
}

double Max_set(TSet m)
{
	double max, temp;
	it = m.begin();
	max = *it;

	for (it = m.begin(); it != m.end(); ++it)
	{
		temp = *it;
		if (max < temp)
			max = temp;
	}

	return max;
}

TSet zadanie(TSet m, double min, double max)
{
	for (it = m.begin(); it != m.end(); ++it)
	{
		double h = *it + min - max;
		cout << h << "  ";
	}

	return m;
}

void main()
{
	int n;
	cout << "Number: ";
	cin >> n;

	TSet m = make_set(n);
	print_set(m);

	double d;
	cout << "Whats to remove: ";
	cin >> d;

	TSet j = erase_set(m, d);
	print_set(j);
	double h = Min_set(j);
	double u;

	cout << "Add: " << endl;
	cin >> u;

	j.insert(u);
	print_set(j);

	cout << endl;

	double g = Max_set(j);

	cout << "Add max and min: " << endl;
	zadanie(j, h, g);
}