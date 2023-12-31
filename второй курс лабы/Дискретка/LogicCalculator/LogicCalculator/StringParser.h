#pragma once
#include <iostream>
#include <stack>
#include <string>
#include <set>
#include <ctime>
#include <conio.h>

namespace std 
{
	class StringParser
	{
	private:
		std::set<int> *manys = NULL;
		std::pair<int, int> universum;

		int size = 0;
		int indexStart = 0;
		int indexEnd = 0;

		std::string string;

	public:
		StringParser()
		{
			this->string = "";
			this->manys = NULL;
		}

		~StringParser()
		{
			this->string = "";
			this->manys = NULL;
		}

		bool Parse();
		bool isSetNull()
		{
			return manys == NULL;
		}

		void SetString(std::string string)
		{
			this->string = string;
		}
		void SetManys(std::set<int>* manys, int size)
		{
			this->manys = manys;
			this->size = size;
		}
		void PrintSet() 
		{
			for (int element : manys[size - 1])
				cout << element << " ";

			cout << endl;
		}
		void PrintSet(int index)
		{
			for (int element : manys[index])
				cout << element << " ";

			cout << endl;
		}
		void WriteSet();
		void PrintSets()
		{
			std::cout << "-------[МНОЖЕСТВА]--------" << std::endl;

			if (!isSetNull())
				for (int i = 0; i < size; i++)
				{
					std::cout << "Множество " << i + 1 << ": ";
					PrintSet(i);
				}
			else
				std::cout << "Пока нет ни одного множества." << std::endl;

			std::cout << std::endl;
		}

	private:
		std::string GetFormulaString(int startIndex, int endIndex);

		void ChangeFormulaString(std::string newFormula, int startIndex, int endIndex);
		bool GetOperation(int index, std::string string);
		void AddNewMany(std::set<int>& newMany);
		void ClearSet();
	};
}