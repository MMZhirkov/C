using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dynamic array";

            int n;//number
            
            Console.Write("ENTER THE NUMBER OF ELEMENTS");
            n = int.Parse(Console.ReadLine());
            //initialize array
            int[] a = new int[n];

            Console.WriteLine("ENTER ELEMENTS OF ARRAY");
            for (int i=0;i<n;i++)
            {
                Console.Write("ENTER ELEMENT A ["+i+"]: ");
                a[i] = int.Parse(Console.ReadLine());
            }
            for (int i=0; i < a.Length; i++)
            {
                Console.Write(a[i] +" ");
            }
            Console.ReadKey();
        }
    }
}
