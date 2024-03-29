﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfRetangleMatrix = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = sizeOfRetangleMatrix[0];
            int cols = sizeOfRetangleMatrix[1];

            int[,] rectangleMatrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowArray = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    rectangleMatrix[row, col] = rowArray[col];
                }
            }

            int sum = -9999999;
            int saveSum = -9999999;
            string saveSquare = string.Empty;

            for (int row = 0; row < rectangleMatrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < rectangleMatrix.GetLength(1) - 2; col++)
                {                   
                    sum = rectangleMatrix[row, col] +
                        rectangleMatrix[row, col + 1] +
                        rectangleMatrix[row, col + 2] +
                        rectangleMatrix[row + 1, col] +
                        rectangleMatrix[row + 1, col + 1] +
                        rectangleMatrix[row + 1, col + 2] +
                        rectangleMatrix[row + 2, col] +
                        rectangleMatrix[row + 2, col + 1] +
                        rectangleMatrix[row + 2, col + 2];    
                    
                    if (saveSum < sum)
                    {
                        saveSum = sum;
                        saveSquare = $"{rectangleMatrix[row, col]} {rectangleMatrix[row, col + 1]} {rectangleMatrix[row, col + 2]}"+
                            $"\n{rectangleMatrix[row + 1, col]} {rectangleMatrix[row + 1, col + 1]} {rectangleMatrix[row + 1, col + 2]}"+
                            $"\n{rectangleMatrix[row + 2, col]} {rectangleMatrix[row + 2, col + 1]} {rectangleMatrix[row + 2, col + 2]}";
                    }                   
                }
            }

            Console.WriteLine($"Sum = {saveSum}");
            Console.WriteLine(saveSquare);
        }
    }
}
