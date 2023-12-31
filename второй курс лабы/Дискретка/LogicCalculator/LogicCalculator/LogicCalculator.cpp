// Калькулятор множеств с вводом формулы и выводом преобразований
//
// Поважный Виталий РИС-22-1б
// 
// Команды:
// '^' - А И Б
// 'U' - А ИЛИ Б
// '>' -  А И НЕ Б
// '=' - (А И НЕ Б) ИЛИ (НЕ А И Б)
// 
// Множества нужно вводить в соответствии с их номерами
//
// Пример:
// Количество множеств: 3
// Множество 1: { 2, 6, 8 }
// Множество 2: { 2, 6, 8, 4 }
// Множество 3: { 8, 9, 6, 1, 5 }
// Формула: 3&(1^2)
// Результат: { 6, 8 }

#include "StringParser.h"

void PrintMenu()
{
    std::cout << "----------[МЕНЮ]----------" << std::endl;
    std::cout << "[1] Ввести множества" << std::endl;
    std::cout << "[2] Ввести формулу" << std::endl;
    std::cout << "[0] Выход" << std::endl;
}

int main()
{
    setlocale(LC_ALL, "rus");
    srand(time(0));

    std::StringParser parser;

    while (true)
    {
        system("cls");

        PrintMenu();
        parser.PrintSets();

        int choice = 0;
        std::cin >> choice;

        switch (choice)
        {
        case 1:
            parser.WriteSet();
            break;

        case 2:
            system("cls");
            parser.PrintSets();

            if (!parser.isSetNull())
            {
                std::cout << "Команды:\n"
                    << "'^' - А И Б" << std::endl
                    << "'U' - А ИЛИ Б" << std::endl
                    << "'>' -  А И НЕ Б" << std::endl
                    << "'=' - (А И НЕ Б) ИЛИ (НЕ А И Б)" << std::endl
                    << "Множества нужно вводить в соответствии с их номерами\n\n" << std::endl;

                std::cout << "Формула: ";
                std::string formula;
                std::cin >> formula;
                std::cout << "\n";

                parser.SetString(formula);
                parser.Parse();

                std::cout << "\nРезультат: ";
                parser.PrintSet();
                std::cout << "\n\n";
            }
            else
                std::cout << "Пока нет ни одного множества." << std::endl;

            system("pause");
            break;

        case 0:
            return 0;

        default:
            system("cls");

            std::cout << "Неверная команда.\n\n";

            system("pause");
            break;
        }
        
    }

    return 0;
}