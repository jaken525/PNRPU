#include <iostream>
#include "Header.h"
#include "Header1.h"

using namespace std;

Pair::Pair(void)
{
    first = 0;
    second = 0;
}
// деструктор
Pair::~Pair(void)
{
}
// конструктор с параметрами
Pair::Pair(int C, int P)
{
    first = C;
    second = P;
}
// конструктор копирования
Pair::Pair(const Pair& Pair)
{
    first = Pair.first;
    second = Pair.second;
}
// модификаторы
void Pair::Set_first(int C)
{
    first = C;
}

void Pair::Set_second(int P)
{
    second = P;
}
// перегрузка операции присваивания
Pair& Pair::operator=(const Pair& c)
{
    if (&c == this)
        return *this;
    second = c.second;
    first = c.first;
    return *this;
}
// глобальная функция для ввода
istream& operator>>(istream& in, Pair& c)
{
    cout << "\nsecond:";
    in >> c.second;
    cout << "\nfirst:";
    in >> c.first;
    return in;
}
// глобальная функция для вывода
ostream& operator<<(ostream& out, const Pair& c)
{
    out << "\nfirst : " << c.first;
    out << "\nsecond : " << c.second;
    out << "\n";
    return out;
}
_Long::_Long(void) : Pair()
{
    gruz = 0;
}
// дестрктор
_Long::~_Long(void)
{
}
// конструктор с параметрами
_Long::_Long(int C, int P, double G) : Pair(C, P)
{
    gruz = G;
}
// конструктор копирования
_Long::_Long(const _Long& L)
{
    first = L.first;
    second = L.second;
    gruz = L.gruz;
}
// модификатор
void _Long::Set_Gruz(double G)
{
    gruz = G;
}
void _Long::Long(int K, int L)
{
    gruz = K + L;
}
// оперция присваивания
_Long& _Long::operator=(const _Long& l)
{
    if (&l == this)
        return *this;
    second = l.second;
    first = l.first;
    gruz = l.gruz;
    return *this;
}
// операция ввода
istream& operator>>(istream& in, _Long& l)
{
    cout << "\nsecond:";
    in >> l.second;
    cout << "\nfirst:";
    in >> l.first;
    return in;
}
// операция вывода
ostream& operator<<(ostream& out, const _Long& l)
{
    out << "\nfirst : " << l.first;
    out << "\nsecond : " << l.second;
    out << "\nsumm : " << l.gruz;
    out << "\n";
    return out;
}

void f1(_Long& c)
{
    int first = c.first;
    int second = c.second;
    c.Long(first, second);

}
int main()
{
    Pair a;
    cin >> a;
    cout << a;
    Pair b(4, 115);
    cout << b;
    a = b;
    cout << a;

    _Long c;
    cin >> c;
    f1(c);
    cout << c;

    system("pause");
    return 0;
}
