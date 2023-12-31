// Вариант 23
//
// Данные:
// y = 2(cos^2(x) - 1)
// 0.1 <= x <= 1
// n = 15
// S = -(2x)^2/2 + (2x)^4/24 + ... + (-1)^n * (2x)^2n/(2n)!
using VitalikTeamLibrary;

namespace Laba3
{
    static class Program
    {
        const int k = 10;
        const int n = 200;

        const double e = 0.0001;
        const double a = 0.1;
        const double b = 1;

        static void Main(string[] args)
        {
            const double step = (b - a) / k;

            for (double x = a; x <= b; x += step)
            {
                Console.Write("X = {0:f2}\t", x);

                double summ = 0;
                double factorial = 1;
                double pow = 1;
                for (int i = 1; i < n; i++)
                    summ += VitalikTeam.Sign(i) * (VitalikTeam.Pow(n, 2 * x, ref pow) / VitalikTeam.Factorial(2 * i, ref factorial)); 

                Console.Write("SN = {0:f4}\t", summ);

                summ = 0;
                factorial = 1;
                double compareSumm = 1;
                pow = 1;
                for (int i = 1; Math.Abs(compareSumm) > e; i++)
                {
                    compareSumm = VitalikTeam.Sign(i) * (VitalikTeam.Pow(n, 2 * x, ref pow) / VitalikTeam.Factorial(2 * i, ref factorial));
                    summ += compareSumm;
                }
                Console.Write("SE = {0:f4}\t", summ);

                Console.Write("Y = {0:f4}\t", 2 * (Math.Pow(Math.Cos(x), 2) - 1));
                Console.Write("\n");
            }

        }

    }

}