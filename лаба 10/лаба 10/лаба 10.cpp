#include <iostream>

using namespace std;

string* DeleteString(string* arr, int num, int size)
{
    string* newArr = new string[size - 1];

    for (int i = 0; i < num - 1; i++)
        newArr[i] = arr[i];

    for (int i = num - 1; i < size - 1; i++)
        newArr[i] = arr[i + 1];

    return newArr;
}

int main()
{
    int n = 0;
    cin >> n;

    string* str = new string[n];
    for (int i = 0; i < n; i++) 
    {
        string line;
        cout << i + 1 << ". ";
        cin >> line;
        str[i] = line;
    }

    int num;
    cin >> num;
    str = DeleteString(str, num, n);

    cout << endl;

    for (int i = 0; i < n - 1; i++)
        cout << i + 1 << ". " << str[i] << endl;

    return 0;
}