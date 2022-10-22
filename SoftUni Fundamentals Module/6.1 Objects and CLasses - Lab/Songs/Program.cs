using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            List<Songs> saveSongs = new List<Songs>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] informationToList = Console.ReadLine()
                    .Split('_')
                    .ToArray();

                Songs song = new Songs(informationToList[0],
                    informationToList[1], informationToList[2]);

                saveSongs.Add(song);
            }

            string listTypeOrAll = Console.ReadLine();

            if (listTypeOrAll == "all")
            {
                foreach (Songs Song in saveSongs)
                {
                    Console.WriteLine(Song.Name);
                }
            }
            else
            {
                foreach (Songs song in saveSongs)
                {
                    if (song.TypeList == listTypeOrAll)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Songs
    {
        public Songs(string typeList, string name, string time)
        {
            this.TypeList  = typeList;
            this.Name = name;
            this.Time = time;
        }

        public string TypeList { get; set; }    

        public string Name { get; set; }

        public string Time { get; set; }    
    }
}
