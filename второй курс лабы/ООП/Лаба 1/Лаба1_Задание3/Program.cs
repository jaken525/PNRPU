using VitalikTeamLibrary;

namespace Laba1
{
    static class Program
    {
        static void CalculateEx6(float a, float b)
        {
            Console.WriteLine("float: " + (float)((Math.Pow(a - b, 3) - (Math.Pow(a, 3) - 3 * Math.Pow(a, 2) * b)) / (3 * a * Math.Pow(b, 2) - Math.Pow(b, 3))));
        }

        static void CalculateEx6(double a, double b)
        {
            Console.WriteLine("double: " + ((Math.Pow(a - b, 3) - (Math.Pow(a, 3) - 3 * Math.Pow(a, 2) * b)) / (3 * a * Math.Pow(b, 2) - Math.Pow(b, 3))));
        }

        static void Main(string[] args)
        {
            // Задача 3
            const float floatA = 1000;
            const float floatB = 0.0001f;

            const double doubleA = 1000;
            const double doubleB = 0.0001;

            Console.Write("((a - b)^3 - (a^3 - 3a^2b)) / (3ab^2 - b^3)\n");
            CalculateEx6(floatA, floatB);
            CalculateEx6(doubleA, doubleB);
        }
    }
}