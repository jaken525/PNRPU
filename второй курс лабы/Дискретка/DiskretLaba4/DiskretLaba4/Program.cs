using Functions;
using VitalikTeamLibrary;

namespace DiskretLaba4
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (count > 3 || count < 1)
            {
                count = VitalikTeam.ReadValue("количество векторов");

                if (count > 3 || count < 1)
                    Console.WriteLine("Неверное количество векторов. Максимум можно иметь 3 вектора.");
            }

            DiskretVectors[] Vectors = new DiskretVectors[count];
            string[] propertiesVectors = new string[count];
            string[] additionalVectors = new string[count];

            for (int i = 0; i < Vectors.Count(); i++)
            {
                Vectors[i] = new DiskretVectors();
                propertiesVectors[i] = Vectors[i].PropertiesFunction();
                additionalVectors[i] = Vectors[i].additional;
            }

            Console.WriteLine("------------------------");
            Console.WriteLine("   | T0| T1| S | M | L |");
            for (int i = 0; i < propertiesVectors.Count(); i++)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($" {i + 1} |{propertiesVectors[i]}");
            }
            Console.WriteLine("------------------------");

            bool isCompleteness = true;
            for (int j = 0; j < propertiesVectors[0].Length; j++)
            {
                int countMinus = 0;
                for (int i = 0; i < propertiesVectors.Count(); i++)
                {
                    if (propertiesVectors[i][j] == ' ')
                    {
                        countMinus = -1;
                        break;
                    }

                    if (propertiesVectors[i][j] == '-')
                        countMinus++;
                }
                if (count != 1)
                {
                    isCompleteness = false;
                    break;
                }

            }

            Console.WriteLine($"Полнота: {isCompleteness}");
        }
    }
}