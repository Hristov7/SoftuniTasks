namespace Minor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int countOfAllCounts = 0;
            int rowIndex = 0;
            int colIndex = 0;

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < n; i++)
            {
                char[] chars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                countOfAllCounts += chars.Where(x => x == 'c').Count();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = chars[j];
                    if (chars[j] == 's')
                    {
                        rowIndex = i;
                        colIndex = j;
                    }
                }
            }
            int countOfCollectedCoals = 0;
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (rowIndex != 0)
                        {
                            rowIndex--;
                            char symbol = matrix[rowIndex, colIndex];
                            matrix[rowIndex, colIndex] = '*';
                            if (symbol == 'c')
                            {
                                countOfCollectedCoals++;
                                if (countOfCollectedCoals == countOfAllCounts)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    Environment.Exit(0);
                                }
                            }
                            else if (symbol == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        break;

                    case "right":
                        if (colIndex != matrix.GetLength(1) - 1)
                        {
                            colIndex++;
                            char symbol = matrix[rowIndex, colIndex];
                            matrix[rowIndex, colIndex] = '*';
                            if (symbol == 'c')
                            {
                                countOfCollectedCoals++;
                                if (countOfCollectedCoals == countOfAllCounts)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    Environment.Exit(0);
                                }
                            }
                            else if (symbol == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        break;

                    case "left":
                        if (colIndex != 0)
                        {
                            colIndex--;
                            char symbol = matrix[rowIndex, colIndex];
                            matrix[rowIndex, colIndex] = '*';
                            if (symbol == 'c')
                            {
                                countOfCollectedCoals++;
                                if (countOfCollectedCoals == countOfAllCounts)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    Environment.Exit(0);
                                }
                            }
                            else if (symbol == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        break;

                    case "down":
                        if (rowIndex != matrix.GetLength(0) - 1)
                        {
                            rowIndex++;
                            char symbol = matrix[rowIndex, colIndex];
                            matrix[rowIndex, colIndex] = '*';
                            if (symbol == 'c')
                            {
                                countOfCollectedCoals++;
                                if (countOfCollectedCoals == countOfAllCounts)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    Environment.Exit(0);
                                }
                            }
                            else if (symbol == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"{countOfAllCounts - countOfCollectedCoals} coals left. ({rowIndex}, {colIndex})");
        }
    }
}
/*
5
up right right up right
* * * c *
* * * e *
* * c * *
s * * c *
* * c * *

4
up right right right down
* * * e
* * c *
* s * c
* * * *

6
left left down right up left left down down down
* * * * * *
e * * * c *
* * c s * *
* * * * * *
c * * * c *
* * c * * *

 */