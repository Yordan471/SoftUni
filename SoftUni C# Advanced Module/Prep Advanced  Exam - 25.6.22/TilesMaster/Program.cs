using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesMaster
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] areOfWhiteTiles = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(num => int.Parse(num))
                .ToArray();

            int[] areOfGreyTiles = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(num => int.Parse(num))
                .ToArray();

            Queue<int> greyTiles = new Queue<int>(areOfGreyTiles);
            Stack<int> whiteTiles = new Stack<int>(areOfWhiteTiles);

            Dictionary<int, string> areaAndLocation = 
                new Dictionary<int, string>
            {
                { 40, "Sink" },
                { 50, "Oven" },
                { 60, "Countertop" },
                { 70, "Wall" }
            };

            Dictionary<string, int> locationAndCount = 
                new Dictionary<string, int>();

            while (greyTiles.Count != 0 && whiteTiles.Count != 0)
            {
                if (greyTiles.Peek() != whiteTiles.Peek())
                {
                    int countS = 0;
                    int[] saveStack = new int[whiteTiles.Count];
                    saveStack[whiteTiles.Count - 1] = whiteTiles.Pop() / 2;

                    while(whiteTiles.Count != 0)
                    {
                        countS++;
                        saveStack[saveStack.L - 1 - countS] = whiteTiles.Pop();
                    }

                    whiteTiles = new Stack<int>(saveStack);

                    int countQ = 0;
                    int[] saveQueue = new int[greyTiles.Count];
                    saveQueue[greyTiles.Count - 1] = greyTiles.Dequeue();

                    while (greyTiles.Count != 0)
                    {
                        saveQueue[countQ++] = greyTiles.Dequeue();
                    }

                    greyTiles = new Queue<int>(saveQueue);
                    continue;
                }

                int tileArea = greyTiles.Peek() + whiteTiles.Peek();
             
                if (!areaAndLocation.ContainsKey(tileArea))            
                {
                    if (!locationAndCount.ContainsKey("Floor"))
                    {
                        locationAndCount.Add("Floor", 0);
                    }

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                    locationAndCount["Floor"]++;
                    continue;
                }

                foreach(var area in areaAndLocation)
                {
                    if (area.Key == tileArea)
                    {
                        if (!locationAndCount.ContainsKey(area.Value))
                        {
                            locationAndCount.Add(area.Value, 0);
                            continue;
                        }

                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                        locationAndCount[area.Value]++;
                    }      
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var location in locationAndCount.
                OrderByDescending(c => c.Value)
                .ThenBy(l => l.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
