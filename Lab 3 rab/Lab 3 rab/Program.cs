using System;

namespace Lab_3_rab
{
    class Human
    {
        protected string name, surname, age;

        public Human(string name, string surname, string age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public string this[string choice]
        {
            get
            {
                switch (choice)
                {
                    case "name": return name;
                    case "surname": return surname;
                    case "age": return age;
                    default: return null;
                }
            }
            set
            {
                switch (choice)
                {
                    case "name": name = value; break;
                    case "surname": surname = value; break;
                    case "age": age = value; break;
                }
            }
        }

        public static void Id()
        {
            Random rand = new Random();
            string[] id = new string[6];

            for (int i = 0; i < 6; i++)
            {
                id[i] = Convert.ToString(rand.Next(0, 9));
            }

            string singleString = String.Join("", id);
            Console.Write("ID: {0}", singleString);
        }
    }

    class Student : Human
    {
        string _workStatus;
        string _university;
        int _course;
        bool _studStatus;

        public Student(string name, string surname, string age) : base(name, surname, age) { }

        public int Course
        {
            get
            {
                return _course;
            }
            set
            {
                if (value >= 1 && value <= 4)
                {
                    _course = value;
                }
            }
        }

        public bool University()
        {
            Console.WriteLine("1.БГУИР\n2.БГУ\n3.БНТУ\n4.Другой университет\n5.Не являюсь студентом");
            int _choice = int.Parse(Console.ReadLine());

            switch (_choice)
            {
                case 1:
                    _university = "БГУИР";
                    break;

                case 2:
                    _university = "БГУ";
                    break;

                case 3:
                    _university = "БНТУ";
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Введите название вашего университета: ");
                    _university = Console.ReadLine();
                    break;

                case 5:
                    _university = "Не является студентом";
                    _studStatus = true;
                    break;
            }
            return _studStatus == true ? true : false;
        }

        public void WorkStatus()
        {
            Console.WriteLine("Есть ли у вас работа: да/нет");
            string trueOrFalse = Console.ReadLine();

            _workStatus = trueOrFalse == "да" ? "имеет работу" : "без работы";
        }

        public void InforamationAboutStudent(string surname, string name, string age)
        {
            Console.Clear();

            if (_studStatus)
            {
                Console.WriteLine("Фамилия и имя: {0} {1}\nВозраст: {2}\nМесто учебы: {3}", surname, name, age, _university);
            }
            else
            {
                Console.WriteLine("Фамилия и имя: {0} {1}\nВозраст: {2}\nМесто учебы: {3}\n№ курса: {4}\nworkStatus: {5}", surname, name, age, _university, _course, _workStatus);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name, surname, age;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            surname = Console.ReadLine();

            Console.Write("Ваш возраст: ");
            age = Console.ReadLine();

            Student st1 = new Student(name, surname, age);

            do
            {
                Console.Clear();
                Console.WriteLine("1.Дополнить информацию о себе\n2.изменить информацию\n3.вывести информацию\n4.выйти");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nВ каком университете вы учитесь?: ");
                        bool check = st1.University();

                        if (!check)
                        {
                            Console.WriteLine("\nНа каком курсе обучения вы находитесь?");
                            st1.Course = int.Parse(Console.ReadLine());
                            st1.WorkStatus();
                        }
                        break;

                    case 2:
                        Console.WriteLine("Изменить:\n1.имя и фамилию\n2.возраст\n3.выйти");
                        int a = int.Parse(Console.ReadLine());

                        switch (a)
                        {
                            case 1:
                                Console.Write("имя:");
                                st1["name"] = Console.ReadLine();

                                Console.Write("фамилия:");
                                st1["surname"] = Console.ReadLine();
                                break;

                            case 2:
                                Console.Write("возраст:");
                                st1["age"] = Console.ReadLine();
                                break;

                            case 3: break;
                        }
                        break;

                    case 3:
                        name = st1["name"];
                        surname = st1["surname"];
                        age = st1["age"];
                        st1.InforamationAboutStudent(surname, name, age);
                        Student.Id();
                        Console.ReadLine();
                        break;

                    case 4: break;
                }

                if (choice == 4)
                {
                    break;
                }
            } while (true);
        }
    }
}