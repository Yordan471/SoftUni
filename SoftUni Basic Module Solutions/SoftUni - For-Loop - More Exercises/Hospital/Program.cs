using System;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;
            int counter = 0;
            int treatedPatients = 0;
            int untreatedPatients = 0;
            
            for (int i = 1; i <= period; i++)
            {
                int patients = int.Parse(Console.ReadLine());

                counter++;
                               
                if (counter % 3 == 0)
                {
                    if (untreatedPatients > treatedPatients)
                    {
                        doctors++;
                    }
                }
                if (doctors >= patients)
                {
                    treatedPatients += patients;
                }
                else if (doctors < patients)
                {
                    treatedPatients += doctors;
                    untreatedPatients += (patients - doctors);
                }                         
            }
            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
