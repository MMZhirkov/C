using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace ConsoleTest
{
    class Program
    {

      
        static void Main(string[] args)
        {
            
            MyMusic MyCollection = new MyMusic();
            //выделили 3 ссылки на будущие объекты
            MyCollection.Tracks = new Track[3];

            MyCollection.Tracks[0] = new Track()
            {
                Artist = "Artist1",
                Album = "Album1",
                Title = "Title1",
                Year = "2015"
            };
            MyCollection.Tracks[1] = new Track()
            {
                Artist = "Artist2",
                Album = "Album2",
                Title = "Title2",
                Year = "2015"
            };
            MyCollection.Tracks[2] = new Track()
            {
                Artist = "Artist3",
                Album = "Album3",
                Title = "Title3",
                Year = "2015"
            };
            string serialized = JsonConvert.SerializeObject(MyCollection);
            Console.WriteLine(serialized);

            string json = serialized;
            MyMusic newMusic = JsonConvert.DeserializeObject<MyMusic>(json);
           
            foreach (var track in newMusic.Tracks)
            {
                Console.WriteLine(track.Artist);
            }
            Console.ReadLine();

        }
    }
   class MyMusic
    {
        //creat array objects class Track
        public Track[] Tracks { get; set; }
    }
   class Track
    {
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
    }
}
