using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            
            n = Convert.ToInt32(Console.ReadLine());
            
            BB Bumaga4 = new BB(n);

            for(int i=0;i<n;i++)
            {
                Bumaga4[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(int i=0;i<n;i++)Console.WriteLine(Bumaga4[i]);

        }
    }
}