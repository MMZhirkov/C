using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace @foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=4;
            int b=8;
            int k = a;
            for (int i = a; i <= b; i++)
            {
               
                k++;
                Console.Write( k);
                Console.WriteLine(i);
            }
            Console.ReadKey();
           

        }
    }
}
