using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            int m1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter two numbers: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            int m2 = Convert.ToInt32(Console.ReadLine());

            RationalNumber example1 = new RationalNumber(n1, m1);
            RationalNumber example2 = new RationalNumber(n2, m2);

            Console.WriteLine("+");
            Console.WriteLine($"{(double)(example1 + example2)}");
            Console.WriteLine("-");
            Console.WriteLine($"{(double)(example1 - example2)}");
            Console.WriteLine("/ ");
            Console.WriteLine($"{(double)(example1 / example2)}");
            Console.WriteLine("*");
            Console.WriteLine($"{(double)(example1 * example2)}");
            Console.WriteLine(">");
            if (example1 > example2)
                Console.WriteLine($"{(double)example1}");
            else
                Console.WriteLine($"{(double)example2}");
            Console.WriteLine($"{(double)example2}");
            Console.WriteLine("<");
            if (example1 < example2)
                Console.WriteLine($"{(double)example1}");
            else
                Console.WriteLine($"{(double)example2}");

            Console.WriteLine(">= ");
            if (example1 >= example2)
                Console.WriteLine($"{(double)example1}");
            else
                Console.WriteLine($"{(double)example2}");
            Console.WriteLine("<=");
            if (example1 <= example2)
                Console.WriteLine($"{(double)example1}");
            else
                Console.WriteLine($"{(double)example2}");
            Console.WriteLine("==");

            if (example1 == example2)
                Console.WriteLine("The numbers are equal");
            else
                Console.WriteLine("The numbers are not equal");

            Console.WriteLine("convert to a string");
            Console.WriteLine(example1.ToString());
            Console.WriteLine(example2.ToString());
            Console.WriteLine("convert to an int");
            Console.WriteLine(example1.ToString());
            Console.WriteLine(example2.ToString());
            Console.WriteLine("convert to a double");
        }
    }
}