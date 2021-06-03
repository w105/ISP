using System;
using System.Collections;
using System.Globalization;

namespace Lab_8
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

        public Human(string name, int age)
        {
            Name = name;
            Age = age;
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
        public ZooDirector(string name, int age, string zooName) : base(name, age)
        {
            ZooName = zooName;
        }

        public string ZooName { get; set; }

        public override string ToString()
        {
            return String.Format($"\nИнформация о директоре зоопарка:\nИмя: {Name}\nВозраст: {Age}\nназвание зоопарка: {ZooName}");
        }
    }

    class Feed
    {
        public delegate void EventHandler(string message);
        public static event EventHandler NotifyFeed;

        public static int FeedAmount { get; private set; }

        public Feed()
        {
            FeedAmount = 100;
        }

        public static void Worker()
        {
            for (int i = FeedAmount; i >= 0; i--)
            {
                if (FeedAmount == 0)
                {
                    NotifyFeed?.Invoke("Alert: Закончился корм");
                }

                FeedAmount--;
            }
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
        public delegate void Eleph(string message);
        public event Eleph Notify;

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
            Notify?.Invoke("\nAlert: В зоопарк прибыли слоны");
        }

        public delegate void Abilities();

        public static void CanFly()
        {
            Console.WriteLine("Создатель наделил слонов возможностью летать");
        }

        public static void CanSwim()
        {
            Console.WriteLine("Cоздатель дал слонам способость плавать");
        }

        public static void GiveAction(Abilities mes)
        {
            mes?.Invoke();
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
            Console.Clear();
            Console.WriteLine(new string('*', 30));

            string name = "";
            int age = 0;

            try
            {
                Console.Write("Введите имя директора: ");
                name = Console.ReadLine();
                Console.Write("Введите возраст директора: ");
                age = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОШИБКА: В поле \"возраст\" вы не указали число");
            }

            ZooDirector director = new ZooDirector(name, age, "some zoo");
            string info = Human.Info<ZooDirector>(director);
            Console.WriteLine(info);
            Console.WriteLine(new string('*', 30));

            var elephant = new Elephant();

            elephant.Notify += delegate (string message)
            {
                Console.WriteLine(message);
            };

            Console.Write("\nElephant can : ");
            elephant.Walk();
            Random rnd = new Random();
            int value = rnd.Next(1, 3);

            if (value == 1)
            {
                Elephant.GiveAction(Elephant.CanFly);
            }
            else
            {
                Elephant.GiveAction(Elephant.CanSwim);
            }

            ArrayList elephants = new ArrayList();
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                Elephant eleph = new Elephant(rand.Next(1, 65), rand.Next(1, 3), rand.Next(120, 6000));
                elephants.Add(eleph);
            }

            elephants.Sort();  //сортируем возраст 
            Console.WriteLine("\nзначения после сортировки :");
            Console.WriteLine("age height weight");

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

            Feed.NotifyFeed += mes => Console.WriteLine(mes);
            Feed.Worker();

            var swan = new Swan();
            Console.Write("\nSwan can : ");
            swan.Walk();
            swan.Fly();
            swan.Swim();
            Console.ReadLine();
        }
    }
}