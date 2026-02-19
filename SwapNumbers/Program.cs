namespace SwapNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] parts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = parts[0];
            int cols = parts[1];
            string[,] matrix = new string[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (input[0] == "swap")
                    {
                        int row1 = int.Parse(input[1]);
                        int col1 = int.Parse(input[2]);
                        int row2 = int.Parse(input[3]);
                        int col2 = int.Parse(input[4]);

                        string element = matrix[row1, col1];
                        string element2 = matrix[row2, col2];
                        matrix[row1, col1] = element2;
                        matrix[row2, col2] = element;
                        PrintMantrix(matrix);
                    }
                    else Console.WriteLine("Invalid input!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                }
                
            }
        }
        public static void PrintMantrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
/*
2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END

1 2
Hello World
0 0 0 1
swap 0 0 0 1
swap 0 1 0 0
END
 
 */