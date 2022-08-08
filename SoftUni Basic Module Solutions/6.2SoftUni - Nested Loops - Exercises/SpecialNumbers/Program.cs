using System;

namespace SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // да мина през всички стойности от 1111 - 9999

            for (int i = 1111; i <= 9999; i++)
            {
                int iTwin = i;// за да не се променя стойността на i в цикъла,
                              // което би довело до грешки в кода.
                bool iIsSpecial = true;

                for (int j = 1; j <= 4; j++)
                {
                    int lastDigit = iTwin % 10; //търсим коя стойност за i остава без остатък

                    if (lastDigit == 0)
                    {
                        iIsSpecial = false;
                        break;
                    }

                    int remainder = n % lastDigit; 

                    if (remainder != 0)
                    {
                        iIsSpecial = false;
                        // i is not a special number;
                        break;
                    }
                    // променяме стойността на i от външния цикъл за да променим вътрешния
                    iTwin /= 10; //правим целочислено делене int/int и така губим
                             //последната цифра на четерицифреното число
                }

                if (iIsSpecial)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
