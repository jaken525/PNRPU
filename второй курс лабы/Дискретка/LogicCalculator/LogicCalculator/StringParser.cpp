#include "StringParser.h"

void std::StringParser::WriteSet()
{
	ClearSet();
	system("cls");

	std::cout << "Введите универсум: ";
	std::cin >> universum.first >> universum.second;

	std::cout << "Хотите случайно запролнять множества? [Y - Да,N - Нет]" << std::endl;
	int choice = _getch();
	bool isRandom = false;

	if (choice > 90)
		choice -= 32;

	if (choice == 89 || choice == 78)
		switch (choice)
		{
		case 89:
			std::cout << "\nРежим СЛУЧАЙНОГО заполнения.\n" << std::endl;
			isRandom = true;
			break;

		case 78:
			std::cout << "\nРежим РУЧНОГО заполнения.\n" << std::endl;
			isRandom = false;
			break;
		}
	else
	{
		std::cout << "Введено неправильное значение." << std::endl;
		system("pause");
		return;
	}

	std::cout << "Введите кол-во множеств: ";
	size = 0;
	std::cin >> size;

	if (size > 0)
	{
		manys = new std::set<int>[size];

		for (int i = 0; i < size; i++)
		{
			std::cout << "Размер множества " << i + 1 << ": ";
			int manySize = 0;
			std::cin >> manySize;

			if (!isRandom)
				std::cout << "Элементы множества " << i + 1 << ": ";

			for (int j = 0; j < manySize; j++)
			{
				int element = 0;

				if (isRandom)
					element = rand() % (universum.second - universum.first + 1) + universum.first;
				else
				{
					do
					{
						std::cin >> element;
					} while (element > universum.second && element < universum.first);
				}

				manys[i].insert(element);
			}
		}
	}
}

void std::StringParser::ClearSet()
{
	manys = NULL;
}

bool std::StringParser::Parse()
{
	bool success = false;

	if (string != "")
	{
		do
		{
			indexStart = 0;
			indexEnd = 0;

			for (int i = 0; i < this->string.length(); i++)
			{
				if (string[i] == 40)
					indexStart = i + 1;

				if (string[i] == 41)
				{
					indexEnd = i;
					break;
				}
			}

			if (indexStart != 0 && indexEnd != 0)
			{
				std::string currentFormula = GetFormulaString(indexStart, indexEnd);
				ChangeFormulaString(currentFormula, indexStart, indexEnd);
				std::cout << string << std::endl;
			}
		} while (indexStart != 0 && indexEnd != 0);
	}

	std::cout << string << std::endl;
	ChangeFormulaString(string, 0, string.length());
	std::cout << string << std::endl;

	return success;
}

std::string std::StringParser::GetFormulaString(int startIndex, int endIndex)
{
	std::string formula = "";

	for (int i = startIndex; i < endIndex; i++)
		formula += string[i];

	return formula;
}

void std::StringParser::ChangeFormulaString(std::string newFormula, int startIndex, int endIndex)
{
	for (int i = 0; i < newFormula.length(); i++)
		if (GetOperation(i, newFormula))
			break;

	std::string newString = "";

	for (int i = 0; i < startIndex - 1; i++)
		newString += this->string[i];

	newString += std::to_string(this->size);
	for (int i = endIndex + 1; i < this->string.length(); i++)
		newString += this->string[i];

	this->string = newString;
}

bool std::StringParser::GetOperation(int index, std::string string)
{
	bool isOperation = true;

	switch (string[index])
	{
	case '^':
	{
		set<int> result;

		std::string firstIndex = "";
		std::string secondIndex = "";
		for (int i = 0; i < index; i++)
			firstIndex += string[i];
		for (int i = index + 1; i < string.length(); i++)
			secondIndex += string[i];

		for (int element : manys[std::stoi(firstIndex) - 1])
			if (manys[std::stoi(secondIndex) - 1].count(element) > 0)
				result.insert(element);

		AddNewMany(result);
	}
	break;

	case 'U':
	{
		std::string firstIndex = "";
		std::string secondIndex = "";
		for (int i = 0; i < index; i++)
			firstIndex += string[i];
		for (int i = index + 1; i < string.length(); i++)
			secondIndex += string[i];

		set<int> result = manys[std::stoi(firstIndex) - 1];

		result.insert(manys[std::stoi(secondIndex) - 1].begin(), manys[std::stoi(secondIndex) - 1].end());

		AddNewMany(result);
	}
	break;

	case '>':
	{
		std::string firstIndex = "";
		std::string secondIndex = "";
		for (int i = 0; i < index; i++)
			firstIndex += string[i];
		for (int i = index + 1; i < string.length(); i++)
			secondIndex += string[i];

		set<int> result;

		for (int element : manys[std::stoi(firstIndex) - 1])
			if (manys[std::stoi(secondIndex) - 1].count(element) == 0)
				result.insert(element);

		AddNewMany(result);
	}
	break;

	case '=':
	{
		std::string firstIndex = "";
		std::string secondIndex = "";
		for (int i = 0; i < index; i++)
			firstIndex += string[i];
		for (int i = index + 1; i < string.length(); i++)
			secondIndex += string[i];

		set<int> result;
		set<int> secondComponent;

		for (int element : manys[std::stoi(secondIndex) - 1])
			if (manys[std::stoi(firstIndex) - 1].count(element) == 0)
				result.insert(element);

		for (int element : manys[std::stoi(firstIndex) - 1])
			if (manys[std::stoi(secondIndex) - 1].count(element) == 0)
				secondComponent.insert(element);

		result.insert(secondComponent.begin(), secondComponent.end());

		AddNewMany(result);
	}
	break;

	default:
		isOperation = false;
		break;
	}

	return isOperation;
}

void std::StringParser::AddNewMany(std::set<int>& newMany)
{
	size++;

	std::set<int> *newManys = new std::set<int>[size];

	for (int i = 0; i < size - 1; i++)
		newManys[i] = manys[i];

	newManys[size - 1] = newMany;

	manys = newManys;
}