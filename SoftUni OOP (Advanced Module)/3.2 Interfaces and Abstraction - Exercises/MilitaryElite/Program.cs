using MilitaryElite;
using MilitaryElite.Models.Enum;
using MilitaryElite.Models.Interfaces;

string[] soldierInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string rank = soldierInfo[0];
string id = soldierInfo[1];
string firstName = soldierInfo[2];
string lastName = soldierInfo[3];   

