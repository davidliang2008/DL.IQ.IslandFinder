using System;

namespace DL.IQ.IslandFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] map = new int[,]
            {
                { 0, 1, 0, 0, 0, 1 },
                { 0, 1, 0, 0, 1, 0 },
                { 1, 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 0 },
                { 0, 0, 1, 0, 1, 0 },
                { 1, 0, 1, 0, 0, 1 }
            };

            Print(map);

            Console.WriteLine($"Number of islands is: { GetIslandCount(map)}");

            Console.ReadKey();
        }

        static int GetIslandCount(int[,] map)
        {
            // Get the dimension of the map
            int row = map.GetLength(0),
                col = map.GetLength(1);

            // Create a bool array to store visited coordinates
            bool[,] visited = new bool[row, col];

            int count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (IsOKToSearch(map, i, j, visited))
                    {
                        Search(map, i, j, visited);
                        count++;
                    }
                }
            }

            return count;
        }

        // A function to search recursively on the given coordinate's neighbours
        static void Search(int[,] map, int rowIndex, int colIndex, bool[,] visited)
        {
            // Mark this coordinate as visited
            visited[rowIndex, colIndex] = true;

            // Go through all 8 possible neighbours from that given coordinate:

            // Top left
            if (IsOKToSearch(map, rowIndex - 1, colIndex - 1, visited))
            {
                Search(map, rowIndex - 1, colIndex - 1, visited);
            }

            // Top center
            if (IsOKToSearch(map, rowIndex, colIndex - 1, visited))
            {
                Search(map, rowIndex, colIndex - 1, visited);
            }

            // Top right
            if (IsOKToSearch(map, rowIndex + 1, colIndex - 1, visited))
            {
                Search(map, rowIndex + 1, colIndex - 1, visited);
            }

            // Left
            if (IsOKToSearch(map, rowIndex - 1, colIndex, visited))
            {
                Search(map, rowIndex - 1, colIndex, visited);
            }

            // Right
            if (IsOKToSearch(map, rowIndex + 1, colIndex, visited))
            {
                Search(map, rowIndex + 1, colIndex, visited);
            }

            // Bottom left
            if (IsOKToSearch(map, rowIndex - 1, colIndex + 1, visited))
            {
                Search(map, rowIndex - 1, colIndex + 1, visited);
            }

            // Bottom center
            if (IsOKToSearch(map, rowIndex, colIndex + 1, visited))
            {
                Search(map, rowIndex, colIndex + 1, visited);
            }

            // Bottom right
            if (IsOKToSearch(map, rowIndex + 1, colIndex + 1, visited))
            {
                Search(map, rowIndex + 1, colIndex + 1, visited);
            }
        }

        // A function to help determine whether it's OK to proceed the search
        // based on the given row and column index.
        static bool IsOKToSearch(int[,] map, int rowIndex, int colIndex, bool[,] visited)
        {
            // Get the dimension of the map
            int row = map.GetLength(0),
                col = map.GetLength(1);

            return
                rowIndex >= 0 && rowIndex < row &&
                colIndex >= 0 && colIndex < col &&
                map[rowIndex, colIndex] == 1 &&
                !visited[rowIndex, colIndex];
        }

        // A function to display the matrix
        static void Print(int[,] map)
        {
            Console.WriteLine("The input map looks like:");

            // Get the dimension of the map
            int row = map.GetLength(0),
                col = map.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write($"{ map[i, j] }|");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
