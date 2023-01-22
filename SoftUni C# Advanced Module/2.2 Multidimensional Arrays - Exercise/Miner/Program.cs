using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] movements = Console.ReadLine()
                .Split(' ');

            char[,] field = new char[fieldSize, fieldSize];
            int countCoals = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] inputForRow = Console.ReadLine()
                    .Split(' ');
                char[] rowArray = inputForRow.Select(x => char.Parse(x)).ToArray();
                    
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowArray[col];

                    if (rowArray[col] == 'c')
                    {
                        countCoals++;
                    }
                }
            }

            bool end = false;
            bool zeroCoals = false;
            bool action = false;
            int saveIndexRow = 0;
            int saveIndexCol = 0;
            int countMovements = 0;

            while (true)
            {
                if (zeroCoals)
                {
                    Console.WriteLine($"You collected all coals! ({saveIndexRow}, {saveIndexCol})");
                    break;
                }
                else if (end)
                {
                    Console.WriteLine($"Game over! ({saveIndexRow}, {saveIndexCol})");
                    break;
                }
                else if (countMovements == movements.Length && end == false && zeroCoals == false)
                {
                    Console.WriteLine($"{countCoals} coals left. ({saveIndexRow}, {saveIndexCol})");
                    break;
                }

                if (movements[countMovements] == "up")
                {
                    countMovements++;

                    for (int row = 0; row < field.GetLength(0); row++)
                    {
                        for (int col = 0; col < field.GetLength(1); col++)
                        {
                            if (row - 1 >= 0 && row - 1 < field.GetLength(0))
                            {
                                if (field[row, col] == 's')
                                
                                {
                                    if (field[row - 1, col] == '*')
                                    {
                                        field[row - 1, col] = 's';
                                        field[row, col] = '*';
                                        saveIndexRow = row - 1;
                                        saveIndexCol = col;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row - 1, col] == 'c')
                                    {
                                        field[row - 1, col] = 's';
                                        field[row, col] = '*';
                                        countCoals--;

                                        if (countCoals == 0)
                                        {
                                            saveIndexRow = row - 1;
                                            saveIndexCol = col;
                                            zeroCoals = true;
                                            action = true;
                                            break;
                                        }

                                        saveIndexRow = row - 1;
                                        saveIndexCol = col;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row - 1, col] == 'e')
                                    {
                                        saveIndexRow = row - 1;
                                        saveIndexCol = col;
                                        end = true;
                                        action = true;
                                        break;
                                    }                                  
                                }
                            }                            
                        }

                        if (action)
                        {
                            action  = false;    
                            break;
                        }
                    }
                }
                else if (movements[countMovements] == "down")
                {
                    countMovements++;

                    for (int row = 0; row < field.GetLength(0); row++)
                    {
                        for (int col = 0; col < field.GetLength(1); col++)
                        {
                            if (row + 1 >= 0 && row + 1 < field.GetLength(0))
                            {
                                if (field[row, col] == 's')

                                {
                                    if (field[row + 1, col] == '*')
                                    {
                                        field[row + 1, col] = 's';
                                        field[row, col] = '*';
                                        saveIndexRow = row + 1;
                                        saveIndexCol = col;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row + 1, col] == 'c')
                                    {
                                        field[row + 1, col] = 's';
                                        field[row, col] = '*';
                                        countCoals--;

                                        if (countCoals == 0)
                                        {
                                            saveIndexRow = row + 1;
                                            saveIndexCol = col;
                                            zeroCoals = true;
                                            action = true;
                                            break;
                                        }

                                        saveIndexRow = row + 1;
                                        saveIndexCol = col;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row + 1, col] == 'e')
                                    {
                                        saveIndexRow = row + 1;
                                        saveIndexCol = col;
                                        end = true;
                                        action = true;
                                        break;
                                    }                                  
                                }
                            }
                        }

                        if (action)
                        {
                            action = false;
                            break;
                        }
                    }
                }
                else if (movements[countMovements] == "right")
                {
                    countMovements++;

                    for (int row = 0; row < field.GetLength(0); row++)
                    {
                        for (int col = 0; col < field.GetLength(1); col++)
                        {
                            if (col + 1 >= 0 && col + 1 < field.GetLength(1))
                            {
                                if (field[row, col] == 's')

                                {
                                    if (field[row, col + 1] == '*')
                                    {
                                        field[row, col + 1] = 's';
                                        field[row, col] = '*';
                                        saveIndexRow = row;
                                        saveIndexCol = col + 1;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row, col + 1] == 'c')
                                    {
                                        field[row, col + 1] = 's';
                                        field[row, col] = '*';
                                        countCoals--;

                                        if (countCoals == 0)
                                        {
                                            saveIndexRow = row;
                                            saveIndexCol = col + 1;
                                            zeroCoals = true;
                                            action = true;
                                            break;
                                        }

                                        saveIndexRow = row;
                                        saveIndexCol = col + 1;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row, col + 1] == 'e')
                                    {
                                        end = true;
                                        saveIndexRow = row;
                                        saveIndexCol = col + 1;
                                        action = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (action)
                        {
                            action = false;
                            break;
                        }
                    }
                }
                else if (movements[countMovements] == "left")
                {
                    countMovements++;

                    for (int row = 0; row < field.GetLength(0); row++)
                    {
                        for (int col = 0; col < field.GetLength(1); col++)
                        {
                            if (col - 1 >= 0 && col - 1 < field.GetLength(1))
                            {
                                if (field[row, col] == 's')

                                {
                                    if (field[row, col - 1] == '*')
                                    {
                                        field[row, col - 1] = 's';
                                        field[row, col] = '*';
                                        saveIndexRow = row;
                                        saveIndexCol = col - 1;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row, col - 1] == 'c')
                                    {
                                        field[row, col - 1] = 's';
                                        field[row, col] = '*';
                                        countCoals--;

                                        if (countCoals == 0)
                                        {
                                            saveIndexRow = row;
                                            saveIndexCol = col - 1;
                                            zeroCoals = true;
                                            action = true;
                                            break;
                                        }

                                        saveIndexRow = row;
                                        saveIndexCol = col - 1;
                                        action = true;
                                        break;
                                    }
                                    else if (field[row, col - 1] == 'e')
                                    {
                                        saveIndexRow = row;
                                        saveIndexCol = col - 1;
                                        end = true;
                                        action = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (action)
                        {
                            action = false;
                            break;
                        }
                    }
                }
            }
        } 
    }
}
