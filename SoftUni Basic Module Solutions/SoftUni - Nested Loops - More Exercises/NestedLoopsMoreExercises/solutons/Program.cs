using System;
using System.Globalization;

namespace solutons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture); // care for date letters
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var holydaysCount = 0;

            for (var date = startDate; date <= endDate; date = date.AddDays(1)) // have to reinitialie date + 1
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || // or not and
                    date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holydaysCount++;
                }
            }

            Console.WriteLine(holydaysCount);
        }
    }
}
