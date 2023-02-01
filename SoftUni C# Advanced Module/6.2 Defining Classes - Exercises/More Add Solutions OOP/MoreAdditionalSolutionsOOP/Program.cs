using System.Text;

namespace Ranking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string firstCommand = string.Empty;
            List<Contest> gatherContests = new();
            while ((firstCommand= Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = firstCommand
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contestName = contestInfo[0];
                string password = contestInfo[1];

                if (!gatherContests.Any(c => c.ContestName == contestName))
                {
                    Contest contest = new(contestName, password);
                    gatherContests.Add(contest);
                    continue;
                }
            }

            string secondCommand = string.Empty;

            List<User> users = new();

            while ((secondCommand = Console.ReadLine()) != "end of submissions")
            {
                string[] userInfp = secondCommand
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contestName = userInfp[0];
                string password = userInfp[1];
                string userName = userInfp[2];
                int points = int.Parse(userInfp[3]);

                Contest contest = new();

                if (gatherContests.Any(c => c.ContestName == contestName && c.Password == password))
                {
                    if (users.Count == 0)
                    {
                        contest = new(contestName, password);
                        User user = new();
                        user.UserName = userName;
                        user.ContestsPoints.Add(contest, points);
                        users.Add(user);
                        continue;
                    }

                    foreach (User user in users)
                    {
                        if (user.UserName == userName && user.ContestsPoints
                            .Any(c => c.Key.ContestName == contestName && c.Value < points))
                        {
                            user.ContestsPoints.Remove(contest);
                            contest = new(contestName, password);
                            user.ContestsPoints.Add(contest, points);
                            //contest = new(contestName, password);
                            //user.Contests.Add(contest);
                            break;
                        }

                        //user.Points = points;
                        contest = new(contestName, password);
                        user.ContestsPoints.Add(contest, points);
                        users.Add(user);
                        break;
                    }
                }
            }

            foreach (User user in users.OrderByDescending(u => u.ContestsPoints.Values.Average()))
            {
                Console.WriteLine($"Best candidate is {user.UserName.First()} with total {user.ContestsPoints.Values.Sum()}");
            }
            
            foreach (User user in users.OrderBy(u => u.UserName))
            {
                Console.WriteLine(user);
            }
        }
    }

    public class Contest
    {
        public Contest()
        {
            this.ContestName = "test";
            this.Password= "password";
        }

        public Contest(string contestName, string password) : this()
        {
            this.ContestName = contestName;
            this.Password = password;
        }

        public string ContestName { get; set; }

        public string Password { get; set; }
    }

    public class User
    {
        public User()
        {
            this.UserName = string.Empty;
            this.Points = 0;
            this.ContestsPoints = new();
        }

        public string UserName { get; set; }

        public int Points { get; set; }
        
        public Dictionary<Contest, int> ContestsPoints { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{this.UserName}");

            foreach (var contest in ContestsPoints)
            {
                sb.AppendLine($"# {contest.Key} -> {contest.Value}");
            }

            return sb.ToString().Trim();
        }
    }

}