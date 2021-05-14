using System;
using System.Runtime.InteropServices;

namespace Laba4_2_
{
    static class math
    {
        [DllImport("Math.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Sum(int a, int b);

        [DllImport("Math.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Minus(int a, int b);
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("______________________");
            Console.WriteLine("a = " + a + "\nb = " + b);
            Console.WriteLine("а + b = " + math.Sum(a, b));
            Console.WriteLine("a - b = " + math.Minus(a, b));

        }
    }
}