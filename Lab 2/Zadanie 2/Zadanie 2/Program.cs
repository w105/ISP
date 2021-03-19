using System;

namespace Zadanie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string stroka = "";
            Console.WriteLine("Ввдите строку: ");
            stroka = Console.ReadLine();
            string[] words = stroka.Split(' ');
            Array.Reverse(words);
            string newstroka = String.Join(" ", words);
            Console.WriteLine("\nСтрока наооборот: " + newstroka);
        }
    }
}
