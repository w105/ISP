using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    interface IAnimal { }

    interface IAction
    {
        void DoAction();
    }

    interface IWalker
    {
        void Walk();
    }

    interface ISwimmer
    {
        void Swim();
    }

    interface IFly
    {
        void Fly();
    }

    interface IDoggy
    {
        void WriteName();
        void WriteSpeed();
    }

    class SwimAction : IAction
    {
        public void DoAction()
        {
            Console.Write("swim ");
        }
    }

    class WalkAction : IAction
    {
        public void DoAction()
        {
            Console.Write("walk ");
        }
    }

    class FlyAction : IAction
    {
        public void DoAction()
        {
            Console.Write("fly ");
        }
    }

    class Human
    {
        public Human(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public static string Info<T>(T obj)
        {
            return obj.ToString();
        }
    }

    class ZooDirector : Human
    {
        public ZooDirector(string Name, int Age, string ZooName) : base(Name, Age)
        {
            this.ZooName = ZooName;
        }

        public string ZooName { get; set; }

        public override string ToString()
        {
            return String.Format($"Информация о директоре зоопарка\nИмя: {Name}\nВозраст: {Age}\nназвание зоопарка: {ZooName}");
        }
    }

    class Dog : IFormattable, IDoggy, IAnimal, IWalker, ISwimmer
    {
        IAction walkAction;
        IAction swimAction;

        private decimal _speed;
        private string _name;

        public Dog(string name, decimal speed)
        {
            walkAction = new WalkAction();
            swimAction = new SwimAction();
            _speed = speed;
            _name = name;
        }

        void IDoggy.WriteName()
        {
            Console.WriteLine($"имя: {_name}");
        }

        void IDoggy.WriteSpeed()
        {
            Console.WriteLine($"скорость собаки:");
        }

        public void Walk()
        {
            walkAction.DoAction();
        }

        public void Swim()
        {
            swimAction.DoAction();
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal MetersPerSecond
        {
            get => _speed;
        }

        public decimal KilometersPerHour
        {
            get => _speed * 3.6m;
        }

        public decimal MilesPerHour
        {
            get => _speed * 2.237m;
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "C":
                    return _speed.ToString("F2", provider) + " m/s";
                case "F":
                    return KilometersPerHour.ToString("F2", provider) + " k/h";
                case "K":
                    return MilesPerHour.ToString("F2", provider) + " mph";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
    }

    class Elephant : IComparable, IAnimal, IWalker
    {
        public int age;
        public double height;
        public int weight;

        public Elephant(int age, double height, int weight)
        {
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        IAction walkAction;

        public Elephant()
        {
            walkAction = new WalkAction();
        }

        public void Walk()
        {
            walkAction.DoAction();
        }

        public int CompareTo(object obj)
        {
            Elephant e = obj as Elephant;

            if (e != null)
            {
                if (this.age < e.age)
                    return -1;
                else if (this.age > e.age)
                    return 1;
                else
                    return 0;
            }
            else
            {
                throw new Exception("Параметр должен быть типа Elephant");
            }
        }
    }

    class Swan : IAnimal, IWalker, ISwimmer, IFly
    {
        IAction walkAction;
        IAction flyAction;
        IAction swimAction;

        public Swan()
        {
            walkAction = new WalkAction();
            flyAction = new FlyAction();
            swimAction = new SwimAction();
        }

        public void Walk()
        {
            walkAction.DoAction();
        }

        public void Fly()
        {
            flyAction.DoAction();
        }

        public void Swim()
        {
            swimAction.DoAction();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ZooDirector director = new ZooDirector(Name: "John", Age: 53, ZooName: "some zoo");
            string info = Human.Info<ZooDirector>(director);
            Console.WriteLine(info);
            Console.WriteLine(new string('*', 30));

            var elephant = new Elephant();
            Console.Write("\nElephant can : ");
            elephant.Walk();
            Console.WriteLine("\nхарактеристика слонов до сортировки :");
            Console.WriteLine("age height weight");

            ArrayList elephants = new ArrayList();
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                Elephant eleph = new Elephant(rand.Next(1, 65), rand.Next(1, 3), rand.Next(120, 6000));
                elephants.Add(eleph);
                Console.WriteLine(eleph.age + "    " + eleph.height + "    " + eleph.weight);
            }

            elephants.Sort();  //сортируем возраст 
            Console.WriteLine("\nзначения после сортировки :");

            foreach (Elephant eleph in elephants)
            {
                Console.WriteLine(eleph.age + "    " + eleph.height + "    " + eleph.weight);
            }
            Console.WriteLine(new string('*', 30));

            var dog = new Dog("Rex", 10);
            IDoggy link = (IDoggy)dog;
            link.WriteName();
            link.WriteSpeed();
            Console.WriteLine("Speed [default] = {0}", dog);
            Console.WriteLine("Speed [mph] = {0}", dog.ToString("K", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine("Speed [k/h] =  {0}", dog.ToString("F", CultureInfo.CreateSpecificCulture("ru-RU")));

            Console.Write("\nDog can : ");
            dog.Walk();
            dog.Swim();
            Console.Write("\n");
            Console.WriteLine(new string('*', 30));

            var swan = new Swan();
            Console.Write("\nSwan can : ");
            swan.Walk();
            swan.Fly();
            swan.Swim();
            Console.ReadLine();
        }
    }
}