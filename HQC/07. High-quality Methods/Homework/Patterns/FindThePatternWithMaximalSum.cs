namespace Patterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FindThePatternWithMaximalSum
    {
        public static void Main()
        {
            int[,] matrix = FillMatrix();
            long sum = long.MinValue;
            long bestSum = long.MinValue;
            ////int bestRow = 0;
            ////int bestCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 4; col++)
                {
                    if ((matrix[row, col] == matrix[row, col + 1] - 1) && (matrix[row, col + 1] == matrix[row, col + 2] - 1) && (matrix[row, col + 2] == matrix[row + 1, col + 2] - 1) && (matrix[row + 1, col + 2] == matrix[row + 2, col + 2] - 1) && (matrix[row + 2, col + 2] == matrix[row + 2, col + 3] - 1) && (matrix[row + 2, col + 3] == matrix[row + 2, col + 4] - 1))
                    {
                        sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col + 2] + matrix[row + 2, col + 2] + matrix[row + 2, col + 3] + matrix[row + 2, col + 4];
                    }

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        ////bestRow = row;
                        ////bestCol = col;
                    }
                }
            }

            if (bestSum == int.MinValue)
            {
                long diagonalSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    diagonalSum += matrix[row, row];
                }

                Console.WriteLine("NO {0}", diagonalSum);
            }
            else
            {
                Console.WriteLine("YES {0}", bestSum);
            }
        }

        private static int[,] FillMatrix()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                string rolStr = Console.ReadLine(); // ex. 1 2 3
                string[] emptySpace = new string[] { " " }; // remove from split empty space
                string[] colStrArray = rolStr.Split(emptySpace, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < colStrArray.Length; j++)
                {
                    matrix[i, j] = int.Parse(colStrArray[j]); // Input digits in array
                }
            }

            return matrix;
        }
    }
}
