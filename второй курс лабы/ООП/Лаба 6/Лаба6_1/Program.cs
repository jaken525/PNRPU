using VitalikTeamLibrary;

namespace Laba6_2
{
    public static class Program
    {
        public static void Main()
        {  
            string[] words = VitalikTeam.ReadString("строку").Split(" ");

            Array.Reverse(words);

            Console.WriteLine("Перевёрнутый ");
            VitalikTeam.PrintArray(words);

            Array.Sort(words);
            Array.Reverse(words);

            Console.Write("Отсортированный по убыванию ");
            VitalikTeam.PrintArray(words);
        }
    }
}