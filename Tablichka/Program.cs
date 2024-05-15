namespace Tablichka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][,] document = new int[n][,];

            for (int i = 0; i < n; i++)
            {
                string[] sizes = Console.ReadLine().Split();
                int rows = int.Parse(sizes[0]);
                int cols = int.Parse(sizes[1]);
                document[i] = new int[rows, cols];

               
                for (int row = 0; row < rows; row++)
                {
                    string[] values = Console.ReadLine().Split();
                    for (int col = 0; col < cols; col++)
                    {
                        document[i][row, col] = int.Parse(values[col]);
                    }
                }
            }

            double[] minValues = new double[n];
            double[] maxValues = new double[n];
            double[] sheetAverages = new double[n];
            double totalSum = 0;
            int totalElements = 0;
            for (int i = 0; i < n; i++)
            {
                double min = double.MaxValue;
                double max = double.MinValue;
                double sum = 0;
                int elements = 0;
                int rows = document[i].GetLength(0);
                int cols = document[i].GetLength(1);
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        int value = document[i][row, col];
                        sum += value;
                        elements++;
                        min = Math.Min(min, value);
                        max = Math.Max(max, value);
                    }
                }
                minValues[i] = min;
                maxValues[i] = max;
                sheetAverages[i] = sum / elements;
                totalSum += sum;
                totalElements += elements;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{minValues[i]} {maxValues[i]} {sheetAverages[i]}");
            }

            double documentAverage = totalSum / totalElements;
            int[] aboveAverageCount = new int[n];

            for (int i = 0; i < n; i++)
            {
                int rows = document[i].GetLength(0);
                int cols = document[i].GetLength(1);
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (document[i][row, col] > documentAverage)
                        {
                            aboveAverageCount[i]++;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", aboveAverageCount));
        }
    }
}
