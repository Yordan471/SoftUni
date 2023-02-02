using System.Data;
using System.Runtime.Serialization;

int sizeOfMatrix = int.Parse(Console.ReadLine());
string racingNumber = Console.ReadLine();

string[,] matrix = new string[sizeOfMatrix, sizeOfMatrix];

for (int row = 0; row < sizeOfMatrix; row++)
{
    string[] rowArray = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = rowArray[col];
    }
}

string command = string.Empty;
int saveRow = 0;
int saveCol = 0;
int kilometersPassed = 0;
bool finish = false;

while ((command = Console.ReadLine()) != "End")
{
    string movePosition = command;

    if (movePosition == "left")
    {
        if (CheckLeftOrRight(matrix, saveRow, saveCol - 1))
        {
            saveCol--;
            string nextPosition = matrix[saveRow, saveCol];

            kilometersPassed = GoingTo(nextPosition, kilometersPassed);
        }
    }
    else if (movePosition == "right")
    {
        if (CheckLeftOrRight(matrix, saveRow, saveCol + 1))
        {
            saveCol++;
            string nextPosition = matrix[saveRow, saveCol];

            kilometersPassed = GoingTo(nextPosition, kilometersPassed);
        }
    }
    else if (movePosition == "up")
    {
        if (CheckUpOrDown(matrix, saveRow - 1, saveCol))
        {
            saveRow--;
            string nextPosition = matrix[saveRow, saveCol];

            kilometersPassed = GoingTo(nextPosition, kilometersPassed);
        }
    }
    else if (movePosition == "down")
    {
        if (CheckUpOrDown(matrix, saveRow + 1, saveCol))
        {
            saveRow++;
            string nextPosition = matrix[saveRow, saveCol];

            kilometersPassed = GoingTo(nextPosition, kilometersPassed);
        }
    }

    if (matrix[saveRow, saveCol] == "F")
    {
        Console.WriteLine($"Racing car {racingNumber} finished the stage!");
        finish = true;
        matrix[saveRow, saveCol] = "C";
        break;
    }
    else if (matrix[saveRow, saveCol] == "T")
    {
        matrix[saveRow, saveCol] = ".";

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == "T")
                {
                    matrix[row, col] = ".";
                    saveRow = row;
                    saveCol = col;

                    break;
                }
            }
        }
    }
}

if (!finish)
{
    Console.WriteLine($"Racing car {racingNumber} DNF.");
    matrix[saveRow, saveCol] = "C";
}

Console.WriteLine($"Distance covered {kilometersPassed} km.");

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write($"{matrix[row, col]}"); 
    }

    Console.WriteLine();
}


bool CheckLeftOrRight(string[,] matrix, int saveRow, int saveCol)
{
    if (saveCol >= 0 && saveCol < matrix.GetLength(1))
    {
        return true;
    }

    return false;
}

bool CheckUpOrDown(string[,] matrix, int saveRow, int saveCol)
{
    if (saveRow >= 0 && saveRow < matrix.GetLength(1))
    {
        return true;
    }

    return false;
}

string[,] ThroughTunel(string[,] matrix, int saveRow, int saveCol)
{
    matrix[saveRow, saveCol] = ".";

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] == "T")
            {
                matrix[row, col] = ".";
                saveRow = row;
                saveCol = col;

                break;
            }
        }
    }

    return matrix;
}

int GoingTo(string nextPosition, int kilometersPassed)
{
    switch(nextPosition)
    {
        case ".":
            kilometersPassed += 10;
            break;
        case "T":
            kilometersPassed += 30;
           // matrix = ThroughTunel(matrix, saveRow, saveCol);
            break;
        case "F":           
            kilometersPassed += 10;
            break;
    }

    return kilometersPassed;
}

