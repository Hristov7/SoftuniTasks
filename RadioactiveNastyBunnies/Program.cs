namespace RadioactiveNastyBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = parts[0];
            int cols = parts[1];

            string[,] matrix = new string[rows, cols];
            int rowIndexP = 0;
            int colIndexP = 0;

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'P')
                    {
                        rowIndexP = i;
                        colIndexP = j;
                    }
                    matrix[i, j] = line[j].ToString();
                }
            }
            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == 'U')
                {
                    rowIndexP--;
                    if (rowIndexP < 0)
                    {
                        Console.WriteLine($"won: {++rowIndexP} {colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    if (matrix[rowIndexP, colIndexP] == "B")
                    {
                        Console.WriteLine($"dead: {rowIndexP} {colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    SpreadBunnies(matrix);
                }
                else if (commands[i] == 'L')
                {
                    colIndexP--;
                    if (colIndexP < 0)
                    {
                        Console.WriteLine($"won: {rowIndexP} {++colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    if (matrix[rowIndexP, colIndexP] == "B")
                    {
                        Console.WriteLine($"dead: {rowIndexP} {colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    SpreadBunnies(matrix);
                }
                else if (commands[i] == 'R')
                {
                    colIndexP++;
                    if (colIndexP > matrix.GetLength(1) - 1)
                    {
                        Console.WriteLine($"won: {rowIndexP} {--colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    if (matrix[rowIndexP, colIndexP] == "B")
                    {
                        Console.WriteLine($"dead: {rowIndexP} {colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    SpreadBunnies(matrix);
                }
                else if (commands[i] == 'D')
                {
                    rowIndexP++;
                    if (rowIndexP > matrix.GetLength(0) - 1)
                    {
                        Console.WriteLine($"won: {--rowIndexP} {colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    if (matrix[rowIndexP, colIndexP] == "B")
                    {
                        Console.WriteLine($"dead: {rowIndexP} {colIndexP}");
                        SpreadBunnies(matrix);
                        break;
                    }
                    SpreadBunnies(matrix);
                }
            }
            PrintMatrix(matrix);
        }

        public static void SpreadBunnies(string[,] matrix)
        {
            bool[,] wasBunny = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    wasBunny[i, j] = matrix[i, j] == "B";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (wasBunny[i, j])
                    {
                        if (i != 0) matrix[i - 1, j] = "B";
                        if (i != matrix.GetLength(0) - 1) matrix[i + 1, j] = "B";
                        if (j != 0) matrix[i, j - 1] = "B";
                        if (j != matrix.GetLength(1) - 1) matrix[i, j + 1] = "B";
                    }
                }
            }
        }
        public static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
/*
5 8
.......B
...B....
....B..B
........
..P.....
ULLL

4 5
.....
.....
.B...
...P.
LLLLLLLL

 */