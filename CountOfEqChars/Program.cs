namespace CountOfEqChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = parts[0];
            int cols = parts[1];
            char[,] matrix = new char[rows, cols];
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                char[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    char symbol = matrix[i, j];
                    if (symbol == matrix[i, j + 1] && symbol == matrix[i + 1, j] && symbol == matrix[i + 1, j + 1]) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
/*
3 4
A B B D
E B B B
I J B B


2 2
a b
c d

 */