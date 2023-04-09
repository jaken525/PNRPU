#pragma once
#include "Header.h"

class _Long :
    public
    Pair
{
public:
    _Long(void);                                              // конструктор без параметров 
public:
    ~_Long(void);                                             // деструктор 
    _Long(int, int, double);//конструктор с параметрами 
    _Long(const _Long&);//конструктор копирования
    int Get_gruz() { return gruz; }                           // модификатор 
    void Set_Gruz(double);//селектор
    void Long(int, int);
    _Long& operator=(const _Long&);                         // операция присваивания
    friend istream& operator>>(istream& in, _Long& l);        // операция ввода
    friend ostream& operator<<(ostream& out, const _Long& l); // операция вывода 
protected:
    int gruz;                                                 // атрибут грузоподъемность
};
