 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var person = new Person
            {
                Age = 19,
                FirstName = "Andrew",
                LastName = "Men"
            };
            string jsonData = JsonConvert.SerializeObject(person);
            var person2 = JsonConvert.DeserializeObject<Person>(jsonData);

            Console.ReadKey();
        }
    }
}
