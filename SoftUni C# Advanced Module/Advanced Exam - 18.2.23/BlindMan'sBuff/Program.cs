using System.Linq;

int[] inputPlayGroundSize = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToArray();

string[,] playground = new string[inputPlayGroundSize[0], inputPlayGroundSize[1]];

int blindRow = 0;
int blindCol = 0;	

for (int row = 0; row < inputPlayGroundSize[0]; row++)
{
    string[] rowInput = Console.ReadLine()
		.Split(" ", StringSplitOptions.RemoveEmptyEntries);


	for (int col = 0; col < inputPlayGroundSize[1]; col++)
	{
		playground[row, col] = rowInput[col].ToString();

		if (playground[row, col] == "B")
		{
			blindRow = row;
			blindCol = col;
			playground[blindRow, blindCol] = "-";

        }
	}
}

string command = string.Empty;
int touchedOpponents = 0;
int movesMade = 0;

while (touchedOpponents != 3 && (command = Console.ReadLine()) != "Finish")
{
	string moveTo = command;
    bool hitObject = false;

	if (moveTo == "left" && blindCol - 1 >= 0 && playground[blindRow, blindCol - 1] != "O")
	{
		blindCol--;
	}
	else if (moveTo == "right" && blindCol + 1 < inputPlayGroundSize[1] && playground[blindRow, blindCol + 1] != "O")
	{
		blindCol++;
	}
	else if (moveTo == "up" && blindRow - 1 >= 0 && playground[blindRow - 1, blindCol] != "O")
	{
		blindRow--;
	}
	else if (moveTo == "down" && blindRow + 1 < inputPlayGroundSize[0] && playground[blindRow + 1, blindCol] != "O")
	{
		blindRow++;
	}
    else
    {
        hitObject = true;
    }

	if (playground[blindRow, blindCol] == "P")
	{
		touchedOpponents++;
		movesMade++;
		playground[blindRow, blindCol] = "-";

    }
	else if (playground[blindRow, blindCol] == "-" && hitObject != true)
	{
		movesMade++;
	}
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");

