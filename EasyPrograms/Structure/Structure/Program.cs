using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure
{
    class Program
    {   
        struct  Student
        {
            public string name;
            public int date;
        }
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter number students");
            n = int.Parse(Console.ReadLine());
            Student[] st = new Student[n];

            for (int i = 0; i < st.Length; i++)
            {
                Console.WriteLine("Enter name student");
                st[i].name = Console.ReadLine();
                Console.WriteLine("Enter data born");
                st[i].date = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < st.Length; i++)
            {
                Console.WriteLine(st[i].name);
                Console.WriteLine(st[i].date);
            }

            //Console.WriteLine("Enter name student");
            //st.name = Console.ReadLine();
            //Console.WriteLine("Enter date");
            //st.date = int.Parse(Console.ReadLine());
            //Console.WriteLine("Name{0}\n Date{1}",st.name,st.date);
            Console.ReadKey();
        }
        
    }
}
