using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.None);

            Queue<string> songs = new Queue<string>(
                Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
                

            while (songs.Count != 0)
            {
                string[] commands = Console.ReadLine()
                    .Split(new string[] {" "}, 2, StringSplitOptions.None);

                string operation = commands[0];

                if (operation == "Play" && songs.Count > 0)
                {
                    songs.Dequeue();

                    if (songs.Count == 0)
                    {
                        Console.WriteLine("No more songs!");
                        return;
                    }
                }
                else if (operation == "Add")
                {
                    string song = commands[1];

                    if (!(songs.Contains(song)))
                    {
                        songs.Enqueue(song);
                        continue;
                    }

                    Console.WriteLine($"{song} is already contained!");
                }
                else if (operation == "Show" && songs.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
        }
    }
}
