using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace HAPEasy
{
    class Program
    {
        static void Main(string[] args)
        {
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument document = web.Load("http://www.terfit.ru/life/lyubertsy/");

            //HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a[contains(@class, 'title')]").ToArray();
            //foreach (HtmlNode item in nodes)
            //{
            //    Console.WriteLine(item.InnerHtml);
            //}
            Person person = new Person();
            person.FirstName = 23;
            int number = person.FirstName;
            Console.WriteLine(number);
            Console.ReadKey();

        }

        private class Person
        {
            private int firstName=213;
            public int FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
        }

    }

}
