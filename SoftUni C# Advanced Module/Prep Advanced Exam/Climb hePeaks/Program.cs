using System;

int[] dailyFoodPortion = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();

int[] dailyStamina = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();

Stack<int> foodPortions = new(dailyFoodPortion);
Queue<int> stamina = new(dailyStamina);
int days = 7;

Dictionary<int, string> diffLevelAndPeakName = new()
{
    { 80, "Vihren"},
    { 90, "Kutelo"},
    { 100, "Banski Suhodol"},
    { 60, "Polezhan"},
    { 70, "Kamenitza"},
};
List<int> heights = new() { 80, 90, 100, 60, 70};
List<string> conqueredPeaks = new();

while (foodPortions.Count != 0 && stamina.Count != 0 && 
    days != 0 && diffLevelAndPeakName.Count != 0)
{
    if (foodPortions.Peek() + stamina.Peek() >= heights[0])
    {
        conqueredPeaks.Add(diffLevelAndPeakName[heights[0]]);
        diffLevelAndPeakName.Remove(heights[0]);
        heights.Remove(heights[0]);
    }
    else
    {
        days--;
    }

    foodPortions.Pop();
    stamina.Dequeue();
}

if (diffLevelAndPeakName.Count > 0)
{
    Console.WriteLine($"Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}
else
{
    Console.WriteLine($"Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}

if (conqueredPeaks.Count > 0)
{
    Console.WriteLine("Conquered peaks:");

    for (int peak = 0; peak < conqueredPeaks.Count; peak++)
    {
        Console.WriteLine(conqueredPeaks[peak]);
    }
}
