using System;
namespace Cubic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввод параметров кубического уравнения:");
            Console.Write("a=");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("b=");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("c=");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.Write("d=");
            double d = Convert.ToDouble(Console.ReadLine());
            int tip = 0;
            double p1 = 0, p2 = 0, p3 = 0;
            Kardano(a, b, c, d, ref tip, ref p1, ref p2, ref p3);
            if (tip == 1)
                Console.WriteLine("Первый тип. Один вещественный и два комплексно сопряженных корня: x1={0} Re[x2,x3]={1} Im[x2,x3]={2}", p1, p2, p3);
            else
                Console.WriteLine("Вещественные корни: Тип={0} p1={1} p2={2} p3={3}", tip, p1, p2, p3);
            Console.ReadKey();
        }
        private static void Kardano(double a, double b, double c, double d, ref int tip, ref double p1, ref double p2, ref double p3)
        {
            double eps = 1E-14;
            double p = (3 * a * c - b * b) / (3 * a * a);
            double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);
            double det = q * q / 4 + p * p * p / 27;
            if (Math.Abs(det) < eps)
                det = 0;
            if (det > 0)
            {
                tip = 1;
                double u = -q / 2 + Math.Sqrt(det);
                u = Math.Exp(Math.Log(u) / 3);
                double yy = u - p / (3 * u);
                p1 = yy - b / (3 * a);
                p2 = -(u - p / (3 * u)) / 2 - b / (3 * a);
                p3 = Math.Sqrt(3) / 2 * (u + p / (3 * u));
            }
            else
            {
                if (det < 0)
                {
                    tip = 2; 
                    double fi;
                    if (Math.Abs(q) < eps) 
                        fi = Math.PI / 2;
                    else
                    {
                        if (q < 0) 
                            fi = Math.Atan(Math.Sqrt(-det) / (-q / 2));
                        else 
                            fi = Math.Atan(Math.Sqrt(-det) / (-q / 2)) + Math.PI;
                    }
                    double r = 2 * Math.Sqrt(-p / 3);
                    p1 = r * Math.Cos(fi / 3) - b / (3 * a);
                    p2 = r * Math.Cos((fi + 2 * Math.PI) / 3) - b / (3 * a);
                    p3 = r * Math.Cos((fi + 4 * Math.PI) / 3) - b / (3 * a);
                }
                else 
                {
                    if (Math.Abs(q) < eps)
                    {
                        tip = 4;
                        p1 = -b / (3 * a);
                        p2 = -b / (3 * a);
                        p3 = -b / (3 * a);
                    }
                    else
                    {
                        tip = 3;
                        double u = Math.Exp(Math.Log(Math.Abs(q) / 2) / 3);
                        if (q < 0)
                            u = -u;
                        p1 = -2 * u - b / (3 * a);
                        p2 = u - b / (3 * a);
                        p3 = u - b / (3 * a);
                    }
                }
            }
        }
    }
}