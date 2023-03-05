using MilitaryElite;

string[] soldierInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string id = soldierInfo[1];
string firstName = soldierInfo[2];
string lastName = soldierInfo[3];   
decimal salary = decimal.Parse(soldierInfo[4]);
string corps = soldierInfo[5];

try
{
    Engineer engineer = new(id, firstName, lastName, salary, corps);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
