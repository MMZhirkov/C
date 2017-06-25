using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //Создайте класс студент с полями - имя, курс, есть ли стипендия, конструктор с параметрами
    class Student
    {
        private string name;
        private int course;
        private float averageScore;
        private bool grant;

        public  Student()
        {
            name = "name";
            course = 0;
            averageScore = 0;
            Print();
        }
        public Student(string name, int course, float averageScore)
        {
            this.name = name;
            this.course = course;
            this.averageScore = averageScore;
            Print();
        }
        private void Print()
        {
            if (averageScore<=4)
            {
                grant = false;
            }
            else 
            {
                grant = true;
            }
            Console.WriteLine (name+course+grant);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Michael = new Student("Michael", 6, 5);
            Student Forma = new Student();
            Console.ReadKey();
        }
    }
}
