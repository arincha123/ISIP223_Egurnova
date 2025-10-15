using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{ 
    class Person
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }

        public Person(int id, string fio, DateTime birthday, string gender)
        {
            ID = id;
            FIO = fio;
            Birthday = birthday;
            Gender = gender;
        }

        public virtual void Print()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"ФИО: {FIO}");
            Console.WriteLine($"Дата рождения: {Birthday:dd.MM.yyyy}");
            Console.WriteLine($"Пол: {Gender}");
        }

        public int GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (Birthday.Date > today.AddYears(-age)) age--;
            return age;
        }

        public static DateTime EnterBirthdayManual()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите дату рождения (дд.мм.гггг): ");
                    string input = Console.ReadLine();

                    DateTime birthday = DateTime.ParseExact(input, "dd.MM.yyyy", null);

                    if (birthday > DateTime.Today)
                    {
                        Console.WriteLine("Дата рождения не может быть в будущем! Попробуйте снова.");
                        continue;
                    }

                    if (birthday < DateTime.Today.AddYears(-100))
                    {
                        Console.WriteLine("Возраст слишком большой! Попробуйте снова.");
                        continue;
                    }

                    return birthday;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат! Введите дату в формате дд.мм.гггг (например, 15.05.2000)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}. Попробуйте снова.");
                }
            }
        }
    }


    class Student : Person
    {
        public List <Course> Courses { get; set; }

        public Student(int id, string fio, DateTime birthday, string gender)
            : base(id, fio, birthday, gender)
        {
            Courses = new List<Course>();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Возраст: {GetAge()}");
            Console.WriteLine("Курсы:");
            if (Courses.Count == 0)
            {
                Console.WriteLine("  Не записан на курсы");
            }
            else
            {
                foreach (var course in Courses)
                {
                    Console.WriteLine($"  - {course.Name}");
                }
            }
            Console.WriteLine();
        }

    }

    class Teacher : Person
    {
        public List<Course> Courses { get; set; }

        public Teacher(int id, string fio, DateTime birthday, string gender)
            : base(id, fio, birthday, gender)
        {
            Courses = new List<Course>();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Возраст: {GetAge()}");
            Console.WriteLine("Ведет курсы:");
            if (Courses.Count == 0)
            {
                Console.WriteLine("  Не назначен на курсы");
            }
            else
            {
                foreach (var course in Courses)
                {
                    Console.WriteLine($"  - {course.Name}");
                }
            }
            Console.WriteLine();
        }

    }


    class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public Course(int id, string name)
        {
            ID = id;
            Name = name;
            Teacher = null;
            Students = new List<Student>();
        }

        public void Print()
        {
            Console.WriteLine($"ID курса: {ID}");
            Console.WriteLine($"Название: {Name}");

            if (Teacher != null)
            {
                Console.WriteLine($"Преподаватель: {Teacher.FIO}");
            }
            else
            {
                Console.WriteLine("Преподаватель: Не назначен");
            }

            Console.WriteLine($"Количество студентов: {Students.Count}");
            Console.WriteLine("Студенты:");
            if (Students.Count == 0)
            {
                Console.WriteLine("  Нет записанных студентов");
            }
            else
            {
                foreach (var student in Students)
                {
                    Console.WriteLine($"  - {student.FIO}");
                }
            }
            Console.WriteLine();
        }
    }


    class System
    {
        private List<Student> students;
        private List<Teacher> teachers;
        private List<Course> courses;
        private int studentIdCounter;
        private int teacherIdCounter;
        private int courseIdCounter;

        public System()
        {
            students = new List<Student>();
            teachers = new List<Teacher>();
            courses = new List<Course>();
            studentIdCounter = 1;
            teacherIdCounter = 1;
            courseIdCounter = 1;
        }
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
