using System;

namespace Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int roomVolume = width * length * height;

            while (roomVolume > 0)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }
                roomVolume -= int.Parse(input);
            }
            if (roomVolume > 0)
            {
                Console.WriteLine($"{roomVolume} Cubic meters left.");
            }
            else
            {
                int absoluteRoomVolumeValue = Math.Abs(roomVolume);
                Console.WriteLine($"No more free space! You need {absoluteRoomVolumeValue} Cubic meters more.");
            }
        }
    }
}
