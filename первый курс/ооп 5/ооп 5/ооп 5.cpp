#include <iostream>
#include <cmath>
#include <ctime>
#include "pair.h"
#include "rightAngled.h"

using namespace std;


int main()
{
    srand(time(NULL));

    Pair pair;
    Pair pair1;
    std::cout << pair << std::endl;
    std::cout << pair1 << std::endl;

    pair + pair1;

    cout << pair << endl;

    LongPair rightangled(3, 4);
    rightangled.calculate();
    std::cout << rightangled.get() << std::endl;

    return 0;
}