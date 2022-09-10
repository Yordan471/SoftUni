using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutesCon = int.Parse(Console.ReadLine());
            int secondsCon = int.Parse(Console.ReadLine());
            double lengthU = double.Parse(Console.ReadLine());
            int secondFor100M = int.Parse(Console.ReadLine());

            double every120m = 2.5;

            double additionalTimeForEvery120M = (lengthU / 120) * every120m;
            double timeForLengthU = (lengthU / 100) * secondFor100M;
            double timeToFinish = timeForLengthU - additionalTimeForEvery120M;

            int minutesConInSeconds = minutesCon * 60;
            int timeInSecondForCon = minutesConInSeconds + secondsCon;

            if (timeToFinish <= timeInSecondForCon)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {timeToFinish:f3}.");
            }
            else if (timeToFinish > timeInSecondForCon)
            {
                double lessTimeNeeded = timeToFinish - timeInSecondForCon;
                Console.WriteLine($"No, Marin failed! He was {lessTimeNeeded:f3} second slower.");
            }           
        }
    }
}
