﻿#include <iostream>
#include "Stack.h"

using namespace std;

int main()
{
    Stack pt(3);

    pt.push(1);
    pt.push(2);

    pt.pop();
    pt.pop();

    pt.push(3);

    cout << "The top element is " << pt.peek() << endl;
    cout << "The stack size is " << pt.size() << endl;

    pt.pop();

    if (pt.isEmpty())
        cout << "The stack is empty\n";
    else
        cout << "The stack is not empty\n";

    cout << endl;

    return 0;
}