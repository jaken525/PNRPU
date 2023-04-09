#pragma once
#include "Header.h"

class _Long :
    public
    Pair
{
public:
    _Long(void);                                              // ����������� ��� ���������� 
public:
    ~_Long(void);                                             // ���������� 
    _Long(int, int, double);//����������� � ����������� 
    _Long(const _Long&);//����������� �����������
    int Get_gruz() { return gruz; }                           // ����������� 
    void Set_Gruz(double);//��������
    void Long(int, int);
    _Long& operator=(const _Long&);                         // �������� ������������
    friend istream& operator>>(istream& in, _Long& l);        // �������� �����
    friend ostream& operator<<(ostream& out, const _Long& l); // �������� ������ 
protected:
    int gruz;                                                 // ������� ����������������
};
