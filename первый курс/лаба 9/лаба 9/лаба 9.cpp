#include <fstream>
#include <iostream>
#include <string>
#include <vector>

using namespace std;

const int sogls[20] = { 66, 67, 68, 70, 71, 72, 74, 75, 76, 77, 78, 80, 81, 82, 83, 84, 86, 87, 88, 90 };

int GetCountSogl(string word) 
{
    int cunt = 0;

    for (int i = 0; i < word.size(); i++)
        for(int j = 0; j < size(sogls); j++)
            if (word[i] == sogls[j] || word[i] == sogls[j] + 32)
                cunt++;

    return cunt;
}

bool WordCounter(string line) 
{
    string s = "";
    vector<string> words;

    s += line[0];
    for (int i = 1; i < line.size(); i++) 
        if (i == line.size() - 1)
        {
            s += line[i];
            words.push_back(s);
            s = "";
        }
        else 
            if ((line[i - 1] != ' ' && line[i] == ' '))
            {
                words.push_back(s);
                s = "";
            }
            else
                s += line[i];

    for (int i = 1; i < words.size(); i++)
        if (words[i] == words[0])
            return true;

    return false;
}

int main()
{
    ifstream f1("f1.txt");
    ofstream f2("f2.txt");

    string line;

    while (getline(f1, line))
        if (WordCounter(line))
            f2 << endl << line;

    f2.close();
    f1.close();

    ifstream f("f2.txt");

    string str;
    while (getline(f, str)) {}

    cout << "Sogls: " << GetCountSogl(str) << endl;

    f.close();

    return 0;
}
