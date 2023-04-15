#include <cmath>
#include "pair.h"

class LongPair : public Pair
{  
public:

    LongPair(int f, int s) : Pair(f, s) {}
    
    void calculate()
    {
        hyp = first + second;
    }
    int get() const
    {
        return hyp;
    }

private:
    int hyp;
};
