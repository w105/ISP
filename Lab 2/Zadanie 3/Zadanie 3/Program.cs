using System;

namespace Zadanie_3
{
    class Program
    {
        static int Main()
        {
        input:
            Console.WriteLine("Задайте длину сторон треугольника: ");
            Console.Write("A = "); double a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = "); double b = Convert.ToInt32(Console.ReadLine());
            Console.Write("C = "); double c = Convert.ToInt32(Console.ReadLine());
            int menu = 0;
            if (a < b + c && a > b - c && c < a + b && c > a - b && b < a + c && b > a - c)
            {
                do
                {
                    Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                    Console.WriteLine("Меню: \n1. Повтор ввода\n2. Вычисление\n3. Выход");
                    menu = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                    switch (menu)
                    {
                        case 1: goto input; break;
                        case 2:
                            double Perimeter, Square, alpha, beta, gamma, radius, RADIUS;
                            Perimeter = a + b + c;
                            Square = Math.Sqrt((Perimeter / 2) * ((Perimeter / 2) - a) * ((Perimeter / 2) - b) * ((Perimeter / 2) - c));
                            alpha = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
                            beta = (Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c);
                            gamma = (Math.Pow(b, 2) + Math.Pow(a, 2) - Math.Pow(c, 2)) / (2 * b * a);
                            radius = 2 * Square / Perimeter;
                            RADIUS = (a * b * c) / (4 * Square);
                            Console.WriteLine("Перимиетр прямоугольника: " + Perimeter);
                            Console.WriteLine("Площадь прямоугольника: " + Square);
                            Console.WriteLine("Косинус угла Альфа: " + alpha);
                            Console.WriteLine("Косинус угла Бета: " + beta);
                            Console.WriteLine("Косинус угла Гамма: " + gamma);
                            Console.WriteLine("Радиус вписанной окружности: " + radius);
                            Console.WriteLine("Радиус описанной окружности: " + RADIUS);
                            break;
                        case 3: break;
                        default: Console.WriteLine("Неверный ввод"); break;
                    }
                } while (menu != 3);
            }
            else
            {
                Console.WriteLine("Данного треугольника не существует\nДля повторного ввода нажмите y: ");
                char again = Convert.ToChar(Console.ReadLine());
                if (again == 'y')
                    goto input;
                else
                    return 0;
            }
            return 0;
        }
    }
}