#include "Header.h"
#include <iostream>
using namespace std;

SperBank& SperBank::operator=(const SperBank& t)
{
    if (&t == this) return *this;
    rub = t.rub;
    kop = t.kop;
    return *this;
}

SperBank& SperBank::operator++()
{
    int temp = rub + kop / 100;
    temp++;
    rub = temp;
    kop = temp / 100;
    return *this;
}

SperBank SperBank::operator ++(int)
{
    int temp = rub + kop / 100;
    temp++;
    SperBank t(rub, kop);
    rub = temp;
    kop = temp / 100;
    return t;
}

SperBank SperBank::operator+(const SperBank& t)
{
    int temp1 = rub + kop / 100;
    int temp2 = t.rub + t.kop / 100;
    SperBank p;
    p.rub = (temp1 + temp2);
    p.kop = (temp1 + temp2) / 100;
    return p;
}

istream& operator>>(istream& in, SperBank& t)
{
    cout << "rub? "; in >> t.rub;
    cout << "kop? "; in >> t.kop;
    return in;
}

ostream& operator<<(ostream& out, const SperBank& t)
{
    return (out << t.rub << "," << t.kop);
}
