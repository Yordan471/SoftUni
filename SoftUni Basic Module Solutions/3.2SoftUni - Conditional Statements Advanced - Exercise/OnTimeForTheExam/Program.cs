using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int entryHours = int.Parse(Console.ReadLine());
            int entryMinutes = int.Parse(Console.ReadLine());

            string late = "Late";
            string onTime = "On Time";
            string early = "Early";

            int examHMinutes = examHours * 60;
            int entryHMinutes = entryHours * 60;

            int fullExamTime = examHMinutes + examMinutes;
            int fullEntryTime = entryHMinutes + entryMinutes;

            int TimeDiff = fullEntryTime - fullExamTime;

            string studentArrival = late;
            if (TimeDiff < -30)
            {
                studentArrival = early;
            }    
            else if (TimeDiff <= 30)
            {
                studentArrival = onTime;
            }
             

            string result = string.Empty;
            if (TimeDiff != 0)
            {
                int hoursDiff = Math.Abs(TimeDiff / 60);
                int minutesDiff = Math.Abs(TimeDiff % 60);

                if (hoursDiff > 0)
                {
                    result = string.Format("{0}:{1:00} hours",
                        hoursDiff, minutesDiff);
                }
                else
                {
                    result = minutesDiff + " minutes";
                }
                if (TimeDiff < 0)
                {
                    result += " before the start";
                } 
                else
                {
                    result += " after the start";
                }    
            }
            Console.WriteLine(studentArrival);
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }    
        }
    }
}
