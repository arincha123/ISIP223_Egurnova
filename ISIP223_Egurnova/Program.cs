using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{ 
    class Person
    {
        private int ID {  get; set; }
        private string FIO { get; set; }
        private DateTime Birthday {  get; set; }
        private string Gender {  get; set; }

        public Person(string fio, DateTime birthday, string gender)
        {
            int ID = 1;
            FIO = fio;
            Birthday = birthday;
            Gender = gender;
        }

        public void Print()
        {
            Console.WriteLine($"ФИО: {FIO}\nДата рождения: {Birthday}\nПол: {Gender}");
        }
    }


    class Student : Person
    {
        public List<Courses> courses;

        public Student(int id, string fio, DateTime birthday, string gender)
            : base(fio, birthday, gender)
        {
            int newId = id;
            newId++;
            Courses courses = new Courses();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"ID: {newid}\nНомер курса: {CourseNum}");
        }

    }

    class Teacher : Person
    {
        public List <Courses> courses;

    }


    class Courses
    {

    }


    class System
    {

    }


    class Program
    {
        static void Main(string[] args)
        {
            System university = new System();

            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ УНИВЕРСИТЕТОМ ===");
            Console.WriteLine("1. Управление студентами");
            Console.WriteLine("2. Управление преподавателями");
            Console.WriteLine("3. Управление курсами");
            Console.WriteLine("4. Показать всех студентов");
            Console.WriteLine("5. Показать всех преподавателей");
            Console.WriteLine("6. Показать все курсы");
            Console.WriteLine("Выберите пункт: ");

            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    ManageS(university);
                    break;
                case 2:
                    ManageT(university);
                    break;
                case 3:
                    ManageC(university);
                    break;
                case 4:
                    ShowAllStud();
                    break;
                case 5:
                    ShowAllTeach();
                    break;
                case 6:
                    ShowAllCour();
                    break;
                default:
                    Console.WriteLine("Пункт неверен/неправильный");
                    break;
            }
        }
        static void ManageS(System university)
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ УНИВЕРСИТЕТОМ ===");
            Console.WriteLine("--- УПРАВЛЕНИЕ СТУДЕНТАМИ ---");
            Console.WriteLine("1. Показать всех студентов");
            Console.WriteLine("2. Добавить студента");
            Console.WriteLine("3. Удалить студента");
            Console.WriteLine("4. Записать студента на курс");
            Console.WriteLine("Выберите пункт: ");

            int s = Convert.ToInt32(Console.ReadLine());
            switch (s)
            {
                case 1:
                    ShowAllStud();
                    break;
                case 2:
                    AddStud();
                    break;
                case 3:
                    RemStud();
                    break;
                case 4:
                    SignUpC();
                    break;
                default:
                    Console.WriteLine("Пункт неверен/неправильный");
                    break;
            }
        }
        static void ManageT(System university)
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ УНИВЕРСИТЕТОМ ===");
            Console.WriteLine("--- УПРАВЛЕНИЕ ПРЕПОДАВАТЕЛЯМИ ---");
            Console.WriteLine("1. Показать всех преподавателей");
            Console.WriteLine("2. Добавить преподавателя");
            Console.WriteLine("3. Удалить преподавателя");
            Console.WriteLine("4. Добавить преподавателю курс");
            Console.WriteLine("Выберите пункт: ");

            int t = Convert.ToInt32(Console.ReadLine());
            switch (t)
            {
                case 1:
                    ShowAllTeach();
                    break;
                case 2:
                    AddTeach();
                    break;
                case 3:
                    RemTeach();
                    break;
                case 4:
                    SignUpT();
                    break;
                default:
                    Console.WriteLine("Пункт неверен/неправильный");
                    break;
            }
        }
        static void ManageC(System university)
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ УНИВЕРСИТЕТОМ ===");
            Console.WriteLine("--- УПРАВЛЕНИЕ КУРСАМИ ---");
            Console.WriteLine("1. Показать все курсы");
            Console.WriteLine("2. Добавить курс");
            Console.WriteLine("3. Удалить курс");
            Console.WriteLine("Выберите пункт: ");

            int t = Convert.ToInt32(Console.ReadLine());
            switch (t)
            {
                case 1:
                    ShowAllCour();
                    break;
                case 2:
                    AddCour();
                    break;
                case 3:
                    RemCour();
                    break;
                case 4:
                    SignUpT();
                    break;
                default:
                    Console.WriteLine("Пункт неверен/неправильный");
                    break;
            }
        }

















    }
}
