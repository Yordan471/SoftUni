using System;

namespace gameOfIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());
            double sum = 0;
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;
            int counter5 = 0;
            int counter6 = 0;

            for (int i = 1; i <= turns; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 50)
                {
                    sum /= 2;
                    counter6++;
                }

                if (number >= 0 && number <= 9)
                {
                    sum += number * 0.20;
                    counter1++;
                }
                else if (number >= 10 && number <= 19)
                {
                    sum += number * 0.30;
                    counter2++;
                }
                else if (number >= 20 && number <= 29)
                {
                    sum += number * 0.40;
                    counter3++;
                }
                else if (number >= 30 && number <= 39)
                {
                    sum += 50;
                    counter4++;
                }
                else if (number >= 40 && number <= 50)
                {
                    sum += 100;
                    counter5++;
                }
            }

            Console.WriteLine($"{sum:f2}");

            double numbersCounter1 = counter1 * 100.00 / turns;
            Console.WriteLine($"From 0 to 9: {numbersCounter1:f2}%");

            double numberCounter2 = counter2 * 100.00 / turns;
            Console.WriteLine($"From 10 to 19: {numberCounter2:f2}%");

            double numberCounter3 = counter3 * 100.00 / turns;
            Console.WriteLine($"From 20 to 29: {numberCounter3:f2}%");

            double numberCounter4 = counter4 * 100.00 / turns;
            Console.WriteLine($"From 30 to 39: {numberCounter4:f2}%");

            double numberCounter5 = counter5 * 100.00 / turns;
            Console.WriteLine($"From 40 to 50: {numberCounter5:f2}%");

            double numberCounter6 = counter6 * 100.00 / turns;
            Console.WriteLine($"Invalid numbers: {numberCounter6:f2}%");
            
        }
    }
}
