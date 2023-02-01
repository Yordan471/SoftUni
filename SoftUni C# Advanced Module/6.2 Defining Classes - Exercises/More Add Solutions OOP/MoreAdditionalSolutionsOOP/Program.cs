using System.Drawing;
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
                User currUser = new User();

                if (gatherContests.Any(c => c.ContestName == contestName && c.Password == password))
                {
                   //if (users.Count == 0)
                   //{
                   //    contest = new(contestName, password, points);
                   //    currUser = new();
                   //    currUser.UserName = userName;
                   //    currUser.ContestsPoints.Add(contest);
                   //    users.Add(currUser);
                   //    continue;
                   //}                   

                    if (users.Any(u => u.UserName == userName))
                    {
                        foreach (User user in users)
                        {
                            if (user.UserName == userName && user.ContestsPoints.Any(c => c.ContestName.Equals(contestName) && c.Points < points))

                            {
                                Contest removeContest = user.ContestsPoints.Where(c => c.ContestName.Equals(contestName)).FirstOrDefault();
                                user.ContestsPoints.Remove(removeContest);
                                user.ContestsPoints.Add(new Contest(contestName, password, points));
                                break;
                            }
                            else if (user.UserName == userName && !user.ContestsPoints.Any(x => x.ContestName == contestName))
                            {
                                contest = new(contestName, password, points);
                                user.ContestsPoints.Add(contest);
                                break;
                            }
                        }
                    }
                    else
                    {
                        contest = new(contestName, password, points);
                        currUser = new(userName);
                        currUser.ContestsPoints.Add(contest);
                        users.Add(currUser);
                    }                                                    
                }
            }

            int maxPoints = 0;
            int maxValue = -100000;
            string bestUser = string.Empty;
            foreach (var user in users)
            {
                foreach (var contest in user.ContestsPoints)
                {
                    maxPoints += contest.Points;
                }

                if (maxValue < maxPoints)
                {
                    maxValue = maxPoints;
                    bestUser = user.UserName;
                }

                maxPoints = 0;
            }
            
            Console.WriteLine($"Best candidate is {bestUser} with total {maxValue} points.");
            Console.WriteLine("Ranking:");

            foreach (User user in users.OrderBy(u => u.UserName))
            {
                Console.WriteLine($"{user.UserName}");

                foreach (var contest in user.ContestsPoints.OrderByDescending(p => p.Points))
                {
                    Console.WriteLine($"#  {contest.ContestName} -> {contest.Points}");
                }
            }
        }
    }

    public class Contest
    {
        public Contest()
        {
            this.Points = 0;
            this.ContestName = "test";
            this.Password= "password";
        }

        public Contest(string contestName, string password) : this()
        {
            this.ContestName = contestName;
            this.Password = password;
        }

        public Contest(string contestName, string password, int points) : this(contestName, password)
        {
            this.Points = points;
        }

        public int Points { get; set; }

        public string ContestName { get; set; }

        public string Password { get; set; }
    }

    public class User
    {
        public User()
        {
            this.UserName = string.Empty;
            this.ContestsPoints = new();
        }

        public User(string userName ) : this()
        {
            UserName = userName;
           // ContestsPoints = contestsPoints;
        }

        public string UserName { get; set; }
        
        public List<Contest> ContestsPoints { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"{this.UserName}");

            foreach (var contest in ContestsPoints)
            {
                sb.AppendLine($"# {contest.ContestName} -> {contest.Points}");
            }

            return sb.ToString().Trim();
        }
    }

}