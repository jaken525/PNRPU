#include <iostream>
#include <fstream>
#include <string>
#include <stdio.h>

using namespace std;

void merge(int* a, int n)
{
    int mid = n / 2;
    if (n % 2 == 1)
        mid++;

    int h = 1;
    int* c = new int[n];
    int step;

    while (h < n)
    {
        step = h;

        int i = 0;
        int j = mid;
        int k = 0;

        while (step <= mid)
        {
            while ((i < step) && (j < n) && (j < (mid + step)))
                if (a[i] < a[j])
                {
                    c[k] = a[i];
                    i++;
                    k++;
                }
                else 
                {
                    c[k] = a[j];
                    j++;
                    k++;
                }
            while (i < step)
            {
                c[k] = a[i];
                i++;
                k++;
            }
            while ((j < (mid + step)) && (j < n))
            {
                c[k] = a[j];
                j++;
                k++;
            }
            step += + h;
        }
        h *= 2;

        for (i = 0; i < n; i++)
            a[i] = c[i];
    }
}

int Series(string path1, string path2) {
    ifstream readf(path1);
    ofstream writef(path2);
    string temp, cur;
    int itemp, icur, counter = 0;
    if (!readf.is_open() || !writef.is_open()) { cout << "Error" << endl; }
    else {
        readf >> cur;
        writef << cur << "\n";
        temp = cur;
        while (true) {
            readf >> cur;
            if (readf.eof()) {
                writef << "/";
                counter++;
                return counter;
            }
            itemp = stoi(temp);
            icur = stoi(cur);
            if (itemp <= icur) writef << cur << "\n";
            else {
                writef << "/" << "\n" << cur << "\n";
                counter++;
            }
            temp = cur;
        }
    }
    readf.close();
    writef.close();
}

void Fibonacci(string path1, string path2, string path3, int counter) {
    ifstream f2(path2);
    ofstream f1(path1), f3(path3);
    string cur;
    int max_series = 1, temp, min_series = 1;
    if (!f1.is_open() || !f2.is_open() || !f3.is_open()) { cout << "Error" << endl; }
    else {
        while ((min_series + max_series) < counter) {
            temp = max_series;
            max_series += min_series;
            min_series = temp;
        }
        f2 >> cur;
        int left_series = counter - min_series, add_series = (max_series + min_series) - counter;
        while (min_series > 0) {
            while (cur != "/") {
                f1 << cur << "\n";
                f2 >> cur;
            }
            f1 << "/" << "\n";
            f2 >> cur;
            min_series--;
        }
        while (left_series > 0) {
            while (cur != "/") {
                f3 << cur << "\n";
                f2 >> cur;
            }
            f3 << "/" << "\n";
            f2 >> cur;
            left_series--;
        }
        for (int i = 0; i < add_series; i++) {
            f3 << "/" << "\n";
        }
    }
    f1.close();
    f2.close();
    f3.close();
}

void MergeUntilEmpty(string path1, string path2, string path3) {
    int num = Series(path1, path2);
    if (num == 1) return;
    Fibonacci(path1, path2, path3, num);
    ifstream f1(path1), f3(path3);
    ofstream f2(path2);
    string temp1, temp2;
    int itemp1, itemp2;
    if (!f1.is_open() || !f2.is_open() || !f3.is_open()) { cout << "Error" << endl; }
    else {
        while (!(f1.eof())) {
            f1 >> temp1;
            f3 >> temp2;
            while (temp1 != "/" || temp2 != "/") 
            {
                if (temp1 == "/") 
                {
                    f2 << temp2 << "\n";
                    f3 >> temp2;
                }
                else if (temp2 == "/") 
                {
                    f2 << temp1 << "\n";
                    f1 >> temp1;
                }
                else 
                {
                    itemp1 = stoi(temp1);
                    itemp2 = stoi(temp2);
                    if (itemp1 <= itemp2) 
                    {
                        f2 << temp1 << "\n";
                        f1 >> temp1;
                    }
                    else 
                    {
                        f2 << temp2 << "\n";
                        f3 >> temp2;
                    }
                }
            }
        }
    }
    f1.close();
    f3.close();
    f2.close();
    swap(path1, path2);
    MergeUntilEmpty(path1, path2, path3);
}

void Merge(int* A, int first, int last)
{
    int middle, start, final, j;
    int* mas = new int[100];
    middle = (first + last) / 2;
    start = first;
    final = middle + 1;

    for (j = first; j <= last; j++)
        if ((start <= middle) && ((final > last) || (A[start] < A[final])))
        {
            mas[j] = A[start];
            start++;
        }
        else
        {
            mas[j] = A[final];
            final++;
        }

    for (j = first; j <= last; j++)
        A[j] = mas[j];
    delete[]mas;
};

void Shell(int A[], int n)
{
    int c;
    int d = n;
    d = d / 2;
    while (d > 0)
    {
        for (int i = 0; i < n - d; i++)
        {
            int j = i;
            while (j >= 0 && A[j] > A[j + d])
            {
                c = A[j];
                A[j] = A[j + d];
                A[j + d] = c;
                j--;
            }
        }
        d = d / 2;
    }

    for (int i = 0; i < n; i++)
        cout << A[i] << " ";
}

void MergeSort(int* A, int first, int last)
{
    {
        if (first < last)
        {
            MergeSort(A, first, (first + last) / 2);
            MergeSort(A, (first + last) / 2 + 1, last);
            Merge(A, first, last);
        }
    }
}

int findMax(int arr[], int n)
{
    int i, max = arr[0], cnt = 0;
    for (i = 1; i < n; i++)
        if (arr[i] > max)
            max = arr[i];

    while (max > 0)
    {
        cnt++;
        max = max / 10;
    }

    return cnt;
}

void bucketSort(int arr[], int* bucket[], int n)
{
    static int i, j[10], k, l, d = 1;
    int c;
    c = findMax(arr, n);

    for (int m = 0; m < c; m++)
    {
        for (i = 0; i < 10; i++)
            j[i] = 0;

        for (i = 0; i < n; i++)
        {
            k = (arr[i] / d) % 10;
            bucket[k][j[k]] = arr[i];
            j[k]++;
        }

        l = 0;
        for (i = 0; i < 10; i++)
            for (k = 0; k < j[i]; k++)
            {
                arr[l] = bucket[i][k];
                l++;
            }

        d *= 10;
    }
}

void countSort(int arr[], int n) 
{

    int arr1[10];
    int count_arr[10];
    int x = arr[0];

    for (int i = 1; i < n; i++)
        if (arr[i] > x)
            x = arr[i];

    for (int i = 0; i <= x; ++i)
        count_arr[i] = 0;

    for (int i = 0; i < n; i++)
        count_arr[arr[i]]++;

    for (int i = 1; i <= x; i++)
        count_arr[i] += count_arr[i - 1];

    for (int i = n - 1; i >= 0; i--) 
    {
        arr1[count_arr[arr[i]] - 1] = arr[i];
        count_arr[arr[i]]--;
    }

    for (int i = 0; i < n; i++) 
        arr[i] = arr1[i];

}

void display(int arr[], int n) 
{
    for (int i = 0; i < n; i++)
        cout << arr[i] << " ";
    cout << endl;
}

int partition(int a[], int start, int end)
{
    int pivot = a[end];
    int pIndex = start;

    for (int i = start; i < end; i++)
        if (a[i] <= pivot)
        {
            swap(a[i], a[pIndex]);
            pIndex++;
        }

    swap(a[pIndex], a[end]);

    return pIndex;
}

void quicksort(int a[], int start, int end)
{
    if (start >= end) 
        return;

    int pivot = partition(a, start, end);

    quicksort(a, start, pivot - 1);
    quicksort(a, pivot + 1, end);
}


int main()
{
    int a;
    cin >> a;

    switch (a)
    {

        //быстрая
    case 0: 
    {
        int a[] = { 9, -3, 5, 2, 6, 8, -6, 1, 3 };
        int n = sizeof(a) / sizeof(a[0]);

        quicksort(a, 0, n - 1);

        for (int i = 0; i < n; i++)
            cout << a[i] << " ";

        break; 
    }

        // подсчётом
    case 1: 
    {
        int arr[] = { 4, 2, 2, 8, 3, 3, 1 };
        int n = sizeof(arr) / sizeof(arr[0]);
        countSort(arr, n);
        display(arr, n);
        break;
    }

        // блочная
    case 2:
    {
        int n, * arr, i;
        int* bucket[10];
        cin >> n;

        arr = new int[n + 1];
        for (i = 0; i < 10; i++)
            bucket[i] = new int[n];

        for (i = 0; i < n; i++)
            cin >> arr[i];

        bucketSort(arr, bucket, n);

        for (i = 0; i < n; i++)
            cout << arr[i] << " ";
        break;
    }

    // слиянием
    case 3:
    {
        int n = 5;
        int* A = new int[100];
        for (int i = 1; i <= n; i++)
             cin >> A[i];

        MergeSort(A, 1, n);
        for (int i = 1; i <= n; i++)
            cout << A[i] << " ";

        delete[]A;
        break;
    }
    
    // шелла
    case 4:
    {
        int n;
        cin >> n;
        int* A = new int[n];
        for (int i = 0; i < n; i++)
            cin >> A[i];

        Shell(A, n);
        delete[] A;
        break;
    }

    // внешние
    case 5:
    {
        srand(time(NULL));
        int size, current;
        string firstfile = "1.txt", secondfile = "2.txt", thirdfile = "3.txt", temp;
        ofstream fir;
        ifstream res;
        cout << "Size of an array: ";
        cin >> size;
        cout << "unsorted data" << endl;

        fir.open(firstfile);
        for (int i = 0; i < size; i++) {
            current = rand() % 100;
            cout << current << " ";
            fir << current << "\n";
        }
        fir.close();
        cout << endl << endl;

        MergeUntilEmpty(firstfile, secondfile, thirdfile);
        cout << "sorted data" << endl;

        res.open(firstfile);
        for (int i = 0; i < size; i++) {
            res >> temp;
            cout << temp << " ";
        }
        res.close();

        cout << endl;
        break;
    }

    // двухфазная
    case 6:
    {
        int n;
        cin >> n;

        int* a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = rand() % 125;
            cout << a[i] << " ";
        }
        cout << endl;
        merge(a, n);

        for (int i = 0; i < n; i++)
            cout << a[i] << " ";

        delete[] a;

        break;
    }
    }
}
