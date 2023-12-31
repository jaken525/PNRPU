// Вариант 23

using System;
using VitalikTeamLibrary;

namespace Laba1
{
    public static class Program
    {
        public static void Main()
        {
            int valueN = VitalikTeam.ReadValue("n");
            int valueM = VitalikTeam.ReadValue("m");

            // Задача 1
            Console.WriteLine("--m - n++: " + (--valueM - valueN++));
            Console.WriteLine("m, n: " + valueM + ", " + valueN);

            Console.WriteLine("m * m < n++: " + (valueM * valueM < valueN++));
            Console.WriteLine("m, n: " + valueM + ", " + valueN);

            Console.WriteLine("n-- > ++m: " + (valueN-- > ++valueM));
            Console.WriteLine("m, n: " + valueM + ", " + valueN + "\n");

            double valueX = 0;
            bool isRead = false;

            do 
            {
                valueX = VitalikTeam.ReadDouble("x");

                if (valueX != 0)
                    isRead = true;
                else
                    Console.WriteLine("Неверно задан x.");
            }
            while (!isRead);

            Console.Write("\n1 + 1/x + 1/x^2: " + (1 + Math.Pow(valueX, -1) + Math.Pow(valueX, -2)) + "\n");
        }
    }
}