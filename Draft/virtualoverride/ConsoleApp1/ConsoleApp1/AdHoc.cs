using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DerivedClass:BaseClass
    {
        public void Method()
        {
            base.Method();
            Console.WriteLine("Method from DerivedClass");
        }
    }
}
