using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Michael", };
            var list = new List<string>();
            //foreach (var name in names)
            //{
            //    if (name.Contains("r"))
            //    {
            //        list.Add(name.ToUpper());
            //    }
            //}
            var query = names.Where(x => x.Contains("r")).Select(x=>x.ToUpper());
          
                Console.WriteLine(names.Where(x => x.Contains("r")).Select(x => x.ToUpper()));
           
            

            Console.ReadKey();
        }
    }
}
