namespace MaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = parts[0];
            int cols = parts[1];
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            int maxSum = 0;
            int maxRowIndex = 0;
            int maxRowColumn = 0;
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRowIndex = i;
                        maxRowColumn = j;
                    }
                }
            }
            Console.WriteLine(maxSum);
            Console.WriteLine($"{matrix[maxRowIndex, maxRowColumn]} {matrix[maxRowIndex, maxRowColumn + 1]} {matrix[maxRowIndex, maxRowColumn + 2]}");
            Console.WriteLine($"{matrix[maxRowIndex + 1, maxRowColumn]} {matrix[maxRowIndex + 1, maxRowColumn + 1]} {matrix[maxRowIndex + 1, maxRowColumn + 2]}");
            Console.WriteLine($"{matrix[maxRowIndex + 2, maxRowColumn]} {matrix[maxRowIndex + 2, maxRowColumn + 1]} {matrix[maxRowIndex + 2, maxRowColumn + 2]}");
        }
    }
}
/*
4 5
1 5 5 2 4
2 1 4 14 3
3 7 11 2 8
4 8 12 16 4
 
 */