namespace DifferenceOfDiagonalsSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            int sumOfMainDiagonal = 0;
            //main diagonal
            for (int i = 0; i < n; i++)
            {
                sumOfMainDiagonal += matrix[i, i];
            }

            int sumSecondDiagonal = 0;
            //second diagonal
            for (int i = 0; i < n; i++)
            {
                sumSecondDiagonal += matrix[i, matrix.GetLength(1) - i - 1];
            }

            int diff = Math.Abs(sumOfMainDiagonal - sumSecondDiagonal);
            Console.WriteLine(diff);
        }
    }
}
/*
3
11 2 4
4 5 6
10 8 -12

*/