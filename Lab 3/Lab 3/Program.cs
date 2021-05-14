using System;

namespace Lab_3
{
    class Program
    {
        static void Main()
        {
            int n, j;

            n = 3;
            Warrior Shooter = new Warrior(n);

            Console.Write("Меню редактирования характеристик Стрелка:\n1)Сила \n2)Ловкость \n3)Уровень навыков \n4)Закрыть меню\n");


            for (int i = 0; i < 5; i++)
            {
                j = int.Parse(Console.ReadLine());
                    switch (j)
                    {
                        case 1:
                            Console.Clear();
                            // Console.WriteLine("1");
                            Console.WriteLine(Shooter[0] + " Единиц ");
                            Console.WriteLine("Введите силу Стрелка");
                            Shooter[0] = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.Write("Меню редактирования характеристик Стрелка:\n1)Сила \n2)Ловкость \n3)Уровень навыков \n4)Закрыть меню\n");
                            break;
                        case 2:
                            Console.Clear();
                            // Console.WriteLine("2");
                            Console.WriteLine(Shooter[1] + " Единиц ");
                            Console.WriteLine("Введите ловкость Стрелка");
                            Shooter[1] = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.Write("Меню редактирования характеристик Стрелка:\n1)Сила \n2)Ловкость \n3)Уровень навыков \n4)Закрыть меню\n");
                            break;
                        case 3:
                            Console.Clear();
                            // Console.WriteLine("3");
                            Console.WriteLine(Shooter[2] + " Единиц ");
                            Console.WriteLine("Введите уровень навыков Стрелка");
                            Shooter[2] = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.Write("Меню редактирования характеристик Стрелка:\n1)Сила \n2)Ловкость \n3)Уровень навыков \n4)Закрыть меню\n");
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Вы нажали что-то другое...");
                            break;
                    }
                }
           // for (int i = 0; i < 3; i++) Console.WriteLine(Shooter[i] + " Единиц ");
        }
    }
}