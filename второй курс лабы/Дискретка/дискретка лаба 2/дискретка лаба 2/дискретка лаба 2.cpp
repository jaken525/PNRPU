#include <iostream>
#include <fstream>
#include <Windows.h>
#include <ctime>
#include <string>

class Matrix
{
private:
    static const int size = 6;
    int matrix[size][size];

public:
    Matrix()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                matrix[i][j] == -1;
    }

    std::string OpenFileName(HWND owner = NULL, uint32_t flags = OFN_EXPLORER | OFN_FILEMUSTEXIST | OFN_HIDEREADONLY)
    {
        std::string filename(MAX_PATH, '\0');
        OPENFILENAME ofn = { };

        ofn.lStructSize = sizeof(ofn);
        ofn.hwndOwner = owner;
        ofn.lpstrFilter = "Array Files (*.txt)\0*.txt\0All Files (*.*)\0*.*\0";
        ofn.lpstrFile = &filename[0];
        ofn.nMaxFile = MAX_PATH;
        ofn.lpstrTitle = "Select a File";
        ofn.Flags = flags;

        if (!GetOpenFileName(&ofn))
            return "";

        return filename;
    }

    void ReadArrayFromFile(std::string path)
    {
        std::ifstream file(path);
        std::string str = "";

        for (int i = 0; i < size; i++)
        {
            getline(file, str);

            for (int j = 0, k = 0; j < (size * 2) - 1; j += 2, k++)
                matrix[i][k] = str[j] - '0';
        }

        file.close();
    }

    void PrintArray()
    {
        if (matrix[0][0] != -1)
        {
            std::cout << "Массив:" << std::endl;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    std::cout << matrix[i][j] << " ";

                std::cout << std::endl;
            }
        }
        else
            std::cout << "Массив пуст." << std::endl;

        std::cout << std::endl;
    }

    bool isReflexive() 
    {
        for (int i = 0; i < size; i++)
            if (matrix[i][i] != 1)
                return false;

        return true;
    }

    bool isAntiReflexive()
    {
        for (int i = 0; i < size; i++)
            if (matrix[i][i] != 0)
                return false;

        return true;
    }

    bool isSymmetric() 
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (matrix[i][j] != matrix[j][i])
                    return false;

        return true;
    }

    bool isAntiSymmetric()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (i != j && matrix[i][j] == 1 && matrix[j][i] == 1)
                    return false;

        return true;
    }

    bool isAsymmetric() 
    {
        for (int i = 0; i < size; ++i)
            for (int j = 0; j < size; ++j)
                if (matrix[i][j] == 1 && matrix[j][i] == 1)
                    return false;

        return true;
    }

    bool isTransitive()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (matrix[i][j] == 1)
                    for (int k = 0; k < size; k++)
                        if (matrix[j][k] == 1 && matrix[i][k] != 1)
                            return false;

        return true;
    }

    bool isAntiTransitive() 
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (matrix[i][j] == 1)
                    for (int k = 0; k < size; k++)
                        if (matrix[j][k] == 1 && matrix[i][k] == 1)
                            return false;

        return true;
    }

    bool isComplete() 
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                if (i != j && matrix[i][j] != 1)
                    return false;

        return true;
    }

private:
    unsigned short readshort(char*& f, size_t& pos)
    {
        unsigned short result = {
            (unsigned int)((uint8_t)f[pos] * 0x00000001) + \
            (unsigned int)((uint8_t)f[pos + 1] * 0x00000100)
        };

        pos += 2;

        return result;
    }

    std::string writeShort(int num)
    {
        int arr[] = { 0, 0 };
        while (num >= 256)
        {
            arr[1] += 1;
            num -= 256;
        }
        arr[0] = num;

        std::string hex;
        for (int i = 0; i < 2; i++)
            hex += char(arr[i]);

        return hex;
    }
};

int main()
{
    Matrix matrix;

    srand(time(0));
    setlocale(LC_ALL, "rus");

    while (true)
    {
        system("cls");

        std::string filePath = matrix.OpenFileName();
        if (filePath != "")
        {
            matrix.ReadArrayFromFile(filePath);
            matrix.PrintArray();

            std::cout << "Рефлексивность: " << (matrix.isReflexive() ? "Да" : "Нет") << std::endl;
            std::cout << "Антирефлексивность: " << (matrix.isAntiReflexive() ? "Да" : "Нет") << std::endl;

            std::cout << "Симметричность: " << (matrix.isSymmetric() ? "Да" : "Нет") << std::endl;
            std::cout << "Антисимметричность: " << (matrix.isAntiSymmetric() ? "Да" : "Нет") << std::endl;
            std::cout << "Асимметричность: " << (matrix.isAsymmetric() ? "Да" : "Нет") << std::endl;

            std::cout << "Транзитивность: " << (matrix.isTransitive() ? "Да" : "Нет") << std::endl;

            std::cout << "Связанность: " << (matrix.isComplete() ? "Да" : "Нет") << std::endl;
        }
        else
            std::cout << "Не удаётся открыть файл." << std::endl;

        std::cout << std::endl;
        system("pause");
    }
}
