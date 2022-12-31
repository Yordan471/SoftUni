using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clothesToWear = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> colorAndClothesNumbers = new Dictionary<string, List<string>>(); 

            for (int i = 0; i < clothesToWear; i++)
            {
                string[] clothesInfo = Console.ReadLine()
                    .Split(new string[] { " -> " }, StringSplitOptions.None);

                string color = clothesInfo[0];
                string[] clothes = clothesInfo[1]
                    .Split(',');

                if (!(colorAndClothesNumbers.ContainsKey(color)))
                {
                    colorAndClothesNumbers[color] = new List<string>();
                }

                foreach (string cloth in clothes)
                {
                    colorAndClothesNumbers[color].Add(cloth);
                }
            }

            string[] colorCloth = Console.ReadLine()
                .Split(' ');

            string searchColor = colorCloth[0];
            string searchCloth = colorCloth[1];

            foreach (KeyValuePair<string, List<string>> color in colorAndClothesNumbers)
            {
                Console.WriteLine($"{color.Key} clothes:");

                List<string> clothesList = new List<string>();
                clothesList = color.Value.ToList();

                foreach (string clothes in clothesList.Distinct())
                {
                    int countClothes = 0;

                    for (int i = 0; i < color.Value.Count; i++)
                    {
                        if (clothes == color.Value[i])
                        {
                            countClothes++;
                        }
                    }

                    if (color.Key == searchColor && searchCloth == clothes)
                    {
                        Console.WriteLine($"* {clothes} - {countClothes} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes} - {countClothes}");
                    }                   
                }
            }
        }
    }
}
