﻿#include "Header.h"
#include <iostream>
using namespace std;

void main()
{

    SperBank a;//конструктор без параметров
    SperBank b; //конструктор без параметров
    SperBank c; //конструктор без параметров
    cin >> a;//ввод переменной
    cin >> b;//ввод переменной
    ++a;//префиксная операция инкремент
    cout << a << endl;//вывод переменной
    c = (a++) + b;//сложение и постфиксная операция инкремент
    cout << "a = " << a << endl; //вывод переменной
    cout << "b = " << b << endl; //вывод переменной
    cout << "c = " << c << endl; //вывод переменной
}