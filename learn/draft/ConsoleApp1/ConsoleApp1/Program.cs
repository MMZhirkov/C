using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class A
    {
        virtual void Foo()
        {
            Console.Write("Class A");
        }
    }
    class B : A
    {
        override void Foo()
        {
            Console.Write("Class B");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B obj1 = new A();
            obj1.Foo();
        }
    }
}
