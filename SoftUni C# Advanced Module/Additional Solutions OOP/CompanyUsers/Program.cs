using System.Text;

namespace CompanyUsers
{
    public class Program
    {
        public static void Main()
        {
            string command = string.Empty;

            List<Company> companies = new List<Company>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] companyInfo = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string companyName = companyInfo[0];
                string id = companyInfo[1];

                if (!companies.Any(c => c.CompanyName.Equals(companyName)))
                {
                    Company company = new(companyName);
                    company.employeeIDs.Add(id);
                    companies.Add(company);
                    continue;
                }

                companies
                    .Find(c => c.CompanyName
                    .Equals(companyName))
                    .employeeIDs.Add(id);
            }

            foreach (Company company in companies)
            {
                Console.WriteLine(company);             
            }
        }
    }

    public class Company
    {
        public Company()
        {
            this.CompanyName = string.Empty;
            this.employeeIDs = new();
        }

        public Company(string CompanyName) : this()
        {
            this.CompanyName = CompanyName;
        }

        public string CompanyName { get; set; }

        public HashSet<string> employeeIDs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine(this.CompanyName);

            foreach(string employee in employeeIDs)
            {
                sb.AppendLine($"-- {employee}");
            }

            return sb.ToString().Trim();
        }
    }
}