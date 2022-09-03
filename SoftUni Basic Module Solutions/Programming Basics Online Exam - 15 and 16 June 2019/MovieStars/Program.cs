using System;

namespace MovieStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double actorsBudget = double.Parse(Console.ReadLine());

            double usingActorsBudget = actorsBudget;
            double sumToPayForActors = 0;
            double lessOrEqualThen15 = 0;
            double biggerThen15 = 0;
            bool notEnoug = false;
            bool action = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "ACTION")
                {
                    action = true;
                    break;
                }

                string actorName = command;

                if (actorName.Length > 15)
                {
                    biggerThen15 += usingActorsBudget * 0.20;
                    usingActorsBudget -= biggerThen15;
                    sumToPayForActors += biggerThen15;
                }
                else if (actorName.Length <= 15)
                {
                    lessOrEqualThen15 += double.Parse(Console.ReadLine());
                    usingActorsBudget -= lessOrEqualThen15;
                    sumToPayForActors += lessOrEqualThen15;
                }

                if (sumToPayForActors > actorsBudget)
                {
                    notEnoug = true;
                    break;
                }

                lessOrEqualThen15 = 0;
                biggerThen15 = 0;
            }

            if (action)
            {
                double leftBudget = actorsBudget - sumToPayForActors;
                Console.WriteLine($"We are left with {leftBudget:f2} leva.");
            }
            else if (notEnoug)
            {
                double budgetNeeded = sumToPayForActors - actorsBudget;
                Console.WriteLine($"We need {budgetNeeded:f2} leva for our actors.");
            }
        }
    }
}
