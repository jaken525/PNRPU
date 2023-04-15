#pragma once 
#include <iostream>

class Pair 
{
protected:
    int first;
    int second;

public:
    Pair() 
    {
        first = rand() % 10;
        second = rand() % 10;
    }

    Pair(int f, int s) : first(f), second(s) {}

    void set_first(int f)
    {
        first = f;
    }

    void set_second(int s)
    {
        second = s;
    }

    int get_first() const
    {
        return first;
    }

    int get_second() const
    {
        return second;
    }

    friend std::ostream& operator << (std::ostream& s, const Pair& pair) 
    {
        return s << "(" << pair.first << ", " << pair.second << ")";
    }

    Pair operator + (Pair& pair1)
    {
        Pair newPair(this->first += pair1.first, this->second += pair1.second);
        return newPair;
    }

    virtual int product() const
    {
        return first * second;
    }

    virtual ~Pair() {}
};