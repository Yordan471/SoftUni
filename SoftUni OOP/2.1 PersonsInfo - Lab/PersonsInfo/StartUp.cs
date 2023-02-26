using System.Threading.Channels;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new();

            for (int i = 0; i < lines; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new(personInfo[0], personInfo[1], int.Parse(personInfo[2]), decimal.Parse(personInfo[3]));
                persons.Add(person);
            }

            decimal parcentage = decimal.Parse(Console.ReadLine());

           //persons.ForEach(p => p.IncreaseSalary(parcentage));
           //persons.ForEach(p => Console.WriteLine(p.ToString()));

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team.FirstTeam.Count());
            Console.WriteLine(team.ReserveTeam.Count());
        }
    }
}
