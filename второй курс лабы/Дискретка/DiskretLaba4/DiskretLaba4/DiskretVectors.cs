using static System.Net.Mime.MediaTypeNames;

namespace Functions
{
    internal class DiskretVectors
    {
        string? _vector;
        List<List<int>> truthTable;
        public string? additional;

        public DiskretVectors()
        {
            do
            {
                Console.Write("Введите вектор размером (2, 4, 8) из цифр 0 и 1:\n");
                _vector = Console.ReadLine();
                Console.WriteLine();

                if (string.IsNullOrEmpty(_vector))
                    Console.WriteLine("Вы ввели пустой вектор! Повторите попытку.\n");
                else if (_vector.Length != 8 && _vector.Length != 4 && _vector.Length != 2)
                    Console.WriteLine("Неверная длина вектора! Повторите попытку.\n");

            } while (string.IsNullOrEmpty(_vector) || _vector.Length != 8 && _vector.Length != 4 && _vector.Length != 2);

            truthTable = new List<List<int>>();
            if (_vector.Length == 8)
            {
                int ind = 0;
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        for (int z = 0; z < 2; z++)
                        {
                            truthTable.Add(new List<int>());
                            truthTable[truthTable.Count - 1].Add(i);
                            truthTable[truthTable.Count - 1].Add(j);
                            truthTable[truthTable.Count - 1].Add(z);
                            truthTable[truthTable.Count - 1].Add(Convert.ToInt32(_vector[ind++].ToString()));
                        }
            }
            else if (_vector.Length == 4)
            {
                int ind = 0;
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                    {
                        truthTable.Add(new List<int>());
                        truthTable[truthTable.Count - 1].Add(i);
                        truthTable[truthTable.Count - 1].Add(j);
                        truthTable[truthTable.Count - 1].Add(Convert.ToInt32(_vector[ind++].ToString()));
                    }
            }
            else if (_vector.Length == 2)
            {
                int ind = 0;
                for (int i = 0; i < 2; i++)
                {
                    truthTable.Add(new List<int>());
                    truthTable[truthTable.Count - 1].Add(i);
                    truthTable[truthTable.Count - 1].Add(Convert.ToInt32(_vector[ind++].ToString()));
                }
            }
        }
        public string PropertiesFunction()
        {
            string str = "";
            if (_vector.Length == 8)
            {
                if (
                    truthTable[0][0] == 0 &&
                    truthTable[0][1] == 0 &&
                    truthTable[0][2] == 0 &&
                    truthTable[0][3] == 0
                    )
                {
                    str += " + |";
                    additional += "+";
                }
                else
                { 
                    str += " - |";
                    additional += "-";
                }

                if (
                    truthTable[truthTable.Count - 1][0] == 1 &&
                    truthTable[truthTable.Count - 1][1] == 1 &&
                    truthTable[truthTable.Count - 1][2] == 1 &&
                    truthTable[truthTable.Count - 1][3] == 1
                    )
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                bool isSelfDuality = true;
                for (int i = 0; i < truthTable.Count / 2; i++)
                    if (truthTable[i][3] == truthTable[truthTable.Count - (i + 1)][3])
                    {
                        isSelfDuality = false;
                        break;
                    }

                if (isSelfDuality)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                bool isMonotony = true;
                for (int i = 0; i < truthTable.Count - 1; i++)
                    if (truthTable[i][3] > truthTable[i + 1][3])
                        isMonotony = false;

                if (isMonotony)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                int sum = 0;
                foreach (var item in _vector)
                    if (char.IsDigit(item))
                        sum += Convert.ToInt32(item.ToString());

                char[] obrtext = _vector.ToCharArray();
                Array.Reverse(obrtext);
                string finaltext = new string(obrtext);
                if (finaltext == _vector)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }
            }
            if (_vector.Length == 4)
            {
                if (
                    truthTable[0][0] == 0 &&
                    truthTable[0][1] == 0 &&
                    truthTable[0][2] == 0
                    )
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                if (
                    truthTable[truthTable.Count - 1][0] == 1 &&
                    truthTable[truthTable.Count - 1][1] == 1 &&
                    truthTable[truthTable.Count - 1][2] == 1
                    )
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                bool isSelfDuality = true;
                for (int i = 0; i < truthTable.Count / 2; i++)
                    if (truthTable[i][2] == truthTable[truthTable.Count - (i + 1)][2])
                    {
                        isSelfDuality = false;
                        break;
                    }

                if (isSelfDuality)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                bool isMonotony = true;
                for (int i = 0; i < truthTable.Count - 1; i++)
                    if (truthTable[i][2] > truthTable[i + 1][2])
                        isMonotony = false;

                if (isMonotony)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                int sum = 0;
                foreach (var item in _vector)
                    if (char.IsDigit(item))
                        sum += Convert.ToInt32(item.ToString());

                if (sum % 2 == 0)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }
            }
            if (_vector.Length == 2)
            {
                if (truthTable[0][0] == 0 && truthTable[0][1] == 0)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                if (
                    truthTable[truthTable.Count - 1][0] == 1 &&
                    truthTable[truthTable.Count - 1][1] == 1
                    )
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                bool isSelfDuality = true;
                for (int i = 0; i < truthTable.Count / 2; i++)
                    if (truthTable[i][1] == truthTable[truthTable.Count - (i + 1)][1])
                    {
                        isSelfDuality = false;
                        break;
                    }

                if (isSelfDuality)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                bool isMonotony = true;
                for (int i = 0; i < truthTable.Count - 1; i++)
                    if (truthTable[i][1] > truthTable[i + 1][1])
                        isMonotony = false;

                if (isMonotony)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }

                int sum = 0;
                foreach (var item in _vector)
                    if (char.IsDigit(item))
                        sum += Convert.ToInt32(item.ToString());

                if (sum % 2 != 0)
                {
                    str += " + |";
                    additional += "+";
                }
                else
                {
                    str += " - |";
                    additional += "-";
                }
            }

            return str;
        }

    }

}
