int sizeOfBattlefield = int.Parse(Console.ReadLine());

string[,] battlefield = new string[sizeOfBattlefield, sizeOfBattlefield];

int submarineRow = 0;
int submarineCol = 0;

ReadBattlefield(battlefield, ref submarineRow, ref submarineCol);

string command = string.Empty;
int destroyedBC = 0;
int minesHit = 0;
bool submarineIsDestroyed = false;
bool allBCDeestroyed = false;

while ((command = Console.ReadLine()) != null)
{
    string position = command;

    if (position == "left")
    {
        submarineCol--;
    }
    else if (position == "right")
    {
        submarineCol++;
    }
    else if (position == "up")
    {
        submarineRow--;
    }
    else if (position == "down")
    {
        submarineRow++;
    }

    if (battlefield[submarineRow, submarineCol] == "*")
    {
        battlefield[submarineRow, submarineCol] = "-";
        minesHit++;

        if (minesHit == 3)
        {
            submarineIsDestroyed = true;
            break;
        }
    }
    else if (battlefield[submarineRow, submarineCol] == "C")
    {
        battlefield[submarineRow, submarineCol] = "-";
        destroyedBC++;

        if (destroyedBC == 3)
        {
            allBCDeestroyed = true;
            break;
        }
    }
}

battlefield[submarineRow, submarineCol] = "S";

if (submarineIsDestroyed)
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
}
else if (allBCDeestroyed)
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}

PrintBattlefield(battlefield);

void PrintBattlefield(string[,] battlefield)
{
    for (int row = 0; row < battlefield.GetLength(0); row++)
    {
        for (int col = 0; col < battlefield.GetLength(1); col++)
        {
            Console.Write($"{battlefield[row, col]}");
        }

        Console.WriteLine();

    }
}

static void ReadBattlefield(string[,] battlefield, ref int submarineRow, ref int submarineCol)
{
    for (int row = 0; row < battlefield.GetLength(0); row++)
    {
        string rowInput = Console.ReadLine();

        for (int col = 0; col < battlefield.GetLength(1); col++)
        {
            battlefield[row, col] = rowInput[col].ToString();

            if (battlefield[row, col] == "S")
            {
                battlefield[row, col] = "-";
                submarineRow = row;
                submarineCol = col;
            }
        }
    }
}