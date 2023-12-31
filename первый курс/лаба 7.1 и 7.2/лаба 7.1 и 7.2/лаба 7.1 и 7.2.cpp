/*// 7.2
#include <iostream>

using namespace std;

void square()
{
	int ax, ay, bx, by, cx, cy;
	cin >> ax >> ay >> bx >> by >> cx >> cy;

	double p1 = sqrt((bx - ax) * (bx - ax) + (by - ay) * (by - ay));
	double p2 = sqrt((bx - cx) * (bx - cx) + (by - cy) * (by - cy));
	double p3 = sqrt((cx - ax) * (cx - ax) + (cy - ay) * (cy - ay));
	double p = (p1 + p2 + p3) / 2;

	cout << sqrt(p * (p - p1) * (p - p2) * (p - p3)) << endl;
}
float square1(int k, ...)
{
	int* p = &k;
	float length1 = sqrt(*(p + 2) * *(p + 2) + *(p + 4) * *(p + 4));
	float length2 = sqrt(*(p + 6) * *(p + 6) + *(p + 8) * *(p + 8));
	float length3 = sqrt(*(p + 10) * *(p + 10) + *(p + 12) * *(p + 12));
	float buff = (length1 + length2 + length3) / 2;

	return (sqrt(buff * (buff - length1) * (buff - length2) * (buff - length3)));
}
int point_vector(int arr_x[], int arr_y[], int arr_point_x[], int arr_point_y[], int n)
{
	int sign = 1;
	for (int i = 0; i < n; i++)
		if (i == n - 1)
		{
			arr_x[i] = arr_point_x[0] - arr_point_x[i];
			arr_y[i] = arr_point_y[0] - arr_point_y[i];
		}
		else
		{
			arr_x[i] = arr_point_x[i] - arr_point_x[i + 1];
			arr_y[i] = arr_point_y[i] - arr_point_y[i + 1];
		}

	for (int i = 0; i < n; i++)
		if (i == n - 1)
			sign *= arr_x[i] * arr_y[0] - arr_y[i] * arr_x[0];
		else
			sign *= arr_x[i] * arr_y[i + 1] - arr_y[i] * arr_x[i + 1];

	return sign;
}
int main()
{
	int n = 0;
	cin >> n;

	int* arr_point_x = new int[n];
	int* arr_point_y = new int[n];
	int* arr_x = new int[n];
	int* arr_y = new int[n];
	float max = 0;
	int i_buff = 0;
	int j_buff = 0;
	int buff1 = 0;
	int buff2 = 0;

	for (int i = 0; i < n; i++)
		cin >> arr_point_y[i] >> arr_point_x[i];

	if (point_vector(arr_x, arr_y, arr_point_x, arr_point_y, n) < 0) 
	{
		cout << "ERROR" << endl;
		return 0;
	}

	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
		{
			int e = arr_point_x[i] - arr_point_x[j];
			int r = arr_point_y[i] - arr_point_y[j];
			double length = sqrt(e * e + r * r);
			if (length > max)
			{
				max = length;
				i_buff = i;
				j_buff = j;
				buff1 = e;
				buff2 = r;
			}
		}

	if (i_buff == n - 1)
	{
		unsigned int p_x1 = arr_point_x[i_buff] - arr_point_x[0];
		unsigned int p_y1 = arr_point_y[i_buff] - arr_point_y[0];
		unsigned int p_x2 = arr_point_x[0] - arr_point_x[j_buff];
		unsigned int p_y2 = arr_point_y[0] - arr_point_y[j_buff];
		max = square1(6, p_x1, p_y1, p_x2, p_y2, buff1, buff2);
	}
	else
	{
		unsigned int p_x1 = arr_point_x[i_buff] - arr_point_x[i_buff + 1];
		unsigned int p_y1 = arr_point_y[i_buff] - arr_point_y[i_buff + 1];
		unsigned int p_x2 = arr_point_x[i_buff + 1] - arr_point_x[j_buff];
		unsigned int p_y2 = arr_point_y[i_buff + 1] - arr_point_y[j_buff];
		max = square1(6, p_x1, p_y1, p_x2, p_y2, buff1, buff2);
	}

	cout << "S and max: " << max << endl;
	square();
	return 0;
}*/
// 7.1
#include <iostream>
#include <array>

using namespace std;

size_t foo(string str) 
{
	return str.length();
}

size_t foo(int arr[], int size) 
{
	double a = 0;
	double sr;

	for (int i = 0; i < size; i++)
		a += arr[i];

	sr = a / size;
	return sr;
}

int main(void)
{
	cout << foo("dsfn dkjsfnjdsn jndsfksd kdf") << endl;

	int arr[] = { 1, 2, 3, 4, 5, 6 };
	int _size = size(arr);
	cout << foo(arr, _size) << endl;

	return 0;
}

