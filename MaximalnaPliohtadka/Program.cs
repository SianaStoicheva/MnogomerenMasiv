namespace MaximalnaPliohtadka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split();
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 0; col < m - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] +
                              matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Max sum is: {maxSum}");
            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
        }
    }
}
