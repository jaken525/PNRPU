#include <iostream>

using namespace std;

int main()
{
    string s;
    string t;

    cin >> s;
    t = "";
    for (int i = s.length() - 1; i >= 0; i--)
        t = t + s[i];

    if (s == t)
        cout << "Yes";
    else
        cout << "No";
    return 0;
}