#include <iostream>
using namespace std;

class SperBank
{
    int rub, kop;
public:

    SperBank() { rub = 0; kop = 0; };
    SperBank(int m, int s) { rub = m; kop = s; }
    SperBank(const SperBank& t) { rub = t.rub; kop = t.kop; }
    ~SperBank() {};
    int get_rub() { return rub; }
    int get_kop() { return kop; }
    void set_rub(int m) { rub = m; }
    void set_kop(int s) { kop = s; }

    SperBank& operator=(const SperBank&);
    SperBank& operator++();
    SperBank operator++(int);
    SperBank operator+(const SperBank&);

    friend istream& operator>>(istream& in, SperBank& t);
    friend ostream& operator<<(ostream& out, const SperBank& t);
};