#pragma once
#include <string>
#include <iostream>
#include "object.h"
#include "Event.h"
using namespace std;
class Person :
	public Object
{
	//конструктор без параметров
public:
	Person(void);
public:
	//деструктор
	virtual ~Person(void);
	//констрктор с параметрами
	Person(string, int);
	//конструктор копирования
	Person(const Person&);
	//селекторы
	string GetName() { return name; }
	int GetAge() { return age; }
	//модификаторы
	void Set_Name(string);
	void Set_Age(int);
	void Input();
	void Show();
	//перегрузка операции присваивания	
	Person& operator=(const Person&);
	void HandleEvent(const TEvent& e);
	//атрибуты
protected:
	string name; // Имя
	int age;	 // Возраст
};
