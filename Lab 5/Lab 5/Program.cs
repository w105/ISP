using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    abstract class Soul
    {
        protected string name, surname, age;
        public abstract void CreateMe();
        public abstract void YourSocialStatus();
    }

    class Human : Soul
    {
        protected string placeOfLiving;
        protected int livingWage;
        protected string socialStatus;

        public Human(string name, string surname, string age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public override void CreateMe()
        {
            Console.WriteLine("Создаём личность............");
        }

        public void GetSomeInfo(Human x)
        {
            x.PlaceOfLiving();
            x.I();
        }

        public virtual void I() { }

        public virtual void PlaceOfLiving() { }

        public static void Id()
        {
            Random rand = new Random();
            string[] id = new string[6];

            for (int i = 0; i < 6; i++)
            {
                id[i] = Convert.ToString(rand.Next(0, 9));
            }

            string singleString = String.Join("", id);
            Console.Write($"ID: {singleString}\n");
        }

        enum LivingWage
        {
            Low = 300,
            Middle = 600,
            High = 1000
        }

        public override void YourSocialStatus()
        {
            Console.Write("сколько в месяц вы получаете денег (в бел.руб)(источник не важен): ");
            livingWage = int.Parse(Console.ReadLine());

            if (livingWage <= (int)LivingWage.Low)
            {
                socialStatus = "no point continuing to live";
            }
            else if (livingWage >= (int)LivingWage.Low && livingWage <= (int)LivingWage.Middle)
            {
                socialStatus = "бедный класс";
            }
            else if (livingWage >= (int)LivingWage.Middle && livingWage <= (int)LivingWage.High)
            {
                socialStatus = "средний класс";
            }
            else
            {
                socialStatus = "богат";
            }
        }
    }


    struct School
    {
        string _schoolName;
        string _profileSubject;
        string _numberOfLearners;

        public string SchoolName
        {
            get
            {
                return _schoolName;
            }
            set
            {
                _schoolName = value;
            }
        }

        public string ProfileSubject
        {
            get
            {
                return _profileSubject;
            }
            set
            {
                _profileSubject = value;
            }
        }

        public string GetNumberOfLearners
        {
            get
            {
                return _numberOfLearners;
            }
        }

        public void NumberOfLearners()
        {
            Console.WriteLine("\nВ вашей школе:\n1.>1000 учащихся\n2.<1000 учащихся\n3.~1000 учащихся\n4.ввести точное кол-во");
            int choice;
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    _numberOfLearners = ">1000 учащихся";
                    break;

                case 2:
                    _numberOfLearners = "<1000 учащихся";
                    break;

                case 3:
                    _numberOfLearners = "~1000 учащихся";
                    break;

                case 4:
                    _numberOfLearners = Console.ReadLine();
                    break;
            }
        }

        public void GetInfoAboutSchool()
        {
            Console.Write($"Информация о школе учащегося:\n1.название школы: {_schoolName}\n2.профильный предмет в школе: {_profileSubject}" +
            $"\n3.кол-во учащихся в школе: {_numberOfLearners}\n");
        }
    }


    class SchoolBoy : Human
    {
        string _grade;
        string _averageMark;

        public School YourSchool = new School();

        public SchoolBoy(string name, string surname, string age) : base(name, surname, age) { }

        public override void PlaceOfLiving()
        {
            Console.Write("где вы живете:\n1.В квартире\n2.в доме за городом\n");
            int _choice = int.Parse(Console.ReadLine());

            switch (_choice)
            {
                case 1:
                    placeOfLiving = "В квартире";
                    break;

                case 2:
                    placeOfLiving = "в доме за городом";
                    break;
            }
        }

        public override void I()
        {
            Console.WriteLine("I'm a school boy");
        }

        public void Grade()
        {
            Console.Write("\nВ каком классе вы учитесь:");
            _grade = Console.ReadLine();
        }

        public void YourAverageMark()
        {
            Console.Write("Введите средний балл за четверть: ");
            _averageMark = Console.ReadLine();
        }

        public void SetInfoAboutSchool()
        {
            Console.Write("\nВведите название вашей школы: ");
            YourSchool.SchoolName = Console.ReadLine();

            Console.Write("\nКакой профильный предмет у вас в школе?: ");
            YourSchool.ProfileSubject = Console.ReadLine();

            Console.Write("\nСколько учащихся в школе: ");
            YourSchool.NumberOfLearners();
        }

        public void GetInfoAboutSchoolBoy()
        {
            Console.Clear();
            Console.WriteLine($"Информация о школьнике:\n1.фам. и имя: {surname} {name}\n2.возраст: {age}\n3.место проживания: {placeOfLiving}" +
            $"\n4.Класс: {_grade}\n5.Средний балл за четверть: {_averageMark}\n6.соц.статус: {socialStatus}");
            Human.Id();
            YourSchool.GetInfoAboutSchool();
        }
    }


    class Student : Human
    {
        string _workStatus;
        string _university;
        int _course;

        public Student(string name, string surname, string age) : base(name, surname, age) { }

        public override void PlaceOfLiving()
        {
            Console.Write("где вы живете:\n1.В квртире\n2.в общежитие\n");
            int _choice = int.Parse(Console.ReadLine());
            switch (_choice)
            {
                case 1:
                    placeOfLiving = "в квартире\n";
                    break;

                case 2:
                    placeOfLiving = "в общежитие\n";
                    break;
            }
        }

        public override void CreateMe()
        {
            Console.WriteLine("I'm a student");
        }

        public void Course()
        {
            Console.WriteLine("\nНа каком курсе обучения вы находитесь?");
            _course = int.Parse(Console.ReadLine());
        }

        public void University()
        {
            Console.WriteLine("\nВ каком университете вы учитесь?: ");
            Console.WriteLine("1.БГУИР\n2.БГУ\n3.БНТУ\n4.Другой университет");
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
            }
        }

        public void WorkStatus()
        {
            Console.WriteLine("Есть ли у вас работа: да/нет");
            string trueOrFalse = Console.ReadLine();

            _workStatus = trueOrFalse == "да" ? "имеет работу" : "без работы";
        }

        public void InforamationAboutStudent()
        {
            Console.Clear();
            Console.WriteLine($"информация о студенте:\n1.Фамилия и имя: {surname} {name}\n2.Возраст: {age}\n3.Место учебы: {_university}\n4.№ курса: {_course}\n5.workStatus: {_workStatus}\n6.соц.статуc: {socialStatus}");
            Human.Id();
        }
    }


    class WorkMan : Human
    {
        string _nameOfWork;
        string _currency;
        int _salary;
        int _timeWork;
        int _workExperience;

        public WorkMan(string name, string surname, string age) : base(name, surname, age) { }

        public void NameOfWork()
        {
            Console.Write("\nвведите название фирмы в которой вы работаете: ");
            _nameOfWork = Console.ReadLine();
        }

        public override void PlaceOfLiving()
        {
            Console.Write("где вы живете:\n1.В квартире\n2.в офисе\n");
            int _choice1 = int.Parse(Console.ReadLine());

            switch (_choice1)
            {
                case 1:
                    placeOfLiving = "в квартире";
                    break;

                case 2:
                    placeOfLiving = "в офисе";
                    break;
            }
        }

        public override void I()
        {
            Console.WriteLine("I'm a workMan");
        }

        public void SetInfoAboutWorkMan()
        {
            Console.WriteLine("\nв чем исчисляется ваша зп:\n1.USD\n2.BYN");
            int _choice = int.Parse(Console.ReadLine());

            Console.Write("введите вашу заработную плату: ");
            _salary = int.Parse(Console.ReadLine());

            switch (_choice)
            {
                case 1: _currency = "$"; break;
                case 2: _currency = "Br"; break;
            }

            Console.Write("сколько часов в день вы работаете: ");
            _timeWork = int.Parse(Console.ReadLine());

            Console.Write("опыт работы(в годах): ");
            _workExperience = int.Parse(Console.ReadLine());
        }

        public void GetInfoAboutWorkMan()
        {
            Console.Clear();
            Console.WriteLine($"Информация о сотруднике:\n1.фамилия и имя: {surname} {name}\n2.проживает: {placeOfLiving}\n3.место работы: {_nameOfWork}\n4.зп: {_salary}{_currency}" +
            $"\n5.время работы: {_timeWork} часов в день\n6.опыт работы: {_workExperience} года\n7.соц.статус: {socialStatus}");
            Human.Id();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name, surname, age;

            Human man = new Human("", "", "");
            man.CreateMe();

            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            surname = Console.ReadLine();

            Console.Write("Ваш возраст: ");
            age = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Вы......\n1.школьник\n2.студент\n3.рабочий");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    SchoolBoy schoolBoy = new SchoolBoy(name, surname, age);

                    schoolBoy.PlaceOfLiving();
                    schoolBoy.SetInfoAboutSchool();
                    schoolBoy.Grade();
                    schoolBoy.YourAverageMark();
                    schoolBoy.YourSocialStatus();
                    schoolBoy.GetInfoAboutSchoolBoy();
                    schoolBoy.GetSomeInfo(schoolBoy);
                    break;

                case 2:
                    Student student = new Student(name, surname, age);

                    student.PlaceOfLiving();
                    student.University();
                    student.Course();
                    student.WorkStatus();
                    student.YourSocialStatus();
                    student.InforamationAboutStudent();
                    student.GetSomeInfo(student);
                    break;

                case 3:
                    WorkMan workMan = new WorkMan(name, surname, age);

                    workMan.PlaceOfLiving();
                    workMan.NameOfWork();
                    workMan.SetInfoAboutWorkMan();
                    workMan.YourSocialStatus();
                    workMan.GetInfoAboutWorkMan();
                    workMan.GetSomeInfo(workMan);
                    break;
            }
            Console.ReadLine();
        }
    }
}