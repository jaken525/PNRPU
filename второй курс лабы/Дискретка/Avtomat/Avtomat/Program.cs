using System;

namespace Avtomat
{
    internal class Program
    {
        static void GotWord(string word)
        {
            foreach (char i in word)
            {
                if (i == 'a')
                {
                    Console.WriteLine("--> " + i);
                    Console.WriteLine($"Текущее состояние автомата: {state}");
                    state = dMur[0, state];
                    Console.WriteLine($"Новое состояние: {state}");
                    GetEndState();
                }
                if (i == 'b')
                {
                    Console.WriteLine("--> " + i);
                    Console.WriteLine($"Текущее состояние автомата : {state}");
                    state = dMur[1, state];
                    Console.WriteLine($"Новое состояние: {state}");
                    GetEndState();
                }
                if (i == 'c')
                {
                    Console.WriteLine("--> " + i);
                    Console.WriteLine($"Текущее состояние автомата : {state}");
                    state = dMur[2, state];
                    Console.WriteLine($"Новое состояние: {state}");
                    GetEndState();
                }
                if (i == 'd')
                {
                    Console.WriteLine("--> " + i);
                    Console.WriteLine($"Текущее состояние автомата : {state}");
                    state = dMur[3, state];
                    Console.WriteLine($"Новое состояние автомата: {state}");
                    GetEndState();
                }
            }
        }
        static void GetEndState()
        {
            if (state == 9)
            {
                endState++;
            }
        }
        static int endState = 0;
        static int[,] GetAvtomat()
        {
            int[,] dMur = new int[4, 10];
            dMur[0, 0] = 1;
            dMur[0, 1] = 5;
            dMur[0, 2] = 0;
            dMur[0, 3] = 0;
            dMur[0, 4] = 0;
            dMur[0, 5] = 9;
            dMur[0, 6] = 0;
            dMur[0, 7] = 0;
            dMur[0, 8] = 0;
            dMur[0, 9] = 9;

            dMur[1, 0] = 2;
            dMur[1, 1] = 0;
            dMur[1, 2] = 6;
            dMur[1, 3] = 0;
            dMur[1, 4] = 0;
            dMur[1, 5] = 0;
            dMur[1, 6] = 9;
            dMur[1, 7] = 0;
            dMur[1, 8] = 0;
            dMur[1, 9] = 9;


            dMur[2, 0] = 3;
            dMur[2, 1] = 0;
            dMur[2, 2] = 0;
            dMur[2, 3] = 7;
            dMur[2, 4] = 0;
            dMur[2, 5] = 0;
            dMur[2, 6] = 0;
            dMur[2, 7] = 9;
            dMur[2, 8] = 0;
            dMur[2, 9] = 9;


            dMur[3, 0] = 4;
            dMur[3, 1] = 0;
            dMur[3, 2] = 0;
            dMur[3, 3] = 0;
            dMur[3, 4] = 8;
            dMur[3, 5] = 0;
            dMur[3, 6] = 0;
            dMur[3, 7] = 0;
            dMur[3, 8] = 9;
            dMur[3, 9] = 9;


            return dMur;
        }


        static int[,] dMur = GetAvtomat();
        static int state = 0;

        static void Main(string[] args)
        {
            Input str = new Input();

            GotWord(str.str);

            if (endState > 0)
            {
                Console.WriteLine($"\n\nСлово {str.str} принадлежит языку");
            }
            else
            {
                Console.WriteLine($"\n\nСлово {str.str} НЕ принадлежит языку");
            }
        }
    }
}