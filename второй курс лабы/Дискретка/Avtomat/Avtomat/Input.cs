using System;

namespace Avtomat
{
    public class Input
    {
        public string str = "";

        public Input()
        {
            do
            {
                Console.Write("Введите строку, состоящую из алфавита a, b, c, d: ");
                str = Console.ReadLine();
                if (str == "")
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод. ");
                }
            } while (str == "");
        }
    }
}