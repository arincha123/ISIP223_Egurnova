using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova


{ 
    class Person
    {
        private string FIO;
        private DateTime Birthday;
        private string Gender;

        public Person(string fio, DateTime birthday, string gender)
        {
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
        private int ID;
        private int CourseNum;

        public Student(int id, string fio, DateTime birthday, string gender, int CN)
            : base(fio, birthday, gender)
        {
            ID = id;
            CourseNum = CN;
        }

        public void Print()
        {
            base.Print();
            Console.WriteLine($"ID: {ID}\nНомер курса: {CourseNum}");
        }



    }












    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
