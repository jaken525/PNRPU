using System;
using VitalikTeamLibrary;

namespace Laba1_2
{
    public class Point
    {
        public double valueX;
        public double valueY;

        public Point()
        {
            valueX = 0;
            valueY = 0;
        }

        public Point(double x, double y)
        {
            valueX = x;
            valueY = y;
        }
    }

    public static class Program
    {
        public static void Main()
        {
            // Задача 2
            Point point = new Point(VitalikTeam.ReadDouble("x"), VitalikTeam.ReadDouble("y"));

            Console.WriteLine(
                Math.Pow(point.valueX, 2) + Math.Pow(point.valueY, 2) <= 25 ||
                Math.Pow(point.valueX + 5, 2) + Math.Pow(point.valueY, 2) <= 25
                );
        }
    }
}