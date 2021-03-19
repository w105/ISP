using System;

namespace Zadanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] glasnie = { 'a', 'o', 'y', 'u', 'e', 'i', 'A', 'O', 'Y', 'U', 'E', 'I' };
            char[] alphavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string stroka = "";
            Console.WriteLine("Ввдите строку: ");
            stroka = Console.ReadLine();
            char[] c = stroka.ToCharArray();
            for (int i = 0; i < stroka.Length - 1; i++)
            {
                for (int j = 0; j < glasnie.Length; j++)
                {
                    if (c[i] == glasnie[j])
                    {
                        char a = c[i + 1];
                        for (int z = 0; z < alphavit.Length; z++)
                        {
                            if (a == alphavit[z])
                            {
                                c[i + 1] = alphavit[z + 1];
                            }
                        }
                    }
                }
            }
            Console.WriteLine(c);
        }
    }
}
